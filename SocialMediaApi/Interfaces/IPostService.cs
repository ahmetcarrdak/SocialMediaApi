using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMediaApi.Models;

namespace SocialMediaApi.Interfaces;

public interface IPostService
{
    Task<Post> GetPostByIdAsync(int id);
    Task<IEnumerable<Post>> GetAllPostsAsync();
    Task<IEnumerable<Post>> GetPostsByUserIdAsync(int userId);
    Task<Post> CreatePostAsync(Post post);
    Task<Post> UpdatePostAsync(Post post);
    Task DeletePostAsync(int id);
}