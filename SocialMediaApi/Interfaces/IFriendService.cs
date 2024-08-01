using SocialMediaApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMediaApi.Interfaces
{
    public interface IFriendService
    {
        Task<IEnumerable<Friend>> GetFriendsAsync(int userId);
        Task<bool> AddFriendAsync(int userId, int friendId);
        Task<bool> RemoveFriendAsync(int userId, int friendId);
    }
}