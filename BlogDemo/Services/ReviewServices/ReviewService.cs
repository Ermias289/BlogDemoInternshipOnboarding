using AutoMapper;
using BlogDemo.Contexts;
using BlogDemo.DTOs.ReviewDTOs;
using BlogDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlogDemo.Services.ReviewServices
{
    public class ReviewService : IReviewService
    {
        public readonly DataContext _context;
        public readonly IMapper _mapper;

        public ReviewService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Review> AddReview(AddReviewDTO reviewDTO)
        {
            var review = _mapper.Map<Review>(reviewDTO);

            var blogPostExists = await _context.BlogPosts.AnyAsync(b => b.Id == reviewDTO.BlogPostId);
            if (!blogPostExists)
            {
                throw new KeyNotFoundException($"Blog post with ID {reviewDTO.BlogPostId} not found.");
            }

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();


            return review;
        }

        public async Task<Review> DeleteReview(int id)
        {
            var review = await _context.Reviews
                .Where(bp => bp.Id == id)
                .FirstOrDefaultAsync();

            if (review == null) throw new KeyNotFoundException("Review Not Found");
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<Review> GetReview(int id)
        {
            var review = await _context.Reviews
                        .Where(bp => bp.Id == id)
                        .FirstOrDefaultAsync();
            if (review == null) throw new KeyNotFoundException("Couldn't find Review");
            return review;
        }
        public async Task<List<Review>> GetReviews()
        {
            var reviews = await _context.Reviews.
                               OrderByDescending(bp => bp.UpdatedAt)
                               .ToListAsync();
            if (reviews == null) throw new KeyNotFoundException("Couldn't Find Records");
            return reviews;
        }

        public async Task<Review> UpdateReview(UpdateReviewDTO updateReviewDTO)
        {
            var review = await _context.Reviews.Where(bp => bp.Id == updateReviewDTO.Id).FirstOrDefaultAsync();
            if (review == null) throw new KeyNotFoundException("Review to be updated not found!");
            review = _mapper.Map(updateReviewDTO, review);
            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();
            return review;

        }

    }
}
