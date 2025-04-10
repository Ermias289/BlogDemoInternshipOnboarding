using BlogDemo.DTOs.BlogPostDTOs;
using BlogDemo.DTOs.UserDTOs;
using BlogDemo.Models;
using BlogDemo.Services.BlogPostServices;
using BlogDemo.Services.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        //Add user
        [HttpPost]
        public async Task<ActionResult> AddUser(AddUserDTOs userDTO)
        {
            try
            {
                return Ok(await _userServices.AddUser(userDTO));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }
       
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(int id)
        {
            try
            {
                return Ok(await _userServices.GetUser(id));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }
        //Get all users
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                return Ok(await _userServices.GetUsers());
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id, string password)
        {
            try
            {
                return Ok(await _userServices.DeleteUser(id, password));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }
        //update a specific user
        [HttpPut]
        public async Task<ActionResult> UpdateUser(UpdateUserDTO userDTO)
        {
            try
            {
                return Ok(await _userServices.UpdateUser(userDTO));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }

    }
}
