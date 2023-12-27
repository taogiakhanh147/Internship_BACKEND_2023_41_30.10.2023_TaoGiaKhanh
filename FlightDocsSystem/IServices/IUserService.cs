using FlightDocsSystem.DTO;
using FlightDocsSystem.Models;

namespace FlightDocsSystem.IServices
{
    public interface IUserService
    {
        public Task<List<User>> getAllUserAsync();

        public Task<User> getUserAsync(int id);

        public Task<User> AddUserAsync(UserDTO model);

        public Task<User> UpdateUserAsync(int id, UserDTO model);

        public Task DeleteUserAsync(int id);
    }
}
