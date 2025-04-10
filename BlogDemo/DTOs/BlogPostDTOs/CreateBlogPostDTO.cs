namespace BlogDemo.DTOs.BlogPostDTOs
{
    public class CreateBlogPostDTO
    {
        public int UserID { get; set; }
        public string Password { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
    }
}
