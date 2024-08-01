using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApi.Models;
using SocialMediaApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMediaApi.Interfaces;

namespace SocialMediaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Tüm endpoint'ler için yetkilendirme gerekli
    public class FriendController : ControllerBase
    {
        private readonly IFriendService _friendService;

        public FriendController(IFriendService friendService)
        {
            _friendService = friendService;
        }

        [HttpGet("{userId}/friends")]
        public async Task<ActionResult<IEnumerable<Friend>>> GetFriends(int userId)
        {
            var friends = await _friendService.GetFriendsAsync(userId);
            if (friends == null)
            {
                return NotFound();
            }
            return Ok(friends);
        }

        [HttpPost("{userId}/add")]
        public async Task<IActionResult> AddFriend(int userId, [FromBody] int friendId)
        {
            var result = await _friendService.AddFriendAsync(userId, friendId);
            if (!result)
            {
                return BadRequest("Unable to add friend.");
            }
            return Ok("Friend added successfully.");
        }

        [HttpDelete("{userId}/remove/{friendId}")]
        public async Task<IActionResult> RemoveFriend(int userId, int friendId)
        {
            var result = await _friendService.RemoveFriendAsync(userId, friendId);
            if (!result)
            {
                return BadRequest("Unable to remove friend.");
            }
            return Ok("Friend removed successfully.");
        }
    }
}