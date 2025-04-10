using BlogDemo.Models;

namespace BlogDemo.Services.BlogPostServices
{
    internal class ReturnBlogDTO : BlogPost
    {
        public string Author { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int BlogLikes { get; set; }
        public int BlogDisLikes { get; set; }
    }
}