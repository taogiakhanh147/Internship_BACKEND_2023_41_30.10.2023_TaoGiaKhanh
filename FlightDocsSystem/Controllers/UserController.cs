using FlightDocsSystem.DTO;
using FlightDocsSystem.IServices;
using FlightDocsSystem.Models;
using FlightDocsSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin System")]
    public class UserController : Controller
    {
        private readonly IUserService _iUserService;

        public UserController(IUserService iUser, FlightDocsSystemContext context)
        {
            _iUserService = iUser;
        }

        // Function GetAllUser (GET)
        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            var allUser = await _iUserService.getAllUserAsync();
            return Ok(allUser);
        }

        // Function GetUserById (GET_ID)
        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _iUserService.getUserAsync(id);
            return Ok(user);
        }

        // Function AddNewUser (POST)
        [HttpPost("AddNewUser")]
        public async Task<IActionResult> AddNewUser(UserDTO model)
        {
            var newUser = await _iUserService.AddUserAsync(model);
            return Ok(newUser);
        }

        // Function UpdateUser (PUT)
        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserDTO model)
        {
            var UpdateUser = await _iUserService.UpdateUserAsync(id, model);
            return Ok(UpdateUser);
        }

        // Function DeleteUser (DELETE)
        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _iUserService.DeleteUserAsync(id);
            return Ok();
        }
    }
}
