using AutoMapper;
using genscoSQLProject1.Dto;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;
using Microsoft.AspNetCore.Mvc;

namespace genscoSQLProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        //--------------GET ALL USERS----------------//
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult Index() {
            var users = _mapper.Map<List<UserDto>>(_userRepository.GetAllUsers());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(users);
        }

        //--------------GET USER BY ID----------------//
        [HttpGet("{empId}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetUser(int empId) {
            
            var user = _mapper.Map<UserDto>(_userRepository.GetUser(empId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);  

            return Ok(user);
        }

        //--------------CREATE USER----------------//
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]

        public IActionResult PostUser([FromBody] UserDto userToCreate)
        {
            if (userToCreate == null)
                return BadRequest(ModelState);

            var user = _userRepository.GetAllUsers()
                .Where(u => u.EmployeeId == userToCreate.EmployeeId)
                .FirstOrDefault();

            if (user != null)
            {
                ModelState.AddModelError("", $"User {userToCreate.FirstName} {userToCreate.LastName} with employee number {userToCreate.EmployeeId} already exists");
                return StatusCode(400, ModelState);
            }

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var userMap = _mapper.Map<User>(userToCreate);

            if (!_userRepository.CreateUser(userMap))
            {
                ModelState.AddModelError("", $"Something went wrong saving the user {user.FirstName} {user.LastName}");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Created");
        }
    }
}
