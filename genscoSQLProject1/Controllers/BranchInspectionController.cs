using AutoMapper;
using genscoSQLProject1.Dto;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace genscoSQLProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchInspectionController: Controller
    {
        private readonly IBranchInspectionRepository _branchInspectionRepository;
        private readonly IMapper _mapper;

        public BranchInspectionController(IBranchInspectionRepository branchInspectionListRepository, IMapper mapper)
        {
            _branchInspectionRepository = branchInspectionListRepository;
            _mapper = mapper;
        }

        //--------------GET ALL BRANCH INSPECTIONS----------------//
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BranchInspection>))]

        public IActionResult GetBranchInspections()
        {
            var branchInspections = _mapper.Map<List<BranchInspectionDto>>(_branchInspectionRepository.GetAllBranchInspections());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(branchInspections);
        }

        //--------------GET BRANCH INSPECTION BY ID----------------//

        [HttpGet("{branchInspectionId}")]
        [ProducesResponseType(200, Type = typeof(BranchInspection))]
        [ProducesResponseType(400)]

        public IActionResult GetBranchInspection(int branchInspectionId)
        {
            if (!_branchInspectionRepository.BranchInspectionExists(branchInspectionId))
                return NotFound();

            var branchInspection = _mapper.Map<BranchInspectionDto>(_branchInspectionRepository.GetBranchInspection(branchInspectionId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(branchInspection);
        }

        //--------------CREATE BRANCH INSPECTION----------------//

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(BranchInspection))]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public IActionResult CreateBranchInspection([FromBody] BranchInspectionDto branchInspectionToCreate)
        {
            if (branchInspectionToCreate == null)
                return BadRequest(ModelState);

            DateTime currentMonth = DateTime.Now;
            var branchId = branchInspectionToCreate.BranchId;

            // Check if an inspection for the current month already exists for the given branch
            var existingInspection = _branchInspectionRepository.GetAllBranchInspections()
                .Where(bi => bi.BranchId == branchId
                            && bi.SubmittedDate.HasValue
                            && bi.SubmittedDate.Value.Year == currentMonth.Year
                            && bi.SubmittedDate.Value.Month == currentMonth.Month
                            && bi.DeleteFlag == "N")
                .OrderByDescending(bi => bi.SubmittedDate)
                .FirstOrDefault();

            if (existingInspection != null)
            {
                // If an inspection for this month already exists, return a conflict status code with an error message
                ModelState.AddModelError("", $"Branch Inspection already exists for this month.");
                return StatusCode(422, ModelState);
            }

            // Ensure model state is valid before proceeding
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Map the DTO to the BranchInspection entity
            var branchInspection = _mapper.Map<BranchInspection>(branchInspectionToCreate);

            // Attempt to create the branch inspection in the repository
            if (!_branchInspectionRepository.CreateBranchInspection(branchInspection))
            {
                ModelState.AddModelError("", $"Something went wrong saving the branch inspection {branchInspection.BranchInspectionId}");
                return StatusCode(500, ModelState);
            }

            
            return Ok("Successfully Created");
        }



    }
}
