using AutoMapper;
using genscoSQLProject1.Dto;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;
using Microsoft.AspNetCore.Mvc;

namespace genscoSQLProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetItemsController : Controller
    {
        private readonly IAssetItemsRepository _assetItemsRepository;
        private readonly IMapper _mapper;

        public AssetItemsController(IAssetItemsRepository assetItemsRepository, IMapper mapper)
        {
            _assetItemsRepository = assetItemsRepository;
            _mapper = mapper;
        }

        //--------------GET ALL ASSET ITEMS----------------//
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AssetItems>))]
        public IActionResult GetAssetItems()
        {
            var assetItems = _mapper.Map<List<AssetItemsDto>>(_assetItemsRepository.GetAllAssetItems());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(assetItems);
        }

        //--------------GET ASSET ITEM BY ID----------------//

        [HttpGet("{checklistItemId}/{assetId}/{branchInspectionId}")]
        [ProducesResponseType(200, Type = typeof(AssetItems))]
        [ProducesResponseType(400)]
        public IActionResult GetAssets(int checklistItemId, int assetId, int branchInspectionId)
        {
            if (!_assetItemsRepository.AssetItemsExists(checklistItemId, assetId, branchInspectionId))
                return NotFound();

            var assetItem = _assetItemsRepository.GetAssetItems(checklistItemId, assetId, branchInspectionId);

            if (assetItem == null)
                return NotFound();

            return Ok(assetItem);
        }


        //--------------CREATE ASSET ITEM----------------//

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult CreateAssetItems([FromBody] AssetItemsDto assetItemsToCreate)
        {
            // Check if the DTO is null
            if (assetItemsToCreate == null)
                return BadRequest("Asset Item cannot be null.");

            // Check if the asset item already exists
            if (_assetItemsRepository.AssetItemsExists(assetItemsToCreate.ChecklistItemId, assetItemsToCreate.AssetId, assetItemsToCreate.BranchInspectionId))
            {
                ModelState.AddModelError("", "Asset Item already exists.");
                return BadRequest(ModelState);
            }

            // Validate the model state
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Map the DTO to the AssetItems model
            var assetItemMap = _mapper.Map<AssetItems>(assetItemsToCreate);

            // Try to create the asset item
            if (!_assetItemsRepository.CreateAssetItems(assetItemMap))
            {
                ModelState.AddModelError("", $"Something went wrong saving the asset item {assetItemMap.ChecklistItemId}");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Created");
        }


    }
}
