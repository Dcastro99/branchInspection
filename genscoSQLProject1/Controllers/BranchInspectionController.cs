using AutoMapper;
using genscoSQLProject1.Data;
using genscoSQLProject1.Dto;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace genscoSQLProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class BranchInspectionController: Controller
    {
        private readonly IBranchInspectionRepository _branchInspectionRepository;
        private readonly IFormCategoryRepository _formCategoryRepository;
        private readonly IFormItemsRepository _formItemsRepository;
        //private readonly IFormAssetsRepository _formAssetsRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public BranchInspectionController(
            IBranchInspectionRepository branchInspectionRepository,
            IFormCategoryRepository formCategoryRepository,
            IFormItemsRepository formItemsRepository,
            //IFormAssetsRepository formAssetsRepository,
            ICategoryRepository categoryRepository, 
            IMapper mapper,
            DataContext context
            )
        {
            _branchInspectionRepository = branchInspectionRepository;
            _formCategoryRepository = formCategoryRepository;
            _formItemsRepository = formItemsRepository;
            //_formAssetsRepository = formAssetsRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _context = context;
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
        public IActionResult CreateBranchInspection([FromBody] BranchInspectionDto branchInspectionToCreate)
        {
            if (branchInspectionToCreate == null)
                return BadRequest(ModelState);

            DateTime currentMonth = DateTime.Now;
            var branchId = branchInspectionToCreate.BranchId;

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
                    var branchInspection = _mapper.Map<BranchInspection>(branchInspectionToCreate);

                    // Attempt to create the branch inspection in the repository
                    if (!_branchInspectionRepository.CreateBranchInspection(branchInspection))
                    {
                        ModelState.AddModelError("", $"Something went wrong saving the branch inspection {branchInspection.BranchInspectionId}");
                        return StatusCode(500, ModelState);
                    }

                    var branchInspectionId = branchInspection.BranchInspectionId;

                    // Create related entities
                    CreateRelatedFormEntries(branchInspectionId);

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




        private void CreateRelatedFormEntries(int branchInspectionId)
        {
            // Get valid category ids
            var validCategoryIds = _categoryRepository.GetAllCategories()
                .Where(c => !_formCategoryRepository.FormCategoriesExists(c.CategoryId, branchInspectionId))
                .Select(c => c.CategoryId)
                .ToList();

            if (!validCategoryIds.Any())
            {
                ModelState.AddModelError("", "No valid categories found.");
                throw new InvalidOperationException("No valid categories found.");
            }

            // Create FormCategory for each valid CategoryId
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
                        // Set other properties as needed
                    };

                    _formCategoryRepository.CreateFormCategory(formCategory);
                }
            }

            //// Create FormItems
            //var formItems = new FormItems
            //{
            //    BranchInspectionId = branchInspectionId,
            //    // Other properties
            //};
            //_formItemsRepository.CreateFormItems(formItems);

            //// Create FormAssets
            //var formAssets = new FormAssets
            //{
            //    BranchInspectionId = branchInspectionId,
            //    // Other properties
            //};
            //_formAssetsRepository.CreateFormAssets(formAssets);
        }

        private List<int> GetValidCategoryIds()
        {
            // Retrieve all categories from the repository
            var categories = _categoryRepository.GetAllCategories();

            // Extract the CategoryId as a list of integers
            var categoryIds = categories.Select(c => c.CategoryId).ToList();

            // If no categories exist, create default categories
            if (!categoryIds.Any())
            {
                var defaultCategories = new List<Category>
        {
            new Category { CategoryName = "Default Category 1" },
            new Category { CategoryName = "Default Category 2" },
            // Add as many default categories as needed
        };

                // Use the repository to add new categories
                _categoryRepository.CreateCategories(defaultCategories);

                // After creating, retrieve the newly created CategoryIds
                categoryIds = defaultCategories.Select(c => c.CategoryId).ToList();
            }

            return categoryIds;
        }




    }


}
