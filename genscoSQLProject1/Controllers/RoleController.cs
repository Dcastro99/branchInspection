using AutoMapper;
using genscoSQLProject1.Dto;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;
using Microsoft.AspNetCore.Mvc;

namespace genscoSQLProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RoleController : Controller
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleController(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        //--------------GET ALL ROLES----------------//
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RoleModel>))]
        public IActionResult GetRoles()
        {
            var roles = _mapper.Map<List<RoleDto>>(_roleRepository.GetRoles());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(roles);
        }

        //--------------GET ROLE BY DESCRIPTION----------------//
        [HttpGet("{roleDescription}")]
        [ProducesResponseType(200, Type = typeof(RoleDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetRole(string roleDescription)
        {
            if (string.IsNullOrEmpty(roleDescription))
                return BadRequest("Role description cannot be empty.");

            // Fetch the role by the description
            var role = _roleRepository.GetRoles()
                .FirstOrDefault(r => r.Role.Trim().ToLower() == roleDescription.Trim().ToLower());

            // Check if the role exists
            if (role == null || !_roleRepository.RoleExists(role.RoleId))
                return NotFound($"Role with description '{roleDescription}' not found.");

            // Map the role to a DTO
            var roleMap = _mapper.Map<RoleDto>(role);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(roleMap);
        }


        //--------------CREATE ROLE----------------//

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(RoleModel))]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]

        public IActionResult CreateRole([FromBody] RoleDto roleToCreate)
        {
            if (roleToCreate == null)
                return BadRequest(ModelState);

            var role = _roleRepository.GetRoles()
                .Where(r => r.Role.Trim().ToLower() == roleToCreate.RoleDescription.Trim().ToLower())
                .FirstOrDefault();

            if (role != null)
            {
                ModelState.AddModelError("", $"Role {roleToCreate.RoleDescription} already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var roleMap = _mapper.Map<RoleModel>(roleToCreate);

            if (!_roleRepository.CreateRole(roleMap))
            {
                ModelState.AddModelError("", $"Something went wrong saving the role {roleMap.Role}");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Created");
        }
    }
}
