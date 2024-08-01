using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialMediaApi.Models;
using SocialMediaApi.Data;
using SocialMediaApi.Interfaces;

namespace SocialMediaApi.Services
{
    public class FriendService : IFriendService
    {
        private readonly ApplicationDbContext _context;

        public FriendService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Friend>> GetFriendsAsync(int userId)
        {
            return await _context.Friends
                .Where(f => f.UserId1 == userId || f.UserId2 == userId)
                .ToListAsync();
        }

        public async Task<bool> AddFriendAsync(int userId, int friendId)
        {
            // Kullanıcı ve arkadaş arasında zaten bir arkadaşlık varsa, ekleme yapılmaz
            var existingFriendship = await _context.Friends
                .Where(f => (f.UserId1 == userId && f.UserId2 == friendId) ||
                            (f.UserId1 == friendId && f.UserId2 == userId))
                .FirstOrDefaultAsync();

            if (existingFriendship != null)
            {
                return false; // Zaten arkadaşlar
            }

            var newFriendship = new Friend
            {
                UserId1 = userId,
                UserId2 = friendId
            };

            _context.Friends.Add(newFriendship);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveFriendAsync(int userId, int friendId)
        {
            // Kullanıcı ve arkadaş arasında mevcut bir arkadaşlık olup olmadığını kontrol et
            var existingFriendship = await _context.Friends
                .Where(f => (f.UserId1 == userId && f.UserId2 == friendId) ||
                            (f.UserId1 == friendId && f.UserId2 == userId))
                .FirstOrDefaultAsync();

            if (existingFriendship == null)
            {
                return false; // Arkadaşlık bulunamadı
            }

            _context.Friends.Remove(existingFriendship);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
