using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMediaApi.Models;
using SocialMediaApi.Services;
using SocialMediaApi.Interfaces;
using SocialMediaApi.DTOs;

namespace SocialMediaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Bu kontrolöre erişim için yetkilendirme gerekli
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult<User>> CreateUser([FromBody] UserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("User data is required.");
            }

            // Şifre hash'leme işlemi
            var user = new User
            {
                Username = userDto.Username,
                Email = userDto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password),
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                ProfilePictureUrl = userDto.ProfilePictureUrl,
                CreatedAt = DateTime.UtcNow, // Veritabanı tarafından otomatik olarak atanacak
                UpdatedAt = DateTime.UtcNow  // Veritabanı tarafından otomatik olarak atanacak
            };

            var createdUser = await _userService.CreateUserAsync(user);
            if (createdUser == null)
            {
                return StatusCode(500, "A problem occurred while handling your request.");
            }

            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}