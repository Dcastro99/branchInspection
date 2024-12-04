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
    public class FormNoteController : Controller
    {
        private readonly IFormNoteRepository _formNoteRepository;
        private readonly IMapper _mapper;
        public FormNoteController(IFormNoteRepository formNoteRepository, IMapper mapper)
        {
            _formNoteRepository = formNoteRepository;
            _mapper = mapper;
        }

        //--------------GET ALL FORM NOTES----------------//
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<FormNoteDto>))]
        public async Task<IActionResult> GetAllFormNotes()
        {
            var assets = _mapper.Map<List<FormNoteDto>>(await _formNoteRepository.GetAllFormNotesAsync());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(assets);
        }


        //--------------GET FORM NOTE BY ID----------------//
        [HttpGet("{formNoteId}")]
        [ProducesResponseType(200, Type = typeof(FormNoteDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetFormNote(int formNoteId)
        {
            if (!await _formNoteRepository.FormNoteExistsAsync(formNoteId))
                return NotFound();

            var formNote = _mapper.Map<FormNoteDto>(await _formNoteRepository.GetFormNoteAsync(formNoteId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(formNote);
        }

        //--------------GET FORM NOTE BY BRANCH INSPECTION ID----------------//
        [HttpGet("branchInspectionFormNote/{branchInspectionId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<FormNoteDto>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetFormNotesByBranchInspectionId(int branchInspectionId)
        {
            var formNotes = _mapper.Map<List<FormNoteDto>>(await _formNoteRepository.GetFormNotesByBranchInspectionIdAsync(branchInspectionId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(formNotes);
        }

        //--------------CREATE FORM NOTE----------------//
        [HttpPost("addFormNotes")]
        [ProducesResponseType(201, Type = typeof(IEnumerable<FormNoteDto>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateFormNotes([FromBody] List<FormNoteDto> formNoteDtos)
        {
            if (formNoteDtos == null || formNoteDtos.Count == 0)
                return BadRequest("Form note data is null or empty.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var formNotes = _mapper.Map<List<FormNote>>(formNoteDtos);

            foreach (var formNote in formNotes)
            {
                formNote.CreatedAt = DateTime.UtcNow; // Ensure consistency in timestamp
                var success = await _formNoteRepository.CreateFormNoteAsync(formNote);
                if (!success)
                    return StatusCode(500, "An error occurred while saving one of the form notes.");
            }

            var createdFormNoteDtos = _mapper.Map<List<FormNoteDto>>(formNotes);

            return CreatedAtAction(nameof(GetFormNotesByBranchInspectionId),
                new { branchInspectionId = formNotes[0].BranchInspectionId }, createdFormNoteDtos);
        }

        //[HttpPost]
        //[ProducesResponseType(201, Type = typeof(FormNoteDto))]
        //[ProducesResponseType(400)]
        //public async Task<IActionResult> CreateFormNote([FromBody] FormNoteDto formNoteDto)
        //{
        //    if (formNoteDto == null)
        //        return BadRequest("Form note data is null.");

        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var formNote = _mapper.Map<FormNote>(formNoteDto);

        //    if (!await _formNoteRepository.CreateFormNoteAsync(formNote))
        //        return StatusCode(500, "An error occurred while saving the form note.");

        //    var createdFormNoteDto = _mapper.Map<FormNoteDto>(formNote);

        //    return CreatedAtAction(
        //        "GetFormNote",
        //        new { formNoteId = createdFormNoteDto.FormNoteId },
        //        createdFormNoteDto
        //    );
        //}

    }
}
