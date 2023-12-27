using FlightDocsSystem.DTO;
using FlightDocsSystem.IServices;
using FlightDocsSystem.Models;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;

namespace FlightDocsSystem.Services
{
    public class UserService : IUserService
    {
        private readonly FlightDocsSystemContext _context;

        public UserService(FlightDocsSystemContext context)
        {
            _context = context;
        }

        public async Task<List<User>> getAllUserAsync()
        {
            var Users = await _context.Users.ToListAsync();
            return Users;
        }

        public async Task<User> getUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (_context.Users == null || user == null)
            {
                throw new NotFoundException("UserID does not exist");
            }
            return user;
        }

        public async Task<User> AddUserAsync(UserDTO userDTO)
        {
            if (userDTO == null)
            {
                throw new NotFoundException("Please enter complete information");
            }
            var newUser = new User
            {
                UserName = userDTO.UserName,
                Phone = userDTO.Phone,
                Email = userDTO.Email,
                Password = userDTO.Password,
                Status = userDTO.Status,
                GroupID = userDTO.GroupID,
                RoleID = userDTO.RoleID
            };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<User> UpdateUserAsync(int id, UserDTO model)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
            {
                throw new NotFoundException("ID does not exist");
            }
            else
            {
                existingUser.UserName = model.UserName;
                existingUser.Phone = model.Phone;
                existingUser.Email = model.Email;
                existingUser.Password = model.Password;
                existingUser.Status = model.Status;
                existingUser.GroupID = model.GroupID;
                existingUser.RoleID = model.RoleID;
                _context.Users.Update(existingUser);
                await _context.SaveChangesAsync();
            }
            return existingUser;
        }

        public async Task DeleteUserAsync(int id)
        {
            var existingUser = _context.Users!.SingleOrDefault(b => b.UserID == id);
            if (existingUser != null)
            {
                _context.Users.Remove(existingUser);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException("ID does not exist");
            }
        }
    }
}
