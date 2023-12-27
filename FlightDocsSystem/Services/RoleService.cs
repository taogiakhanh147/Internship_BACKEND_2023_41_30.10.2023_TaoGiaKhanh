using FlightDocsSystem.DTO;
using FlightDocsSystem.IServices;
using FlightDocsSystem.Models;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;

namespace FlightDocsSystem.Services
{
    public class RoleService : IRoleService 
    {
        private readonly FlightDocsSystemContext _context;

        public RoleService(FlightDocsSystemContext context)
        {
            _context = context;
        }

        public async Task<List<Role>> getAllRoleAsync()
        {
            var Roles = await _context.Roles.ToListAsync();
            return Roles;
        }

        public async Task<Role> getRoleAsync(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (_context.Roles == null || role == null)
            {
                throw new NotFoundException("RoleID does not exist");
            }
            return role;
        }


        public async Task<Role> AddRoleAsync(RoleDTO roleDTO)
        {
            if (roleDTO == null)
            {
                throw new NotFoundException("Please enter complete information");
            }
            var NewRole = new Role
            {
                RoleName = roleDTO.RoleName
            };
            _context.Roles.Add(NewRole);
            await _context.SaveChangesAsync();
            return NewRole;
        }

        public async Task<Role> UpdateRoleAsync(int id, RoleDTO model)
        {
            var existingRole = await _context.Roles.FindAsync(id);
            if (existingRole == null)
            {
                throw new NotFoundException("ID does not exist");
            }
            else
            {
                existingRole.RoleName = model.RoleName;
                _context.Roles.Update(existingRole);
                await _context.SaveChangesAsync();
            }
            return existingRole;
        }


        public async Task DeleteRoleAsync(int id)
        {
            var existingRole = _context.Roles!.SingleOrDefault(b => b.RoleID == id);
            if (existingRole != null)
            {
                _context.Roles.Remove(existingRole);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException("ID does not exist");
            }
        }
    }
}
