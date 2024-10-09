using AutoMapper;
using genscoSQLProject1.Dto;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;
using Microsoft.AspNetCore.Mvc;

namespace genscoSQLProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChecklistItemController : Controller
    {
        private readonly IChecklistItemRepository _checklistItemRepository;
        private readonly IMapper _mapper;

        public ChecklistItemController(IChecklistItemRepository checklistItemRepository, IMapper mapper)
        {
            _checklistItemRepository = checklistItemRepository;
            _mapper = mapper;
        }

        //--------------GET ALL CHECKLIST ITEMS----------------//

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ChecklistItem>))]

        public IActionResult GetChecklistItems()
        {
            var checklistItems = _mapper.Map<List<ChecklistItemDto>>(_checklistItemRepository.GetAllChecklistItems());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(checklistItems);
        }

        //--------------GET CHECKLIST ITEM BY ID----------------//

        [HttpGet("{checklistItemId}")]
        [ProducesResponseType(200, Type = typeof(ChecklistItem))]
        [ProducesResponseType(400)]

        public IActionResult GetChecklistItem(int checklistItemId)
        {
            if (!_checklistItemRepository.ChecklistItemExists(checklistItemId))
                return NotFound();

            var checklistItem = _mapper.Map<ChecklistItemDto>(_checklistItemRepository.GetChecklistItem(checklistItemId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(checklistItem);
        }

        //--------------GET CHECKLIST ITEM BY CATEGORY ID----------------//

        [HttpGet("category/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ChecklistItem>))]
        [ProducesResponseType(400)]

        public IActionResult GetChecklistItemByCategory(int categoryId)
        {
            if (!_checklistItemRepository.ChecklistItemExists(categoryId))
                return NotFound();

            var checklistItems = _mapper.Map<List<ChecklistItemDto>>(_checklistItemRepository.GetChecklistItemByCategory(categoryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(checklistItems);
        }

        //--------------CREATE CHECKLIST ITEM----------------//

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ChecklistItem))]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public IActionResult CreateChecklistItem([FromBody] ChecklistItemDto checklistItemToCreate)
        {
            if (checklistItemToCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingChecklistItem = _checklistItemRepository.GetAllChecklistItems()
                .FirstOrDefault(c => c.Name.Trim().ToUpper() == checklistItemToCreate.Name.Trim().ToUpper());

            if (existingChecklistItem != null)
            {
                ModelState.AddModelError("", $"Checklist item {checklistItemToCreate.Name} already exists");
                return StatusCode(422, ModelState);
            }

           

            // Map to ChecklistItem and handle AssetId
            var checklistItemMap = _mapper.Map<ChecklistItem>(checklistItemToCreate);

         
            // Attempt to create the checklist item
            if (!_checklistItemRepository.CreateChecklistItem(checklistItemMap))
            {
                ModelState.AddModelError("", $"Something went wrong saving the checklist item {checklistItemMap.Name}");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Created");
        }






    }
}
