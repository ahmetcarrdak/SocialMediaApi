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
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpGet("{postId}/likes")]
        public async Task<ActionResult<IEnumerable<Like>>> GetLikes(int postId)
        {
            var likes = await _likeService.GetLikesByPostIdAsync(postId);
            if (likes == null)
            {
                return NotFound();
            }
            return Ok(likes);
        }

        [HttpPost("{postId}/like")]
        public async Task<IActionResult> LikePost(int postId, [FromBody] int userId)
        {
            var result = await _likeService.AddLikeAsync(postId, userId);
            if (!result)
            {
                return BadRequest("Unable to like post.");
            }
            return Ok("Post liked successfully.");
        }

        [HttpDelete("{postId}/unlike/{userId}")]
        public async Task<IActionResult> UnlikePost(int postId, int userId)
        {
            var result = await _likeService.RemoveLikeAsync(postId, userId);
            if (!result)
            {
                return BadRequest("Unable to unlike post.");
            }
            return Ok("Post unliked successfully.");
        }
    }
}