using AutoMapper;
using genscoSQLProject1.Dto;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;
using Microsoft.AspNetCore.Mvc;

namespace genscoSQLProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController: Controller
    {
        private readonly ICommentsRepository _commentsRepository;
        private readonly IMapper _mapper;

        public CommentsController(ICommentsRepository commentsRepository, IMapper mapper)
        {
            _commentsRepository = commentsRepository;
            _mapper = mapper;
        }

        //--------------GET ALL COMMENTS----------------//
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Comments>))]

        public IActionResult GetComments()
        {
            var comments = _mapper.Map<List<CommentsDto>>(_commentsRepository.GetAllComments());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(comments);
        }

        //--------------GET COMMENT BY ID----------------//
        [HttpGet("{commentId}")]
        [ProducesResponseType(200, Type = typeof(CommentsDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult GetComments(int commentId) {

            if (commentId <= 0)
            {
                return BadRequest("Invalid comment ID.");
            }

            if (!_commentsRepository.CommentExists(commentId))
                return NotFound();

            var comment = _mapper.Map<CommentsDto>(_commentsRepository.GetComment(commentId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(comment);
        }

   

        //--------------GET COMMENT BY CATEGORY----------------//
        [HttpGet("category/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CommentsDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetCommentsByCategory(int categoryId)
        {
            // Validate categoryId
            if (categoryId <= 0)
            {
                return BadRequest("Invalid category ID.");
            }

            // Get comments by categoryId
            var comments = _commentsRepository.GetCommentByCategory(categoryId);

            // Handle if no comments are found
            if (comments == null || !comments.Any())
            {
                return NotFound($"No comments found for category ID {categoryId}.");
            }

            // Map to DTOs
            var commentsDto = _mapper.Map<List<CommentsDto>>(comments);

            // Validate ModelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(commentsDto);
        }

        //--------------CREATE COMMENT----------------//

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Comments))]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)] 
        [ProducesResponseType(500)]
        public IActionResult CreateComment([FromBody] CommentsDto commentToCreate)
        {
            if (commentToCreate == null)
                return BadRequest(ModelState);

            // Check if a comment already exists for the given CategoryId
            var existingComment = _commentsRepository.GetAllComments()
                .Any(c => c.CategoryId == commentToCreate.CategoryId);

            if (existingComment)
            {
                ModelState.AddModelError("", $"A comment for category {commentToCreate.CategoryId} already exists.");
                return StatusCode(409, ModelState); // Return 409 Conflict
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

           
            var commentMap = _mapper.Map<Comments>(commentToCreate);

            if (!_commentsRepository.CreateComment(commentMap))
            {
                ModelState.AddModelError("", $"Something went wrong saving the comment for category {commentToCreate.CategoryId}.");
                return StatusCode(500, ModelState);
            }

            
            return Ok("Successfully created.");
        }


    }
}
