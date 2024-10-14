//using AutoMapper;
//using genscoSQLProject1.Dto;
//using genscoSQLProject1.Interfaces;
//using genscoSQLProject1.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace genscoSQLProject1.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AssetItemsController: Controller
//    {
//        private readonly IAssetItemsRepository _assetItemsRepository;
//        private readonly IMapper _mapper;

//        public AssetItemsController(IAssetItemsRepository assetItemsRepository, IMapper mapper)
//        {
//            _assetItemsRepository = assetItemsRepository;
//            _mapper = mapper;
//        }

//        //--------------GET ALL ASSET ITEMS----------------//
//        [HttpGet]
//        [ProducesResponseType(200, Type = typeof(IEnumerable<AssetItems>))]
//        public IActionResult GetAssetItems()
//        {
//            var assetItems = _mapper.Map<List<AssetItemsDto>>(_assetItemsRepository.GetAllAssetItems());

//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            return Ok(assetItems);
//        }

//        //--------------GET ASSET ITEM BY ID----------------//

//        [HttpGet("{assetItemsId}")]
//        [ProducesResponseType(200, Type = typeof(AssetItems))]
//        [ProducesResponseType(400)]

//        public IActionResult GetAssets(int assetItemsId) {
//            if (!_assetItemsRepository.AssetItemsExists(assetItemsId))
//                return NotFound();

//            var assetItems = _mapper.Map<AssetItemsDto>(_assetItemsRepository.GetAssetItems(assetItemsId));

//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            return Ok(assetItems);
//        }
//    }
//}
