using AutoMapper;
using BlogDemo.Contexts;
using BlogDemo.DTOs.UserDTOs;
using BlogDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogDemo.Services.UserServices
{
    public class UserServices : IUserServices
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserServices(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<User> AddUser(AddUserDTOs userDTO)
        {
            var UserInsert = _mapper.Map<User>(userDTO);

            _context.Users.Add(UserInsert);
            await _context.SaveChangesAsync();
            return UserInsert;
        }
        public async Task<User> DeleteUser(int id, string password)
        {
            var userDel = await _context.Users
                .Where(bp => bp.Id == id)
                .FirstOrDefaultAsync();

            var userPass = await _context.Users
                .Where(bp => bp.Password == password)
                .FirstOrDefaultAsync();

            if (userDel == null)
            {
                throw new KeyNotFoundException("User Not Found.");
            } else if (userPass == null)
            {
                throw new KeyNotFoundException("User Not Found.");

            }
            _context.Users.Remove(userDel);
            await _context.SaveChangesAsync();

            return userDel;
        }


        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.
                Where(bp => bp.Id == id).
                FirstOrDefaultAsync();

            if ( user == null ) { throw new KeyNotFoundException("User not Found"); }

            return user;
        }
        public async Task<List<User>> GetUsers()
        {
            var user = await _context.Users.
                OrderByDescending(bp =>bp.UpdatedAt)
                .ToListAsync();
            return user;
        }
        public async Task<User> UpdateUser(UpdateUserDTO userDTO)
        {
            var user = await _context.Users.
                Where(b => b.Id == userDTO.Id).
                FirstOrDefaultAsync();
            if ( user == null ) { throw new KeyNotFoundException("User not Found"); }
            user = _mapper.Map(userDTO, user);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;

        }

    }
    }

