// Trong LoginController.cs
using FlightDocsSystem.DTO;
using FlightDocsSystem.IServices;
using Microsoft.AspNetCore.Mvc;
// ...

namespace FlightDocsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(LoginDTO jwtDTO)
        {
            return await _loginService.GenerateJwtToken(jwtDTO);
        }
    }
}
