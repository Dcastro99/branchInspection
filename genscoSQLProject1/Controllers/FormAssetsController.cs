//using AutoMapper;
//using genscoSQLProject1.Dto;
//using genscoSQLProject1.Interfaces;
//using genscoSQLProject1.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace genscoSQLProject1.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class FormAssetsController : Controller
//    {
//        private readonly IFormAssetsRepository _formAssetsRepository;
//        private readonly IBranchInspectionRepository _branchInspectionRepository;
//        private readonly IMapper _mapper;

//        public FormAssetsController(IFormAssetsRepository formAssetsRepository, IBranchInspectionRepository branchInspectionRepository, IMapper mapper)
//        {
//            _formAssetsRepository = formAssetsRepository;
//            _branchInspectionRepository = branchInspectionRepository;
//            _mapper = mapper;
//        }

//        //--------------GET ALL FORM ASSETS----------------//

//        [HttpGet]
//        [ProducesResponseType(200, Type = typeof(IEnumerable<FormAssets>))]

//        public IActionResult GetFormAssets()
//        {
//            var formAssets = _mapper.Map<List<FormAssetsDto>>(_formAssetsRepository.GetAllFormAssets());

//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            return Ok(formAssets);
//        }



//        //--------------GET ASSETS BY BRANCH INSPECTION ID----------------//

//        [HttpGet("{branchInspectionId}/assets")]
//        [ProducesResponseType(200, Type = typeof(IEnumerable<AssetDto>))]
//        [ProducesResponseType(400)]
//        public IActionResult GetFormAssets(int branchInspectionId)
//        {
//            if (!_branchInspectionRepository.BranchInspectionExistsAsync(branchInspectionId).Result)
//                return NotFound();

//            var assets = _formAssetsRepository.GetAssetsByBranchInspectionId(branchInspectionId);

//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            var assetsDto = _mapper.Map<IEnumerable<AssetDto>>(assets);

//            return Ok(assetsDto);
//        }


//        //--------------CREATE FORM ASSET----------------//

//        [HttpPost]
//        [ProducesResponseType(201)]
//        [ProducesResponseType(400)]
//        [ProducesResponseType(409)] // Conflict response for duplicate entries
//        public IActionResult CreateFormAsset([FromBody] FormAssetsDto formAssetToCreate)
//        {
//            if (formAssetToCreate == null)
//                return BadRequest("FormAsset cannot be null");

//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            // Check if the asset already exists with the same BranchInspectionId and AssetId
//            if (_formAssetsRepository.FormAssetsExists(formAssetToCreate.AssetId, formAssetToCreate.BranchInspectionId))
//            {
//                return Conflict($"FormAsset with AssetId {formAssetToCreate.AssetId} and BranchInspectionId {formAssetToCreate.BranchInspectionId} already exists.");
//            }

//            var formAssetMap = _mapper.Map<FormAssets>(formAssetToCreate);

//            if (!_formAssetsRepository.CreateFormAssets(formAssetMap))
//            {
//                ModelState.AddModelError("", $"Something went wrong creating the form asset");
//                return StatusCode(500, ModelState);
//            }

//            return Ok("Successfully Created");
//        }





//    }
//}
