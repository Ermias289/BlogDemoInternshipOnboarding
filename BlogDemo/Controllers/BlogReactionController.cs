using BlogDemo.Services.BlogReactionServices;
using Microsoft.AspNetCore.Mvc;
using BlogDemo.DTOs.BlogReaction;
using Microsoft.AspNetCore.Http;
using BlogDemo.DTOs.BlogReactionDTOs;


namespace BlogDemo.Controllers.BlogReactionController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogReactionController : Controller
    {

        private readonly IBlogReactionServices _blogReaction;
        public BlogReactionController(IBlogReactionServices blogReaction)
        {
            _blogReaction = blogReaction;
        }

        // CREATE BLOG LIKE POST
        [HttpPost]
        public async Task<ActionResult> CreateBlogReaction(CreateBlogReactionDTO blogReactionDTO)
        {
            try
            {
                return Ok(await _blogReaction.CreateBlogReaction(blogReactionDTO));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }

        // GET ALL BLOG POSTS
        [HttpGet]
        public async Task<ActionResult> GetBlogReactions()
        {
            try
            {
                return Ok(await _blogReaction.GetBlogReactions());
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }

        // GET SINGLE BLOG POST
        [HttpGet("{Id}")]
        public async Task<ActionResult> GetBlogReaction(int blogPostId)
        {
            try
            {
                return Ok(await _blogReaction.GetBlogReaction(blogPostId));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }

        // DELETE BLOG LIKE POST
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteBlogReaction(int id)
        {
            try
            {
                return Ok(await _blogReaction.DeleteBlogReaction(id));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }
        // UPDATE BLOG LIKE 
        [HttpPut]
        public async Task<ActionResult> UpdateBlogReaction(UpdateBlogReactionDTO blogReactionDTO)
        {
            try
            {
                return Ok(await _blogReaction.UpdateBlogReaction(blogReactionDTO));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }
    }
}
