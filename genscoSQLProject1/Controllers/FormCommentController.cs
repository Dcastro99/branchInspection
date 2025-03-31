using AutoMapper;
using genscoSQLProject1.Dto;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;
using Microsoft.AspNetCore.Mvc;


namespace genscoSQLProject1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FormCommentController: Controller
    {
        private readonly IFormCommentRepository _formCommentRepository;
        private readonly IBranchInspectionRepository _branchInspectionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<FormCommentController> _logger;

        public FormCommentController(IFormCommentRepository formCommentRepository, IBranchInspectionRepository branchInspectionRepository, IMapper mapper, ILogger<FormCommentController> logger)
        {
            _formCommentRepository = formCommentRepository;
            _branchInspectionRepository = branchInspectionRepository;
            _mapper = mapper;
            _logger = logger;
        }

        //-----------------GET ALL FORM COMMENTS-----------------//
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<FormCommentDto>))]
        public async Task<IActionResult> GetAllFormComments()
        {
           var comments = _mapper.Map<IEnumerable<FormCommentDto>>(await _formCommentRepository.GetAllFormCommentsAsync());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(comments);
        }

        //-----------------GET FORM COMMENT BY ID-----------------//

        [HttpGet("{formCommentId}")]
        [ProducesResponseType(200, Type = typeof(FormCommentDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetFormCommentById(int formCommentId)
        {
            if(!await _formCommentRepository.FormCommentExistsAsync(formCommentId))
                return NotFound();

            var comment = _mapper.Map<FormCommentDto>(await _formCommentRepository.GetFormCommentByIdAsync(formCommentId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if (comment == null)
                return NotFound();

            return Ok(comment);
        }

        //-----------------GET FORM COMMENTS BY BRANCH INSPECTION ID-----------------//

        [HttpGet("branchInspectionFormComment/{branchInspectionId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<FormCommentDto>))]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetFormCommentsByBranchInspectionId(int branchInspectionId)
        {
            if (!await _branchInspectionRepository.BranchInspectionExistsAsync(branchInspectionId))
                return NotFound();

            var comments = _mapper.Map<IEnumerable<FormCommentDto>>(await _formCommentRepository.GetFormCommentsByBranchInspectionIdAsync(branchInspectionId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(comments);
        }

        //-----------------CREATE FORM COMMENT-----------------//

        [HttpPost("addFormComments")]
        [ProducesResponseType(201, Type = typeof(FormCommentDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> CreateFormComment([FromBody] FormCommentDto formCommentDto)
        {
            if (formCommentDto == null)
                return BadRequest(ModelState);

            if (!await _branchInspectionRepository.BranchInspectionExistsAsync(formCommentDto.BranchInspectionId))
                return NotFound();

            var formComment = _mapper.Map<FormComment>(formCommentDto);

            if (!await _formCommentRepository.CreateFormCommentAsync(formComment))
            {
                _logger.LogError($"Something went wrong when saving the comment {formComment.Comment} to the database.");
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return CreatedAtAction("GetFormCommentById", new { formCommentId = formComment.FormCommentId }, formComment);
        }

        //-----------------UPDATE FORM COMMENT-----------------//

        [HttpPost("upsertFormComments")]
        [ProducesResponseType(201, Type = typeof(IEnumerable<FormCommentDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpsertFormComments([FromBody] List<FormCommentDto> formCommentDtos)
        {
            if (formCommentDtos == null || formCommentDtos.Count == 0)
            {
                _logger.LogWarning("Form comment data is null or empty.");
                return BadRequest("Form comment data is null or empty.");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("ModelState is not valid.");
                return BadRequest(ModelState);
            }

            _logger.LogInformation("Received FormCommentDto list:");
            foreach (var comment in formCommentDtos)
            {
                _logger.LogInformation($"BranchInspectionId: {comment.BranchInspectionId}, CategoryId: {comment.CategoryId}, Comment: {comment.Comment}");
            }

            var formComments = _mapper.Map<List<FormComment>>(formCommentDtos);

            foreach (var formComment in formComments)
            {
                _logger.LogInformation($"Processing FormComment: BranchInspectionId: {formComment.BranchInspectionId}, CategoryId: {formComment.CategoryId}, Comment: {formComment.Comment}");

                var existingFormComment = await _formCommentRepository.GetFormCommentByBranchInspectionAndCategoryAsync(
                    formComment.BranchInspectionId, formComment.CategoryId);

                if (existingFormComment != null)
                {
                    _logger.LogInformation("Form comment found. Checking for changes...");

                    bool commentChanged = existingFormComment.Comment != formComment.Comment;

                    if (commentChanged)
                    {
                        _logger.LogInformation("Change detected. Updating FormComment...");
                        existingFormComment.Comment = formComment.Comment;

                        var updateSuccess = await _formCommentRepository.UpdateFormCommentAsync(existingFormComment);
                        if (!updateSuccess)
                        {
                            _logger.LogError("An error occurred while updating a form comment.");
                            return StatusCode(500, "An error occurred while updating a form comment.");
                        }
                    }
                    else
                    {
                        _logger.LogInformation("No changes detected. Skipping update.");
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(formComment.Comment))
                    {
                        _logger.LogInformation("Comment is empty. Skipping creation.");
                        continue;
                    }

                   

                    var createSuccess = await _formCommentRepository.CreateFormCommentAsync(formComment);
                    if (!createSuccess)
                    {
                        _logger.LogError("An error occurred while creating a form comment.");
                        return StatusCode(500, "An error occurred while creating a form comment.");
                    }
                }
            }

            var upsertedFormCommentDtos = _mapper.Map<List<FormCommentDto>>(formComments);
            _logger.LogInformation("Form comments upserted successfully. Returning response...");

            return CreatedAtAction(nameof(GetFormCommentsByBranchInspectionId),
                new { branchInspectionId = formComments[0].BranchInspectionId }, upsertedFormCommentDtos);
        }


    }
}
