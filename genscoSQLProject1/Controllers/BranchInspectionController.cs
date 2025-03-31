using AutoMapper;
using genscoSQLProject1.Data;
using genscoSQLProject1.Dto;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;
using genscoSQLProject1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;


namespace genscoSQLProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class BranchInspectionController : Controller
    {
        private readonly IBranchInspectionRepository _branchInspectionRepository;
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IChecklistItemRepository _checklistItemsRepository;
        private readonly IFormChecklistItemsRepository _formChecklistItemsRepository;
        private readonly IAssetRepository _AssetRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAssetRepository _assetRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly ILogger<BranchInspectionController> _logger;

        public BranchInspectionController(
            IBranchInspectionRepository branchInspectionRepository,
            ICategoryRepository CategoryRepository,
            IChecklistItemRepository checklistItemsRepository,
            IFormChecklistItemsRepository formChecklistItemsRepository,
            IAssetRepository AssetRepository,
            ICategoryRepository categoryRepository,
            IAssetRepository assetRepository,
            IMapper mapper,
            DataContext context,
            ILogger<BranchInspectionController> logger
            )
        {
            _branchInspectionRepository = branchInspectionRepository;
            _CategoryRepository = CategoryRepository;
            _checklistItemsRepository = checklistItemsRepository;
            _formChecklistItemsRepository = formChecklistItemsRepository;
            _AssetRepository = AssetRepository;
            _categoryRepository = categoryRepository;
            _assetRepository = assetRepository;
            _mapper = mapper;
            _context = context;
            _logger = logger;

        }

        //--------------GET ALL BRANCH INSPECTIONS----------------//
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BranchInspectionDto>))]
        public async Task<IActionResult> GetBranchInspections()
        {
            var branchInspections = _mapper.Map<List<BranchInspectionDto>>(await _branchInspectionRepository.GetAllBranchInspectionsAsync());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(branchInspections);
        }

        //--------------GET BRANCH INSPECTIONS BY NeedsApprovl----------------//
        [HttpGet("needsApproval")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BranchInspectionDto>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetBranchInspectionsNeedingApproval()
        {
            var branchInspections = _mapper.Map<List<BranchInspectionDto>>(
                await _branchInspectionRepository.GetBranchInspectionsNeedingApprovalAsync()
            );

            if (branchInspections == null || !branchInspections.Any())
                return NoContent();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(branchInspections);
        }

        //--------------GET BRANCH INSPECTIONS BY PENDING APPROVAL----------------//
        [HttpGet("pendingApproval/{branchNumber}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BranchInspectionDto>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetBranchInspectionsPendingApproval([FromRoute] int branchNumber)
        {
            var branchInspections = _mapper.Map<List<BranchInspectionDto>>(
                await _branchInspectionRepository.GetBranchInspectionsPendingApprovalAsync(branchNumber)
            );

            if (branchInspections == null || !branchInspections.Any())
                return NoContent();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(branchInspections);
        }

        //--------------GET BRANCH ISNPECTIONS BY BRANCH ID----------------//
        [HttpGet("history/{branchNumber}/{count}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BranchInspectionDto>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllBranchinspectionsByBranchId([FromRoute] int branchNumber, [FromRoute] int count)
        {
            var branchInspections = _mapper.Map<List<BranchInspectionDto>>(
                await _branchInspectionRepository.GetAllBranchInspectionByBranchIdAsync(branchNumber, count)
            );

            if (branchInspections == null || !branchInspections.Any())
                return NoContent();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(branchInspections);
        }



        //--------------GET BRANCH INSPECTION BY ID----------------//
        [HttpGet("{branchInspectionId}")]
        [ProducesResponseType(200, Type = typeof(BranchInspectionDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetBranchInspection(int branchInspectionId)
        {
            if (!await _branchInspectionRepository.BranchInspectionExistsAsync(branchInspectionId))
                return NotFound();

            var branchInspection = _mapper.Map<BranchInspectionDto>(await _branchInspectionRepository.GetBranchInspectionAsync(branchInspectionId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(branchInspection);
        }

        //--------------GET BRANCH INSPECTION DETAILS BY ID----------------//
        [HttpGet("{branchInspectionId}/details")]
        [ProducesResponseType(200, Type = typeof(BranchInspectionDetailDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetBranchInspectionWithDetails(int branchInspectionId)
        {
            if (branchInspectionId <= 0)
                return BadRequest("Invalid branch inspection ID.");

            var branchInspection = await _branchInspectionRepository.GetBranchInspectionWithDetailsAsync(branchInspectionId);

            _logger.LogInformation($"Branch Inspection:::::: {branchInspectionId}");

            if (branchInspection == null)
                return NotFound($"Branch inspection with ID {branchInspectionId} not found.");

            var branchInspectionDetailDto = _mapper.Map<BranchInspectionDetailDto>(branchInspection);

            return Ok(branchInspectionDetailDto);
        }





        //--------------CREATE BRANCH INSPECTION----------------// 
        [HttpPost]
        public async Task<IActionResult> CreateBranchInspection([FromBody] FormDto formDto)
        {
            _logger.LogInformation("CreateBranchInspection method started.");

            if (formDto == null)
            {
                _logger.LogWarning("Request body is null.");
                return BadRequest("Request body is null.");
            }

            _logger.LogInformation($"Received BranchId: {formDto.BranchInspection?.BranchId}");
            _logger.LogInformation($"Received Items Count: {formDto.Items?.Count}");
            //_logger.LogInformation($"Received Assets Count: {formDto.Assets?.Count}");

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                _logger.LogWarning("ModelState is invalid: {Errors}", string.Join(", ", errors));
                return BadRequest(new { message = "Invalid request", errors });
            }

            try
            {
                _logger.LogInformation("Checking if a branch inspection already exists for this month.");

                DateTime currentMonth = DateTime.Now;
                if (formDto?.BranchInspection == null)
                {
                    _logger.LogWarning("BranchInspection is null.");
                    return BadRequest("BranchInspection is null.");
                }

                var branchId = formDto.BranchInspection.BranchId;

                var existingInspection = (await _branchInspectionRepository.GetAllBranchInspectionsAsync())
                    .Where(bi => bi.BranchId == branchId
                                && bi.SubmittedDate.HasValue
                                && bi.SubmittedDate.Value.Year == currentMonth.Year
                                && bi.SubmittedDate.Value.Month == currentMonth.Month)
                    .OrderByDescending(bi => bi.SubmittedDate)
                    .FirstOrDefault();

                if (existingInspection != null)
                {
                    _logger.LogWarning("Branch Inspection already exists for this month.");
                    ModelState.AddModelError("", "Branch Inspection already exists for this month.");
                    return StatusCode(422, ModelState);
                }

                // Start transaction
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        _logger.LogInformation("Creating a new BranchInspection entry.");

                        var branchInspection = _mapper.Map<BranchInspection>(formDto.BranchInspection);
                        if (!await _branchInspectionRepository.CreateBranchInspectionAsync(branchInspection))
                        {
                            _logger.LogError("Error saving branch inspection.");
                            ModelState.AddModelError("", "Something went wrong saving the branch inspection.");
                            return StatusCode(500, ModelState);
                        }

                        var branchInspectionId = branchInspection.BranchInspectionId;
                        _logger.LogInformation($"BranchInspection created successfully with ID: {branchInspectionId}");

                        //Create related FormChecklistItems
                        await CreateRelatedFormEntriesAsync(branchInspectionId, formDto.Items, formDto.Comments, branchId);
                        _logger.LogInformation("FormChecklistItems created successfully.");

                        // Commit transaction
                        await transaction.CommitAsync();
                        _logger.LogInformation("Transaction committed successfully.");

                        return Ok(branchInspectionId);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error occurred while saving branch inspection. Message: {Message}", ex.Message);
                        await transaction.RollbackAsync();
                        return StatusCode(500, $"An error occurred while saving the branch inspection: {ex.Message}");
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception in CreateBranchInspection.");
                return StatusCode(500, "An unexpected error occurred.");
            }
        }



        //--------------HELPER METHODS----------------//

        private async Task CreateRelatedFormEntriesAsync(
            int branchInspectionId,
            List<FormChecklistItemsDto> items,
            //List<AssetDto> assets,
            List<FormCommentDto> comments,
            int branchId)
        {

            _logger.LogInformation($"Creating related FormChecklistItems and FormComments. BranchInsoectionId:: {branchInspectionId}");
           
            if (items == null || !items.Any())
            {
                //_logger.LogInformation("No form checklist items to add.");
                return;  
            }

            var formChecklistItems = items.ToList();
         
                //_logger.LogInformation("Checklist items after filtering:");
                foreach (var item in formChecklistItems)
                {
                    item.BranchInspectionId = branchInspectionId;
                    var checklistItemEntity = _mapper.Map<FormChecklistItems>(item);
                    checklistItemEntity.BranchInspectionId = branchInspectionId;

                    //_logger.LogInformation($"Item: {item.FormChecklistItemId}, BranchInspectionId: {item.BranchInspectionId}");

                    _context.FormChecklistItems.Add(checklistItemEntity);
                }
                await _context.SaveChangesAsync();


            if (comments != null && comments.Any())
            {
                _logger.LogInformation("Comments found. Adding to database.");

                foreach (var commentDto in comments)
                {
                    if (string.IsNullOrWhiteSpace(commentDto.Comment))
                    {
                        _logger.LogInformation($"Skipping empty comment for CategoryId {commentDto.CategoryId}");
                        continue; 
                    }

                    commentDto.BranchInspectionId = branchInspectionId;
                    _logger.LogInformation($"Comment before mapping: {commentDto.Comment}, BranchInspectionId: {commentDto.BranchInspectionId}");

                    var commentEntity = _mapper.Map<FormComment>(commentDto);
                    commentEntity.BranchInspectionId = branchInspectionId;
                    _logger.LogInformation($"Comment after mapping: {commentEntity.Comment}, BranchInspectionId: {commentEntity.BranchInspectionId}");

                    _context.FormComments.Add(commentEntity);
                }
                await _context.SaveChangesAsync();
            }
            else
            {
                _logger.LogInformation("No comments to add.");
            }


        }

        //-------------------UPDATE BRANCH INSPECTION----------------//
        [HttpPut("updateStatus")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateBranchInspectionStatus([FromBody] UpdateBranchInspectionStatusDto updateDto)
        {
            if (updateDto == null)
                return BadRequest("Data is null.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

           
            var branchInspection = await _branchInspectionRepository.GetBranchInspectionAsync(updateDto.BranchInspectionId);

            if (branchInspection == null)
                return NotFound($"BranchInspection with ID {updateDto.BranchInspectionId} not found.");

           
            if (!updateDto.IsApproved)
            {
                branchInspection.NeedsApproval = false;
            }
            else
            {
               
                branchInspection.NeedsApproval = false;
                branchInspection.ApprovedByUserId = updateDto.ApprovedByUserId ?? branchInspection.ApprovedByUserId;
                branchInspection.ApprovedDate = updateDto.ApprovedDate ?? DateTime.UtcNow;
            }

            if (!await _branchInspectionRepository.UpdateBranchInspectionAsync(branchInspection))
                return StatusCode(500, "An error occurred while updating the Branch Inspection.");

            return Ok("Branch Inspection status updated successfully.");
        }



    }
}




