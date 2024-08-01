using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMediaApi.Models;

namespace SocialMediaApi.Interfaces;

public interface ICommentService
{
    Task<Comment> GetCommentByIdAsync(int id);
    Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int postId);
    Task<Comment> CreateCommentAsync(Comment comment);
    Task<Comment> UpdateCommentAsync(Comment comment);
    Task DeleteCommentAsync(int id);
}