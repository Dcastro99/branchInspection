using AutoMapper;
using genscoSQLProject1.Dto;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;
using Microsoft.AspNetCore.Mvc;

namespace genscoSQLProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormChecklistItemsController : Controller  
    {
        private readonly IFormChecklistItemsRepository _formChecklistItemRepository;
        private readonly IMapper _mapper;


        public FormChecklistItemsController(
            IFormChecklistItemsRepository formChecklistItemRepository,
            IMapper mapper)
        {
            _formChecklistItemRepository = formChecklistItemRepository;
            _mapper = mapper;
        }

        //--------------GET ALL FORM CHECKLIST ITEMS----------------//
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<FormChecklistItemsDto>))]

        public async Task<IActionResult> GetAllFormChecklistItems()
        {
            var formChecklistItems = await _formChecklistItemRepository.GetAllFormChecklistItemsAsync();
            var formChecklistItemDtos = _mapper.Map<List<FormChecklistItemsDto>>(formChecklistItems);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(formChecklistItemDtos);
        }

        //--------------GET FORM CHECKLIST ITEM BY ID----------------//
        [HttpGet("{formChecklistItemId}")]
        [ProducesResponseType(200, Type = typeof(FormChecklistItemsDto))]
        [ProducesResponseType(400)]

        public async Task<IActionResult> GetFormChecklistItemById(int formChecklistItemId)
        {
            if (!await _formChecklistItemRepository.FormChecklistItemExistsAsync(formChecklistItemId))
                return NotFound();
            var formChecklistItem = await _formChecklistItemRepository.GetFormChecklistItemAsync(formChecklistItemId);
            var formChecklistItemDto = _mapper.Map<FormChecklistItemsDto>(formChecklistItem);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(formChecklistItemDto);
        }

        //--------------CREATE FORM CHECKLIST ITEM----------------//
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(FormChecklistItemsDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]

        public async Task<IActionResult> CreateFormChecklistItem([FromBody] FormChecklistItemsDto formChecklistItemDto)
        {
            if (formChecklistItemDto == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var formChecklistItem = _mapper.Map<FormChecklistItems>(formChecklistItemDto);
            if (!await _formChecklistItemRepository.CreateFormChecklistItemAsync(formChecklistItem))
                return StatusCode(500, "A problem happened while handling your request.");
            return CreatedAtAction("GetFormChecklistItemById", new { formChecklistItemId = formChecklistItem.FormChecklistItemId }, formChecklistItem);
        }


    }
}
