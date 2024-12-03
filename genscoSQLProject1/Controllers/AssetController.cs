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

        public AssetController(IAssetRepository assetRepository, IBranchRepository branchRepository, IMapper mapper)
        {
            _assetRepository = assetRepository;
            _branchRepository = branchRepository;
            _mapper = mapper;
        }



        //--------------GET ALL ASSETS----------------//
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AssetDto>))]
        public async Task<IActionResult> GetAssets()
        {
            var assets = _mapper.Map<List<AssetDto>>(await _assetRepository.GetAllAssetsAsync());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(assets);
        }

        //--------------GET ASSET BY ID----------------//
        [HttpGet("{assetId}")]
        [ProducesResponseType(200, Type = typeof(AssetDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAsset(int assetId)
        {
            if (!await _assetRepository.AssetExistsAsync(assetId))
                return NotFound();

            var asset = _mapper.Map<AssetDto>(await _assetRepository.GetAssetAsync(assetId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(asset);
        }

        //--------------GET ASSET BY BRANCH NUMBER----------------//
        [HttpGet("branchAsset/{branchNumber}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AssetDto>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAssetByBranch(int branchNumber)
        {
            var assets = _mapper.Map<List<AssetDto>>(await _assetRepository.GetAssetByBranchAsync(branchNumber));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(assets);
        }

        //--------------GET BRANCH BY ASSET ID----------------//
        [HttpGet("branch/{assetId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BranchDto>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetBranchByAsset(int assetId)
        {
            var branches = _mapper.Map<List<BranchDto>>(await _assetRepository.GetBranchByAssetAsync(assetId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(branches);
        }

        //--------------CREATE ASSET----------------//

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateAsset([FromBody] AssetDto assetToCreate)
        {
            if (assetToCreate == null)
                return BadRequest(ModelState);

            // Check if the asset already exists
            var existingAsset = (await _assetRepository.GetAllAssetsAsync())
                .FirstOrDefault(a => a.AssetNumber == assetToCreate.AssetNumber);

            if (existingAsset != null)
            {
                ModelState.AddModelError("", $"Asset {assetToCreate.AssetNumber} already exists");
                return StatusCode(422, ModelState);
            }

            // Check if the branch exists by BranchNumber
            var branch = (await _branchRepository.GetAllBranchesAsync())
                .FirstOrDefault(b => b.BranchNumber == assetToCreate.BranchNumber);

            if (branch == null)
            {
                ModelState.AddModelError("", "Branch not found.");
                return BadRequest(ModelState);
            }

            // Map the AssetDto to the Asset entity
            var assetMap = _mapper.Map<Asset>(assetToCreate);

            // Assign the branch's BranchId to the asset
            assetMap.BranchNumber = branch.BranchNumber;
            assetMap.BranchId = branch.BranchId;

            // Save the new asset
            if (!await _assetRepository.CreateAssetAsync(assetMap))
            {
                ModelState.AddModelError("", $"Something went wrong saving the asset {assetMap.AssetNumber}");
                return StatusCode(500, ModelState);
            }

            // Map the created Asset entity back to AssetDto
            var createdAssetDto = _mapper.Map<AssetDto>(assetMap);

            // Return the created asset with 201 status
            return CreatedAtAction(nameof(CreateAsset), new { id = createdAssetDto.AssetId }, createdAssetDto);
        }



    }
}