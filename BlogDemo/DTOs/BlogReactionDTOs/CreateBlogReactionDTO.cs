using BlogDemo.Models;
using System.Text.Json.Serialization;

namespace BlogDemo.DTOs.BlogReactionDTOs
{
    public class CreateBlogReactionDTO
    {
        public int BlogPostId { get; set; }
        public bool BlogLike { get; set; } 
        public bool BlogDisLike { get; set; }
    }
}
