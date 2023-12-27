using FlightDocsSystem.DTO;
using FlightDocsSystem.Models;

namespace FlightDocsSystem.IServices
{
    public interface IRoleService
    {
        public Task<List<Role>> getAllRoleAsync();

        public Task<Role> getRoleAsync(int id);

        public Task<Role> AddRoleAsync(RoleDTO model);

        public Task<Role> UpdateRoleAsync(int id, RoleDTO model);

        public Task DeleteRoleAsync(int id);
    }
}
