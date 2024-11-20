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

            if (branchInspection == null)
                return NotFound($"Branch inspection with ID {branchInspectionId} not found.");

            var branchInspectionDetailDto = _mapper.Map<BranchInspectionDetailDto>(branchInspection);

            return Ok(branchInspectionDetailDto);
        }

        



        //--------------CREATE BRANCH INSPECTION----------------// 
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(BranchInspectionDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateBranchInspection([FromBody] FormDto formDto)
        {
            if (formDto == null || formDto.Items == null || !formDto.Items.Any() || formDto.Assets == null || formDto.Category == null)
                return BadRequest(ModelState);

            DateTime currentMonth = DateTime.Now;
            var branchId = formDto.BranchInspection.BranchId;

            // Check if an inspection for the current month already exists for the given branch
            var existingInspection = (await _branchInspectionRepository.GetAllBranchInspectionsAsync())
                .Where(bi => bi.BranchId == branchId
                              && bi.SubmittedDate.HasValue
                              && bi.SubmittedDate.Value.Year == currentMonth.Year
                              && bi.SubmittedDate.Value.Month == currentMonth.Month)
                .OrderByDescending(bi => bi.SubmittedDate)
                .FirstOrDefault();

            if (existingInspection != null)
            {
                ModelState.AddModelError("", $"Branch Inspection already exists for this month.");
                return StatusCode(422, ModelState);
            }

            // Ensure model state is valid before proceeding 
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Start a transaction
            using (var transaction = await _context.Database.BeginTransactionAsync()) // Change to async
            {
                try
                {
                    // Map the DTO to the BranchInspection entity 
                    var branchInspection = _mapper.Map<BranchInspection>(formDto.BranchInspection);

                    // Attempt to create the branch inspection in the repository 
                    if (!await _branchInspectionRepository.CreateBranchInspectionAsync(branchInspection))
                    {
                        ModelState.AddModelError("", $"Something went wrong saving the branch inspection {branchInspection.BranchInspectionId}");
                        return StatusCode(500, ModelState);
                    }

                    var branchInspectionId = branchInspection.BranchInspectionId;

                    // Create related entities, including FormItems
                    await CreateRelatedFormEntriesAsync(branchInspectionId, formDto.Items, formDto.Assets, formDto.Category, branchId); // Change to async

                    // If everything is successful, commit the transaction 
                    await transaction.CommitAsync(); // Change to async

                    return Ok(branchInspectionId);
                }
                catch (Exception ex)
                {
                    // If something goes wrong, rollback the transaction 
                    await transaction.RollbackAsync(); // Change to async
                    ModelState.AddModelError("", "An error occurred while saving the branch inspection and related entries.");
                    return StatusCode(500, ModelState);
                }
            }
        }



        //--------------HELPER METHODS----------------//

        private async Task CreateRelatedFormEntriesAsync(
        int branchInspectionId,
        List<ChecklistItemDto> itemsDtos,
        List<AssetDto> assetsDtos,
        List<CategoryDto> categoryDtos,
        int branchId)
        {
            // Temporary to actual CategoryId mapping
            var categoryIdMap = new Dictionary<int, int>();

            //----------------- Create FormCategory for each CategoryDto -----------------//
            foreach (var categoryDto in categoryDtos)
            {
                var newCategory = new Category
                {
                    BranchInspectionId = branchInspectionId,
                    CategoryName = categoryDto.CategoryName,
                    CategoryComment = categoryDto.CategoryComment
                };

                await _CategoryRepository.CreateCategoryAsync(newCategory);

                // Store the actual CategoryId after creation
                categoryIdMap[categoryDto.CategoryId] = newCategory.CategoryId;
            }

            //----------------- Create FormItems for each ChecklistItemDto -----------------//
            foreach (var itemDto in itemsDtos)
            {
                var formItem = _mapper.Map<ChecklistItem>(itemDto);
                formItem.BranchInspectionId = branchInspectionId;

                // Assign actual CategoryId using the mapping
                if (categoryIdMap.TryGetValue(itemDto.CategoryId, out var actualCategoryId))
                {
                    formItem.CategoryId = actualCategoryId;
                }

                await _checklistItemsRepository.CreateChecklistItemAsync(formItem);
            }

        }

    }
}




