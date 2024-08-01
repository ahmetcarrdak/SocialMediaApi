using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMediaApi.Models;

namespace SocialMediaApi.Interfaces;

public interface IUserService
{
    Task<User> GetUserByIdAsync(int id);
    Task<User> GetUserByUsernameAsync(string username);
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> CreateUserAsync(User user);
    Task<User> UpdateUserAsync(User user);
    Task DeleteUserAsync(int id);
}