
using AutoMapper;
using BlogDemo.Contexts;
using BlogDemo.DTOs.BlogPostDTOs;
using BlogDemo.DTOs.BlogReaction;
using BlogDemo.DTOs.BlogReactionDTOs;
using BlogDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogDemo.Services.BlogReactionServices
{
    public class BlogReactionServices : IBlogReactionServices
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public BlogReactionServices(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<BlogReaction> CreateBlogReaction(CreateBlogReactionDTO blogReactionDTO)
        {
            bool isLike = blogReactionDTO.BlogLike;
            bool isDislike = blogReactionDTO.BlogDisLike;

            if (isLike && isDislike)
            {
                throw new ArgumentException("A reaction can't be both Like and Dislike. Please choose one.");
            }

            if (!isLike && !isDislike)
            {
                throw new ArgumentException("A reaction must be either Like or Dislike. Both can't be false.");
            }

            // Map the incoming DTO to a BlogReaction entity
            var blogReaction = _mapper.Map<BlogReaction>(blogReactionDTO);

           
            // Fetch the blog post using the foreign key
            var blogPost = await _context.BlogPosts.FindAsync(blogReaction.BlogPostId);

            if (blogPost == null)
            {
                throw new Exception("Associated blog post not found.");
            }

            // Update like/dislike count
            if (isLike == true)
            {
                blogPost.BlogLikes += 1;
            }
            else if (isDislike == true)
            {
                blogPost.BlogDisLikes += 1;
            }

            // Add the reaction to the database
            _context.BlogReactions.Add(blogReaction);
            await _context.SaveChangesAsync();


            // Save the updated blog post
            await _context.SaveChangesAsync();

            return blogReaction;
        }

        public async Task<BlogReaction> DeleteBlogReaction(int id)
        {
            var blogReaction = await _context.BlogReactions
                .Where(bp => bp.Id == id)
                .FirstOrDefaultAsync();

            if (blogReaction == null) throw new KeyNotFoundException("Blog Reaction Not Found.");

            _context.BlogReactions.Remove(blogReaction);
            await _context.SaveChangesAsync();

            return blogReaction;
        }

        public async Task<List<BlogReaction>> GetBlogReactions()
        {
            var blogReactions = await _context.BlogReactions
                .OrderByDescending(br => br.UpdatedAt)  // Changed to BlogPostId
                .ToListAsync();

            return blogReactions;
        }

        public async Task<BlogReaction> GetBlogReaction(int id)
        {
            var blogReaction = await _context.BlogReactions
                .Where(bp => bp.Id == id)
                .FirstOrDefaultAsync();

            if (blogReaction == null)
                throw new KeyNotFoundException("Blog Post Not Found.");


            return blogReaction;
        }

        public async Task<BlogReaction> UpdateBlogReaction(UpdateBlogReactionDTO blogReactionDTO)
        {
            var blogReaction = await _context.BlogReactions
                .Where(bp => bp.Id == blogReactionDTO.Id)
                .FirstOrDefaultAsync();

            if (blogReaction == null) throw new KeyNotFoundException("Blog Reaction Not Found.");

            blogReaction = _mapper.Map(blogReactionDTO, blogReaction);

            _context.BlogReactions.Update(blogReaction);
            await _context.SaveChangesAsync();

            return blogReaction;
        }
    }
}
