using Microsoft.EntityFrameworkCore;
using SocialMediaApi.Models;

namespace SocialMediaApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Friend> Friends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Friend-User relationships
            modelBuilder.Entity<Friend>()
                .HasOne(f => f.User1)
                .WithMany(u => u.Friends1)
                .HasForeignKey(f => f.UserId1)
                .OnDelete(DeleteBehavior.Restrict); // Adjust as needed

            modelBuilder.Entity<Friend>()
                .HasOne(f => f.User2)
                .WithMany(u => u.Friends2)
                .HasForeignKey(f => f.UserId2)
                .OnDelete(DeleteBehavior.Restrict); // Adjust as needed

            // Configure unique index for UserId1 and UserId2 combination
            modelBuilder.Entity<Friend>()
                .HasIndex(f => new { f.UserId1, f.UserId2 })
                .IsUnique();
        }
    }
}