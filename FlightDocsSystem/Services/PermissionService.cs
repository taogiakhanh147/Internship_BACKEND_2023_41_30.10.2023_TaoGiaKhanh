using FlightDocsSystem.DTO;
using FlightDocsSystem.IServices;
using FlightDocsSystem.Models;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;

namespace FlightDocsSystem.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly FlightDocsSystemContext _context;

        public PermissionService(FlightDocsSystemContext context)
        {
            _context = context;
        }

        public async Task<List<Permission>> getAllPermissionAsync()
        {
            var Permissions = await _context.Permissions.ToListAsync();
            return Permissions;
        }

        public async Task<Permission> getPermissionAsync(int id)
        {
            var Permission = await _context.Permissions.FindAsync(id);
            if (_context.Permissions == null || Permission == null)
            {
                throw new NotFoundException("PerissionID does not exist");
            }
            return Permission;
        }


        public async Task<Permission> AddPermissionAsync(PermissionDTO permissionDTO)
        {
            if (permissionDTO == null)
            {
                throw new NotFoundException("Please enter complete information");
            }

            var permission = new Permission
            {
                PermissionName = permissionDTO.PermissionName
            };

            _context.Permissions.Add(permission);
            await _context.SaveChangesAsync();
            return permission;
        }

        public async Task<Permission> UpdatePermissionAsync(int id, PermissionDTO model)
        {
            var existingPermission = await _context.Permissions.FindAsync(id);
            if (existingPermission == null)
            {
                throw new NotFoundException("ID does not exist");
            }
            else
            {
                existingPermission.PermissionName = model.PermissionName;
                _context.Permissions.Update(existingPermission);
                await _context.SaveChangesAsync();
            }
            return existingPermission;
        }


        public async Task DeletePermissionAsync(int id)
        {
            var existingPermission = _context.Permissions!.SingleOrDefault(b => b.PermissionID == id);
            if (existingPermission != null)
            {
                _context.Permissions.Remove(existingPermission);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException("ID does not exist");
            }
        }
    }
}
