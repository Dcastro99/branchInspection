using AutoMapper;
using genscoSQLProject1.Dto;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;
using genscoSQLProject1.Repository;
using Microsoft.AspNetCore.Mvc;

namespace genscoSQLProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : Controller
    {
        private readonly IAssetRepository _assetRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;

        public AssetController(IAssetRepository assetRepository,IBranchRepository branchRepository, IMapper mapper)
        {
            _assetRepository = assetRepository;
            _branchRepository = branchRepository;
            _mapper = mapper;
        }



        //--------------GET ALL ASSETS----------------//
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Asset>))]
        public IActionResult GetAssets()
        {
            var assets = _mapper.Map<List<AssetDto>>(_assetRepository.GetAllAssets());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(assets);
        }


        //--------------GET ASSET BY ID----------------//
        [HttpGet("{assetId}")]
        [ProducesResponseType(200, Type = typeof(Asset))]
        [ProducesResponseType(400)]

        public IActionResult GetAsset(int assetId)
        {
            if (!_assetRepository.AssetExists(assetId))
                return NotFound();

            var asset = _mapper.Map<AssetDto>(_assetRepository.GetAsset(assetId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(asset);
        }

        //--------------GET ASSET BY BRANCH ID----------------//
        [HttpGet("branchAsset/{branchNumber}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Asset>))]
        [ProducesResponseType(400)]

        public IActionResult GetAssetByBranch(int branchNumber)
        {
            var assets = _mapper.Map<List<AssetDto>>(_assetRepository.GetAssetByBranch(branchNumber));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(assets);
        }

        //--------------GET BRANCH BY ASSET ID----------------//
        [HttpGet("branch/{assetId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Branch>))]
        [ProducesResponseType(400)]

        public IActionResult GetBranchByAsset(int assetId)
        {
            var branches = _mapper.Map<List<BranchDto>>(_assetRepository.GetBranchByAsset(assetId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(branches);
        }

        //--------------CREATE ASSET----------------//
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult CreateAsset([FromBody] AssetDto assetToCreate)
        {
            if (assetToCreate == null)
                return BadRequest(ModelState);

            // Check if the asset already exists
            var asset = _assetRepository.GetAllAssets()
                .Where(a => a.AssetNumber == assetToCreate.AssetNumber)
                .FirstOrDefault();

            if (asset != null)
            {
                ModelState.AddModelError("", $"Asset {assetToCreate.AssetNumber} already exists");
                return StatusCode(422, ModelState);
            }

            // Check if the branch exists by BranchNumber
            var branch = _branchRepository.GetAllBranches()
                .FirstOrDefault(b => b.BranchNumber == assetToCreate.BranchNumber);

            if (branch == null)
            {
                ModelState.AddModelError("", "Branch not found.");
                return StatusCode(400, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Map the AssetDto to the Asset entity
            var assetMap = _mapper.Map<Asset>(assetToCreate);

            // Assign the branch to the asset
            assetMap.BranchId = branch.BranchId;

            // Save the new asset
            if (!_assetRepository.CreateAsset(assetMap))
            {
                ModelState.AddModelError("", $"Something went wrong saving the asset {assetMap.AssetNumber}");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Created");
        }




    }
}
