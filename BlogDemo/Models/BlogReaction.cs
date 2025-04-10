using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlogDemo.Models
{
    public class BlogReaction
    {
        [Key]
        public int Id { get; set; }
        public bool BlogLike { get; set; } 
        public bool BlogDisLike { get; set; } 
        [JsonIgnore]
        public BlogPost BlogPost { get; set; }
        public int BlogPostId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
