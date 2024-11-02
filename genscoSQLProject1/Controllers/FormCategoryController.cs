//using AutoMapper;
//using genscoSQLProject1.Dto;
//using genscoSQLProject1.Interfaces;
//using genscoSQLProject1.Models;
//using genscoSQLProject1.Repository;
//using Microsoft.AspNetCore.Mvc;

//namespace genscoSQLProject1.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class FormCategoryController:Controller
//    {
//        private readonly IFormCategoryRepository _formCategoryRepository;
//        private readonly IBranchInspectionRepository _branchInspeectionRepository;
//        private readonly IMapper _mapper;

//        public FormCategoryController(IFormCategoryRepository formCategoryRepository,IBranchInspectionRepository branchInspeectionRepository, IMapper mapper)
//        {
//            _formCategoryRepository = formCategoryRepository;
//            _branchInspeectionRepository = branchInspeectionRepository;
//            _mapper = mapper;
//        }

//        //--------------GET ALL FORM CATEGORIES----------------//

//        [HttpGet]
//        [ProducesResponseType(200, Type = typeof(IEnumerable<FormCategory>))]
//        public IActionResult GetFormCategories()
//        {
//            var formCategories = _mapper.Map<List<FormCategoryDto>>(_formCategoryRepository.GetAllFormCategories());

//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            return Ok(formCategories);
//        }

//        //--------------GET FORM CATEGORY BY ID----------------//
//        [HttpGet("{formCategoryId}")]
//        [ProducesResponseType(201, Type = typeof(FormCategory))]
//        [ProducesResponseType(400)]

//        public IActionResult GetFormCategory(int formCategoryId)
//        {
//            if (!_formCategoryRepository.FormCategoryExists(formCategoryId))
//                return NotFound();

//            var formCategory = _mapper.Map<FormCategoryDto>(_formCategoryRepository.GetFormCategory(formCategoryId));

//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            return Ok(formCategory);
//        }

//        //--------------CREATE FORM CATEGORY----------------//
//        [HttpPost]
//        [ProducesResponseType(201, Type = typeof(FormCategory))]
//        [ProducesResponseType(400)]
//        [ProducesResponseType(500)]

//        public IActionResult CreateFormCategory([FromBody] FormCategory formCategoryToCreate)
//        {
//            if (formCategoryToCreate == null)
//                return BadRequest(ModelState);

            

//            if (!_formCategoryRepository.CreateFormCategory(formCategoryToCreate))
//            {
//                ModelState.AddModelError("", $"Something went wrong saving the form category {formCategoryToCreate.FormCategoryId}");
//                return StatusCode(500, ModelState);
//            }

//            return CreatedAtRoute("GetFormCategory", new { formCategoryId = formCategoryToCreate.FormCategoryId }, formCategoryToCreate);
//        }



//    }
//}
