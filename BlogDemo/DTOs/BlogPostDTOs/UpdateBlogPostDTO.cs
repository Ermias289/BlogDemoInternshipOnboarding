namespace BlogDemo.DTOs.BlogPostDTOs
{
    public class UpdateBlogPostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
    }
}
