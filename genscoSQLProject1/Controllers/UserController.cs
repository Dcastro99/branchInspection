using AutoMapper;
using genscoSQLProject1.Dto;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography;
using System.Text;

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
        //--------------GET USER BY EMPLOYEE NUMBER----------------//
        [HttpGet("byEmpNum/{empNum}")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetUserByEmpNum(int empNum)
        {
            var user = _userRepository.GetUserByEmpNum(empNum);

            if (user == null)
            {
                return NotFound($"User with Employee Number {empNum} not found.");
            }

            var userDto = _mapper.Map<UserDto>(user);

            return Ok(userDto);
        }

        //--------------GET USER BY EMPLOYEE ID----------------//
        [HttpGet("byEmpId/{empId}")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetUserById(int empId)
        {
            var user = _userRepository.GetUserById(empId);

            if (user == null)
            {
                return NotFound($"User with Employee ID {empId} not found.");
            }

            var userDto = _mapper.Map<UserDto>(user);

            return Ok(userDto);
        }


        //--------------CREATE USER----------------//


        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult PostUser([FromBody] UserLoginDto userToCreate)
        {
            if (userToCreate == null)
                return BadRequest(ModelState);

            var existingUser = _userRepository.GetAllUsers()
                .Where(u => u.EmployeeId == userToCreate.User.EmployeeId)
                .FirstOrDefault();

            if (existingUser != null)
            {
                ModelState.AddModelError("", $"A User with employee number {userToCreate.User.EmployeeId} already exists");
                return StatusCode(400, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

           
            var hashedPassword = HashPassword(userToCreate.Login.Password);

            
            var userMap = _mapper.Map<User>(userToCreate.User);
            userMap.Password = hashedPassword; 

            if (!_userRepository.CreateUser(userMap))
            {
                ModelState.AddModelError("", $"Something went wrong saving the user {userMap.FirstName} {userMap.LastName}");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Created");
        }


        //--------------- GET USER BY EMAIL AND PASSWORD --------------//


        [HttpPost("login")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        [ProducesResponseType(400)]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            if (loginDto == null || string.IsNullOrWhiteSpace(loginDto.Email) || string.IsNullOrWhiteSpace(loginDto.Password))
            {
                return BadRequest("Invalid login credentials");
            }

            // Hash the incoming password for comparison
            var hashedPassword = HashPassword(loginDto.Password);

            var user = _userRepository.GetUserByEmailAndPassword(loginDto.Email, hashedPassword);

            if (user == null)
            {
                return Unauthorized("Email or password is incorrect");
            }

            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }





        //------------- Method to hash password --------------//
        private string HashPassword(string password)
        {
           
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

    }
}
