using AutoMapper;
using genscoSQLProject1.Builder;
using genscoSQLProject1.Dto;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;
using Microsoft.AspNetCore.Mvc;
using genscoSQLProject1.SeedData;


namespace genscoSQLProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        //--------------GET ALL CATEGORIES----------------//
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryDto>))]
        public async Task<IActionResult> GetCategories()
        {
            var categories = _mapper.Map<List<CategoryDto>>(await _categoryRepository.GetAllCategoriesAsync());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(categories);
        }

        //--------------GET CATEGORY BY ID----------------//    
        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(CategoryDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCategory(int categoryId)
        {
            if (!await _categoryRepository.CategoryExistsAsync(categoryId))
                return NotFound();

            var category = _mapper.Map<CategoryDto>(await _categoryRepository.GetCategoryAsync(categoryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category);
        }

        //--------------CREATE CATEGORY----------------//
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CategoryDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDto categoryToCreate)
        {
            if (categoryToCreate == null)
                return BadRequest(ModelState);

            var existingCategory = (await _categoryRepository.GetAllCategoriesAsync())
                .FirstOrDefault(c => c.CategoryName.Trim().ToUpper() == categoryToCreate.CategoryName.Trim().ToUpper());

            if (existingCategory != null)
            {
                ModelState.AddModelError("", $"Category {categoryToCreate.CategoryName} already exists");
                return StatusCode(400, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryMap = _mapper.Map<Category>(categoryToCreate);

            if (!await _categoryRepository.CreateCategoryAsync(categoryMap))
            {
                ModelState.AddModelError("", $"Something went wrong saving {categoryMap.CategoryName}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtAction(nameof(GetCategory), categoryMap);
        }

        //------------------GENERATE CATEGORIES----------------//
        //[HttpGet("generateCategories")]
        //public async Task<IActionResult> GenerateCategories()


        //{
        //    var categoryNames = CategoryData.GetCategoryNames();
        //    var categoriesDto = new List<CategoryDto>();
        //    int startCatId = 1;

        //    foreach (var name in categoryNames)
        //    {
        //        var category = new CategoryBuilder(name).Build();




        //        categoriesDto.Add(new CategoryDto
        //        {
        //            CategoryName = category.CategoryName,
        //            CategoryId = startCatId,
        //            //CatRefId = startCatId
        //        });
        //        startCatId++;

        //    }

        //    return Ok(categoriesDto);
        //}

        [HttpGet("generateCategories")]
        public async Task<IActionResult> GenerateCategories()
        {
            var categoryNames = CategoryData.GetCategoryNames();
            var createdCategories = new List<CategoryDto>();

            foreach (var name in categoryNames)
            {
                var category = new CategoryBuilder(name).Build();

                // Create a DTO for the new category
                var categoryDto = new CategoryDto
                {
                    CategoryName = category.CategoryName
                };

                // Check if category already exists
                var existingCategory = (await _categoryRepository.GetAllCategoriesAsync())
                    .FirstOrDefault(c => c.CategoryName.Trim().ToUpper() == categoryDto.CategoryName.Trim().ToUpper());

                if (existingCategory == null)
                {
                    // Map DTO to Entity
                    var categoryEntity = _mapper.Map<Category>(categoryDto);

                    // Save to DB
                    var created = await _categoryRepository.CreateCategoryAsync(categoryEntity);

                    if (!created)
                    {
                        return StatusCode(500, $"Error occurred while creating category {categoryDto.CategoryName}");
                    }

                    // Retrieve the newly created category with the assigned ID
                    var savedCategory = (await _categoryRepository.GetAllCategoriesAsync())
                        .FirstOrDefault(c => c.CategoryName.Trim().ToUpper() == categoryDto.CategoryName.Trim().ToUpper());

                    if (savedCategory != null)
                    {
                        createdCategories.Add(_mapper.Map<CategoryDto>(savedCategory));
                    }
                }
                else
                {
                    // If category already exists, return its existing ID
                    createdCategories.Add(_mapper.Map<CategoryDto>(existingCategory));
                }
            }

            return Ok(createdCategories);
        }


    }
}
