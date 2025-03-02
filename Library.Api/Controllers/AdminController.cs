using Library.Application.Interfaces;
using Library.Core;
using Library.Core.DTO;
using Library.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/admin")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IUserService userService, ILogger<AdminController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        // GET /api/admin/users
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        // GET /api/admin/users/{id}
        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST /api/admin/users
        [HttpPost("users")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUpdateUserDto _user)
        {
            if (_user == null)
            {
                _logger.LogError(LoggerEnums.LogMessage.Error.ToString() + " " + "Null Request");
                return BadRequest("User cannot be null.");
            }

            var user = new User
            {
                Name = _user.Name,
                Email = _user.Email,
                Id = _user.Id,
                PasswordHash = _user.PasswordHash,
                Role = _user.Role,
            };

            await _userService.AddAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // PUT /api/admin/users/{id}
        [HttpPut("users/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] CreateUpdateUserDto _user)
        {
            if (id != _user.Id)
            {
                return BadRequest();
            }

            var existingUser = await _userService.GetByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            var user = new User
            {
                Name = _user.Name,
                Email = _user.Email,
                Id = _user.Id,
                PasswordHash = _user.PasswordHash,
                Role = _user.Role,
            };

            await _userService.UpdateAsync(user);
            return NoContent();
        }

        // DELETE /api/admin/users/{id}
        [HttpDelete("users/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}
