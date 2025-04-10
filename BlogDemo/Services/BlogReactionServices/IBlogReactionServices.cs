using BlogDemo.DTOs.BlogReaction;
using BlogDemo.DTOs.BlogReactionDTOs;
using BlogDemo.Models;

namespace BlogDemo.Services.BlogReactionServices
{
    public interface IBlogReactionServices
    {
        Task<List<BlogReaction>> GetBlogReactions();
        Task<BlogReaction> GetBlogReaction(int id);
        Task<BlogReaction> CreateBlogReaction(CreateBlogReactionDTO blogReactionDTO);
        Task<BlogReaction> UpdateBlogReaction(UpdateBlogReactionDTO blogReactionDTO);
        Task<BlogReaction> DeleteBlogReaction(int id);
    }
}
