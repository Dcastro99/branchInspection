using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using genscoSQLProject1.Dto;
using genscoSQLProject1.SeedData;
using genscoSQLProject1.Builder;
using genscoSQLProject1.Repository;


namespace genscoSQLProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChecklistItemController : Controller
    {
        private readonly IChecklistItemRepository _checklistItemRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ChecklistItemController(
            IChecklistItemRepository checklistItemRepository,
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _checklistItemRepository = checklistItemRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        //--------------GET ALL CHECKLIST ITEMS----------------//
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ChecklistItemDto>))]
        public async Task<IActionResult> GetAllChecklistItems()
        {
            var checklistItems = await _checklistItemRepository.GetAllChecklistItemsAsync();
            var checklistItemDtos = _mapper.Map<List<ChecklistItemDto>>(checklistItems);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(checklistItemDtos);
        }

        //--------------GET CHECKLIST ITEM BY ID----------------//
        [HttpGet("{checklistItemId}")]
        [ProducesResponseType(200, Type = typeof(ChecklistItemDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetChecklistItemById(int checklistItemId)
        {
            if (!await _checklistItemRepository.ChecklistItemExistsAsync(checklistItemId))
                return NotFound();

            var checklistItem = await _checklistItemRepository.GetChecklistItemAsync(checklistItemId);
            var checklistItemDto = _mapper.Map<ChecklistItemDto>(checklistItem);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(checklistItemDto);
        }

        //--------------CREATE CHECKLIST ITEM----------------//
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ChecklistItemDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateChecklistItem([FromBody] ChecklistItemDto checklistItemToCreate)
        {
            if (checklistItemToCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingChecklistItems = await _checklistItemRepository.GetAllChecklistItemsAsync();
            var existingChecklistItem = existingChecklistItems
                .FirstOrDefault(c => c.Name.Trim().ToUpper() == checklistItemToCreate.Name.Trim().ToUpper());

            if (existingChecklistItem != null)
            {
                ModelState.AddModelError("", $"Checklist item {checklistItemToCreate.Name} already exists");
                return StatusCode(422, ModelState);
            }

            var checklistItemMap = _mapper.Map<ChecklistItem>(checklistItemToCreate);

            if (!await _checklistItemRepository.CreateChecklistItemAsync(checklistItemMap))
            {
                ModelState.AddModelError("", $"Something went wrong saving the checklist item {checklistItemMap.Name}");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Created");
        }

        //--------------GENERATE CHECKLIST ITEMS USING BUILDER----------------//

        [HttpGet("generateChecklistItems")]
        public async Task<IActionResult> GenerateChecklistItems()


        {

            var checklistItems = ChecklistItemsData.GetChecklistItems();

            
            int startingId = 1;

            
            foreach (var item in checklistItems)
            {
                item.ChecklistItemId = startingId;
                startingId++; 
            }



            return Ok(checklistItems);
        }


    }
}
