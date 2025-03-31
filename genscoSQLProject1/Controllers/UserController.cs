using AutoMapper;
using genscoSQLProject1.Dto;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;
using genscoSQLProject1.Repository;
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
        private readonly IBranchRepository _branchRepository;
        private readonly ILogger<UserController> _logger;


        public UserController(
            IUserRepository userRepository, 
            IMapper mapper,
            IBranchRepository branchRepository,
            ILogger<UserController> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _branchRepository = branchRepository;
            _logger = logger;
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
        [ProducesResponseType(200, Type = typeof(UserWithBranchDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetUserByEmpNum(int empNum)
        {
            var user = _userRepository.GetUserByEmpNum(empNum);

            if (user == null)
            {
                return NotFound($"User with Employee Number {empNum} not found.");
            }

            var userDto = _mapper.Map<UserDto>(user);

            Console.WriteLine($"Default_branch: {userDto.Default_branch}");

            BranchDto? branchDto = null;
            if (!string.IsNullOrEmpty(userDto.Default_branch) && int.TryParse(userDto.Default_branch, out int branchNumber))
            {
                if (await _branchRepository.BranchExistsAsync(branchNumber))
                {
                    var branch = await _branchRepository.GetBranchAsync(branchNumber);
                    branchDto = _mapper.Map<BranchDto>(branch);
                }
            }

            var response = new UserWithBranchDto
            {
                User = userDto,
                Branch = branchDto
            };

            return Ok(response);
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
                .Where(u => u.Contact_id == userToCreate.User.Contact_id)
                .FirstOrDefault();

            if (existingUser != null)
            {
                ModelState.AddModelError("", $"A User with employee number {userToCreate.User.Contact_id} already exists");
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

            var hashedPassword = HashPassword(loginDto.Password);

            var user = _userRepository.GetUserByEmailAndPassword(loginDto.Email, hashedPassword);

            if (user == null)
            {
                return Unauthorized("Email or password is incorrect");
            }

            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpPost("loginWithBranch")]
        [ProducesResponseType(200, Type = typeof(LoginWithBranchResponseDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> LoginWithBranch([FromBody] LoginDto loginDto)
        {
            if (loginDto == null || string.IsNullOrWhiteSpace(loginDto.Email) || string.IsNullOrWhiteSpace(loginDto.Password))
            {
                return BadRequest("Invalid login credentials");
            }

            var hashedPassword = HashPassword(loginDto.Password);

            var user = _userRepository.GetUserByEmailAndPassword(loginDto.Email, hashedPassword);
            if (user == null)
            {
                return Unauthorized("Email or password is incorrect");
            }

            var userDto = _mapper.Map<UserDto>(user);

            if (string.IsNullOrEmpty(userDto.Default_branch) || !int.TryParse(userDto.Default_branch, out int branchNumber))
            {
                return BadRequest("DefaultLocationId is invalid or missing for the user.");
            }

            if (!await _branchRepository.BranchExistsAsync(branchNumber))
            {
                return NotFound($"Branch with number {branchNumber} does not exist.");
            }

            var branch = _mapper.Map<BranchDto>(await _branchRepository.GetBranchAsync(branchNumber));

            var response = new LoginWithBranchResponseDto
            {
                User = userDto,
                Branch = branch
            };

            return Ok(response);
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
