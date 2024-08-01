using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaApi.Models
{
    public class Friend
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId1 { get; set; }

        [Required]
        public int UserId2 { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        [ForeignKey("UserId1")]
        public virtual User User1 { get; set; }

        [ForeignKey("UserId2")]
        public virtual User User2 { get; set; }
    }
}