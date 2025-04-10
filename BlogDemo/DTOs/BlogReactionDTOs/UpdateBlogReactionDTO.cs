using BlogDemo.Models;

namespace BlogDemo.DTOs.BlogReaction
{
    public class UpdateBlogReactionDTO
    {
        public int Id { get; set; }
        public bool BlogLike { get; set; }
        public bool BlogDisLike { get; set; }
        public int BlogPost { get; set; }
    }
}

