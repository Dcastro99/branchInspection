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
        private readonly ILogger<FormNoteController> _logger;
        public FormNoteController(IFormNoteRepository formNoteRepository, IMapper mapper, ILogger<FormNoteController> logger)
        {
            _formNoteRepository = formNoteRepository;
            _mapper = mapper;
            _logger = logger;
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

            var formNote = _mapper.Map<FormNoteDto>(await _formNoteRepository.GetFormNoteByIdAsync(formNoteId));

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

        //--------------UPDATE FORM NOTE----------------//

        [HttpPut("updateFormNote/{id}")]
        [ProducesResponseType(200, Type = typeof(FormNoteDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateFormNote(int id, [FromBody] FormNoteDto formNoteDto)
        {
            // Check if the incoming data is valid
            if (formNoteDto == null)
                return BadRequest("Form note data is null.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Retrieve the existing form note from the database by ID
            var existingFormNote = await _formNoteRepository.GetFormNoteByIdAsync(id);
            if (existingFormNote == null)
                return NotFound($"Form note with ID {id} not found.");

            // Map the updates from the formNoteDto to the existing form note
            _mapper.Map(formNoteDto, existingFormNote);

            // Optionally, set the 'CreatedAt' value to ensure it doesn't change on update
            existingFormNote.CreatedAt = existingFormNote.CreatedAt;

            // Update the record in the database
            var success = await _formNoteRepository.UpdateFormNoteAsync(existingFormNote);
            if (!success)
                return StatusCode(500, "An error occurred while updating the form note.");

            // Return the updated form note
            var updatedFormNoteDto = _mapper.Map<FormNoteDto>(existingFormNote);
            return Ok(updatedFormNoteDto);
        }


        //--------------UPSERT FORM NOTES----------------//

        [HttpPost("upsertFormNotes")]
        [ProducesResponseType(201, Type = typeof(IEnumerable<FormNoteDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpsertFormNotes([FromBody] List<FormNoteDto> formNoteDtos)
        {
            if (formNoteDtos == null || formNoteDtos.Count == 0)
            {
                _logger.LogWarning("Form note data is null or empty.");
                return BadRequest("Form note data is null or empty.");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("ModelState is not valid.");
                return BadRequest(ModelState);
            }

            _logger.LogInformation("Received FormNoteDto list:");
            foreach (var note in formNoteDtos)
            {
                _logger.LogInformation($"BranchInspectionId: {note.BranchInspectionId}, CategoryId: {note.CategoryId}, SectionNote: {note.SectionNote}, GeneralNotes: {note.generalNotes}");
            }

            var formNotes = _mapper.Map<List<FormNote>>(formNoteDtos);

            foreach (var formNote in formNotes)
            {
                _logger.LogInformation($"Processing FormNote: BranchInspectionId: {formNote.BranchInspectionId}, CategoryId: {formNote.CategoryId}, SectionNote: {formNote.SectionNote}, GeneralNotes: {formNote.generalNotes}");

                var existingFormNote = await _formNoteRepository.GetFormNoteByBranchInspectionAndCategoryAsync(
                    formNote.BranchInspectionId, formNote.CategoryId);

                if (existingFormNote != null)
                {
                    _logger.LogInformation("Form note found. Checking for changes...");

                    bool sectionNoteChanged = existingFormNote.SectionNote != formNote.SectionNote;
                    bool generalNotesChanged = existingFormNote.generalNotes != formNote.generalNotes;

                    if (sectionNoteChanged || generalNotesChanged)
                    {
                        _logger.LogInformation("Changes detected. Updating FormNote...");
                        if (sectionNoteChanged)
                            existingFormNote.SectionNote = formNote.SectionNote;
                        if (generalNotesChanged)
                            existingFormNote.generalNotes = formNote.generalNotes;

                        var updateSuccess = await _formNoteRepository.UpdateFormNoteAsync(existingFormNote);
                        if (!updateSuccess)
                        {
                            _logger.LogError("An error occurred while updating a form note.");
                            return StatusCode(500, "An error occurred while updating a form note.");
                        }
                    }
                    else
                    {
                        _logger.LogInformation("No changes detected. Skipping update.");
                    }
                }
                else
                {
                    // Check if both SectionNote and generalNotes are empty
                    if (string.IsNullOrWhiteSpace(formNote.SectionNote) && string.IsNullOrWhiteSpace(formNote.generalNotes))
                    {
                        _logger.LogInformation("Both SectionNote and generalNotes are empty. Skipping creation.");
                        continue;
                    }

                    _logger.LogInformation("Form note not found. Creating a new one...");
                    formNote.CreatedAt = DateTime.UtcNow;

                    var createSuccess = await _formNoteRepository.CreateFormNoteAsync(formNote);
                    if (!createSuccess)
                    {
                        _logger.LogError("An error occurred while creating a form note.");
                        return StatusCode(500, "An error occurred while creating a form note.");
                    }
                }
            }

            var upsertedFormNoteDtos = _mapper.Map<List<FormNoteDto>>(formNotes);
            _logger.LogInformation("Form notes upserted successfully. Returning response...");

            return CreatedAtAction(nameof(GetFormNotesByBranchInspectionId),
                new { branchInspectionId = formNotes[0].BranchInspectionId }, upsertedFormNoteDtos);
        }





    }
}
