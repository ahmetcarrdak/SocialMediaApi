using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialMediaApi.Models;
using SocialMediaApi.Data;
using SocialMediaApi.Interfaces;

namespace SocialMediaApi.Services
{
    public class LikeService : ILikeService
    {
        private readonly ApplicationDbContext _context;

        public LikeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Like>> GetLikesByPostIdAsync(int postId)
        {
            return await _context.Likes.Where(l => l.PostId == postId).ToListAsync();
        }

        public async Task<bool> AddLikeAsync(int postId, int userId)
        {
            // Posta zaten beğeni yapılmış mı kontrol et
            var existingLike = await _context.Likes
                .Where(l => l.PostId == postId && l.UserId == userId)
                .FirstOrDefaultAsync();

            if (existingLike != null)
            {
                return false; // Zaten beğenilmiş
            }

            var newLike = new Like
            {
                PostId = postId,
                UserId = userId
            };

            _context.Likes.Add(newLike);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveLikeAsync(int postId, int userId)
        {
            // Posta yapılmış beğeniyi bul
            var existingLike = await _context.Likes
                .Where(l => l.PostId == postId && l.UserId == userId)
                .FirstOrDefaultAsync();

            if (existingLike == null)
            {
                return false; // Beğeni bulunamadı
            }

            _context.Likes.Remove(existingLike);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}