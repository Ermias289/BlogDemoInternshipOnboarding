using BlogDemo.DTOs.ReviewDTOs;
using BlogDemo.Models;

namespace BlogDemo.Services.ReviewServices
{
    public interface IReviewService
    {
        Task<Review> AddReview(AddReviewDTO reviewDTO);
        Task<Review> DeleteReview(int id);
        Task<Review> GetReview(int id);
        Task<List<Review>> GetReviews();
        Task<Review> UpdateReview(UpdateReviewDTO updateReviewDTO);
    }
}