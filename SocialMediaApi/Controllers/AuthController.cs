using Microsoft.AspNetCore.Mvc;
using SocialMediaApi.Models;
using SocialMediaApi.Services;
using System.Threading.Tasks;
using SocialMediaApi.Interfaces;
using SocialMediaApi.DTOs;

namespace SocialMediaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthController(IUserService userService, IJwtService jwtService, IPasswordHasher passwordHasher)
        {
            _userService = userService;
            _jwtService = jwtService;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            var user = await _userService.GetUserByUsernameAsync(loginDto.Username);
            if (user == null || !_passwordHasher.VerifyHashedPassword(user.PasswordHash, loginDto.Password))
            {
                return Unauthorized("Invalid username or password.");
            }

            var token = _jwtService.GenerateToken(user);
            return Ok(new { Token = token });
        }
    }
}