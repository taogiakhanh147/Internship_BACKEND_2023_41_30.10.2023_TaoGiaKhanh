using FlightDocsSystem.DTO;
using FlightDocsSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocsSystem.IServices
{
    public interface ILoginService
    {
        Task<IActionResult> GenerateJwtToken(LoginDTO jwtDTO);
        /*Task<User> GetUser(string email, string password);*/
    }
}
