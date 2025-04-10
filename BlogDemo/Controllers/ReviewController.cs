using BlogDemo.DTOs.BlogPostDTOs;
using BlogDemo.DTOs.ReviewDTOs;
using BlogDemo.Services.ReviewServices;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Controllers
{
    [Route("api/Controller")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // CREATE BLOG POST
        [HttpPost]
        public async Task<ActionResult> AddReview(AddReviewDTO reviewDTO)
        {
            try
            {
                return Ok(await _reviewService.AddReview(reviewDTO));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }

        // DELETE BLOG POST
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReview(int id)
        {
            try
            {
                return Ok(await _reviewService.DeleteReview(id));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }

        // GET ALL BLOG POSTS
        [HttpGet]
        public async Task<ActionResult> GetReviews()
        {
            try
            {
                return Ok(await _reviewService.GetReviews());
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }

        // GET SINGLE BLOG POST
        [HttpGet("{id}")]
        public async Task<ActionResult> GetReview(int id)
        {
            try
            {
                return Ok(await _reviewService.GetReview(id));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }

        // UPDATE BLOG POST
        [HttpPut]
        public async Task<ActionResult> UpdateReview(UpdateReviewDTO reviewService)
        {
            try
            {
                return Ok(await _reviewService.UpdateReview(reviewService));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }
    }
}
