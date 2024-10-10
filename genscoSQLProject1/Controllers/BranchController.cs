using AutoMapper;
using genscoSQLProject1.Dto;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;
using Microsoft.AspNetCore.Mvc;

namespace genscoSQLProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : Controller
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;

        public BranchController(IBranchRepository branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }

        //--------------GET ALL BRANCHES----------------//
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Branch>))]

        public IActionResult GetBranches()
        {
            var branches = _mapper.Map<List<BranchDto>>(_branchRepository.GetAllBranches());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(branches);
        }

        //--------------GET BRANCH BY ID----------------//
        [HttpGet("{branchNumber}")]
        [ProducesResponseType(200, Type = typeof(Branch))]
        [ProducesResponseType(400)]

        public IActionResult GetBranch(int branchNumber) {
            if (!_branchRepository.BranchExists(branchNumber))
                return NotFound();

            var branch = _mapper.Map<BranchDto>(_branchRepository.GetBranch(branchNumber));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(branch);
        }

       //----------- CREATE BRANCH ------------//
       [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]

        public IActionResult CreateBranch([FromBody] BranchDto branchToCreate)
        {
            if (branchToCreate == null)
                return BadRequest(ModelState);

            var branch = _branchRepository.GetAllBranches().Where(b => b.BranchNumber == branchToCreate.BranchNumber).FirstOrDefault();

            if (branch != null)
            {
                ModelState.AddModelError("", $"Branch {branchToCreate.BranchNumber} already exists");
                return StatusCode(422, ModelState);
            }

            var branchModel = _mapper.Map<Branch>(branchToCreate);

            if (!_branchRepository.CreateBranch(branchModel))
            {
                ModelState.AddModelError("", $"Something went wrong saving {branchModel.BranchName}");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Created");

        }
    }
}
