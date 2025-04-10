using BlogDemo.DTOs.BlogPostDTOs;
using BlogDemo.Models;
using System.Globalization;

namespace BlogDemo.Services.BlogPostServices
{
    public interface IBlogPostService
    {
        Task<List<BlogPost>> GetBlogPosts(int userId);
        Task<BlogPost> GetBlogPost(int id);
        Task<BlogPost> DeleteBlogPost(int id);
        Task<BlogPost> CreateBlogPost(CreateBlogPostDTO blogPostDTO);
        Task<BlogPost> UpdateBlogPost(UpdateBlogPostDTO blogPostDTO);
  
        
    }
}
