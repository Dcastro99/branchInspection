using AutoMapper;
using genscoSQLProject1.Data;
using genscoSQLProject1.Dto;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;


namespace genscoSQLProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class BranchInspectionController: Controller
    {
        private readonly IBranchInspectionRepository _branchInspectionRepository;
        private readonly IFormCategoryRepository _formCategoryRepository;
        private readonly IFormItemsRepository _formItemsRepository;
        private readonly IFormAssetsRepository _formAssetsRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly ILogger<BranchInspectionController> _logger;

        public BranchInspectionController(
            IBranchInspectionRepository branchInspectionRepository,
            IFormCategoryRepository formCategoryRepository,
            IFormItemsRepository formItemsRepository,
            IFormAssetsRepository formAssetsRepository,
            ICategoryRepository categoryRepository, 
            IMapper mapper,
            DataContext context,
            ILogger<BranchInspectionController> logger
            )
        {
            _branchInspectionRepository = branchInspectionRepository;
            _formCategoryRepository = formCategoryRepository;
            _formItemsRepository = formItemsRepository;
            _formAssetsRepository = formAssetsRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        //--------------GET ALL BRANCH INSPECTIONS----------------//
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BranchInspection>))]

        public IActionResult GetBranchInspections()
        {
            var branchInspections = _mapper.Map<List<BranchInspectionDto>>(_branchInspectionRepository.GetAllBranchInspections());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(branchInspections);
        }

        //--------------GET BRANCH INSPECTION BY ID----------------//

        [HttpGet("{branchInspectionId}")]
        [ProducesResponseType(200, Type = typeof(BranchInspection))]
        [ProducesResponseType(400)]

        public IActionResult GetBranchInspection(int branchInspectionId)
        {
            if (!_branchInspectionRepository.BranchInspectionExists(branchInspectionId))
                return NotFound();

            var branchInspection = _mapper.Map<BranchInspectionDto>(_branchInspectionRepository.GetBranchInspection(branchInspectionId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(branchInspection);
        }

        //--------------CREATE BRANCH INSPECTION----------------//

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(BranchInspection))]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public IActionResult CreateBranchInspection([FromBody] FormDto formDto)
        {
            if (formDto == null || formDto.FormItems == null || !formDto.FormItems.Any() || formDto.FormAssets == null)
                return BadRequest(ModelState);

            if (formDto == null)
            {
                _logger.LogError("FormDto is null");
                return BadRequest("Invalid form data.");
            }

            if (formDto.FormItems == null || !formDto.FormItems.Any())
            {
                _logger.LogError("FormItems is null or empty");
                return BadRequest("FormItems cannot be null or empty.");
            }

            if (formDto.FormAssets == null || !formDto.FormAssets.Any())
            {
                _logger.LogError("FormAssets is null or empty");
                return BadRequest("FormAssets cannot be null or empty.");
            }



            DateTime currentMonth = DateTime.Now;
            var branchId = formDto.BranchInspection.BranchId;

            // Check if an inspection for the current month already exists for the given branch
            var existingInspection = _branchInspectionRepository.GetAllBranchInspections()
                .Where(bi => bi.BranchId == branchId
                            && bi.SubmittedDate.HasValue
                            && bi.SubmittedDate.Value.Year == currentMonth.Year
                            && bi.SubmittedDate.Value.Month == currentMonth.Month
                            && bi.DeleteFlag == "N")
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
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Map the DTO to the BranchInspection entity
                    var branchInspection = _mapper.Map<BranchInspection>(formDto.BranchInspection);

                    // Attempt to create the branch inspection in the repository
                    if (!_branchInspectionRepository.CreateBranchInspection(branchInspection))
                    {
                        ModelState.AddModelError("", $"Something went wrong saving the branch inspection {branchInspection.BranchInspectionId}");
                        return StatusCode(500, ModelState);
                    }

                    var branchInspectionId = branchInspection.BranchInspectionId;

                    // Create related entities, including FormItems
                    CreateRelatedFormEntries(branchInspectionId, formDto.FormItems, formDto.FormAssets);

                 

                    // If everything is successful, commit the transaction
                    transaction.Commit();

                    return Ok(branchInspectionId);
                }
                catch (Exception ex)
                {
                    // If something goes wrong, rollback the transaction
                    transaction.Rollback();
                    ModelState.AddModelError("", "An error occurred while saving the branch inspection and related entries.");
                    return StatusCode(500, ModelState);
                }
            }
        }



        //--------------HELPER METHODS----------------//

        private void CreateRelatedFormEntries(int branchInspectionId, List<FormItemsDto> formItemsDtos, List<FormAssetsDto> formAssetsDtos)
        {


            //-------------- Get valid category ids --------------//

            var validCategoryIds = _categoryRepository.GetAllCategories()
                .Where(c => !_formCategoryRepository.FormCategoriesExists(c.CategoryId, branchInspectionId))
                .Select(c => c.CategoryId)
                .ToList();

            if (!validCategoryIds.Any())
            {
                ModelState.AddModelError("", "No valid categories found.");
                throw new InvalidOperationException("No valid categories found.");
            }



            //----------------- Create FormCategory for each valid CategoryId -----------------//

            foreach (var categoryId in validCategoryIds)
            {
                // Check if the FormCategory already exists for this BranchInspectionId and CategoryId
                var existingFormCategory = _formCategoryRepository.FormCategoriesExists(categoryId, branchInspectionId);

                if (!existingFormCategory)
                {
                    var formCategory = new FormCategory
                    {
                        BranchInspectionId = branchInspectionId,
                        CategoryId = categoryId,
                    };

                    _formCategoryRepository.CreateFormCategory(formCategory);
                }
            }



            //------------- Create FormItems based on user input ------------------//

            foreach (var formItemDto in formItemsDtos)
            {
                // Map DTO to FormItems entity
                var formItem = _mapper.Map<FormItems>(formItemDto);
                formItem.BranchInspectionId = branchInspectionId; // Assign the current BranchInspectionId

                // Create FormItems
                _formItemsRepository.CreateFormItems(formItem);
            }



            //----------- Create FormAssets(Optional -currently commented out) ------------//


           
                foreach (var formAssetDto in formAssetsDtos)
                {
                    //var formAsset = _mapper.Map<FormAssets>(formAssetDto);
                    //formAsset.BranchInspectionId = branchInspectionId;
                    //formAsset.AssetId = formAssetDto.AssetId;

                    var formAsset = new FormAssets
                    {
                        BranchInspectionId = branchInspectionId,
                        AssetId = formAssetDto.AssetId
                    };


                _logger.LogInformation("FormAsset: BranchInspectionId = {BranchInspectionId}, AssetId = {AssetId}", formAsset.BranchInspectionId, formAsset.AssetId);


                    try
                    {
                        _formAssetsRepository.CreateFormAssets(formAsset);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"Error inserting form asset: {ex.Message}");
                        throw; // Re-throw or handle accordingly
                    }
                }
            
        }

    }


}
