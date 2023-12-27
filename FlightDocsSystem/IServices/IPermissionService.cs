using FlightDocsSystem.DTO;
using FlightDocsSystem.Models;

namespace FlightDocsSystem.IServices
{
    public interface IPermissionService
    {
        public Task<List<Permission>> getAllPermissionAsync();

        public Task<Permission> getPermissionAsync(int id);

        public Task<Permission> AddPermissionAsync(PermissionDTO model);

        public Task<Permission> UpdatePermissionAsync(int id, PermissionDTO model);

        public Task DeletePermissionAsync(int id);
    }
}
