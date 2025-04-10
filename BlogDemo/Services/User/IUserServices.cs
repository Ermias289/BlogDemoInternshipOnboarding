using BlogDemo.DTOs.UserDTOs;
using BlogDemo.Models;

namespace BlogDemo.Services.UserServices
{
    public interface IUserServices
    {
        Task<User> AddUser(AddUserDTOs userDTO);
        Task<User> DeleteUser(int id, string password);
        Task<User> GetUser(int id);
        Task<List<User>> GetUsers();
        Task<User> UpdateUser(UpdateUserDTO userDTO);
    }
}
