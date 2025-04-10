using BlogDemo.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogDemo.Models
{
    public class BlogPost : IAuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public List<BlogReaction> BlogReaction { get; set; }
        public List<Review> BlogReviews { get; set; }
        public int BlogLikes { get; set; }
        public int BlogDisLikes { get; set; }
        public User? User { get; set; }
        [ForeignKey("UserId")] 
        public int UserId { get; set; }
        public string? Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
