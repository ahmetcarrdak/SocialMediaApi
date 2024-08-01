using SocialMediaApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMediaApi.Interfaces
{
    public interface ILikeService
    {
        Task<IEnumerable<Like>> GetLikesByPostIdAsync(int postId);
        Task<bool> AddLikeAsync(int postId, int userId);
        Task<bool> RemoveLikeAsync(int postId, int userId);
    }
}