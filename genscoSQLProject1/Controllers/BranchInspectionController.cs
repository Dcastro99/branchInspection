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
            int branchId
        )
        {
            //-------------- Get valid category ids --------------//

            var allCategories = await _categoryRepository.GetAllCategoriesAsync();

            // Filter valid category IDs based on the provided formCategoryDtos
            var validCategoryIds = allCategories
                .Where(c => categoryDtos.Select(fc => fc.CategoryId).Contains(c.CategoryId))
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
                var existingCategory = await _CategoryRepository.CategoriesExistsAsync(categoryId, branchInspectionId); // Change to async

                if (!existingCategory)
                {
                    // Find the comment for this categoryId, if available
                    var categoryDto = categoryDtos.FirstOrDefault(c => c.CategoryId == categoryId);
                    var categoryComment = categoryDto?.CategoryComment;

                    // Create new FormCategory
                    var newCategory = new Category
                    {
                        BranchInspectionId = branchInspectionId,
                        CategoryId = categoryId,
                        CategoryComment = categoryComment
                    };

                    await _CategoryRepository.CreateCategoryAsync(newCategory); // Change to async
                }
            }



            //------------- Create FormItems ------------------//

            foreach (var itemDto in itemsDtos)
            {
                // Map DTO to FormItems entity
                var formItem = _mapper.Map<ChecklistItem>(itemDto);
                formItem.BranchInspectionId = branchInspectionId; // Assign the current BranchInspectionId

                // Create FormItems
               await _checklistItemsRepository.CreateChecklistItemAsync(formItem); 
            }



            ////----------- Create FormAssets ------------//

            //foreach (var assetDto in assetsDtos)

            //{

            //    var asset = _assetRepository.GetAssetAsync(assetDto.AssetId);

            //    if (asset != null && asset.Bran
            //    {
            //        var formAsset = new Asset
            //        {
            //            BranchInspectionId = branchInspectionId,
            //            AssetId = formAssetDto.AssetId
            //        };

            //       await _assetRepository.CreateAssetAsync(formAsset);
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", $"Asset with ID {formAssetDto.AssetId} not found or does not belong to the branch.");
            //        throw new InvalidOperationException($"Asset with ID {formAssetDto.AssetId} not found or does not belong to the branch.");
            //    }

            //}

        }


    }
}
