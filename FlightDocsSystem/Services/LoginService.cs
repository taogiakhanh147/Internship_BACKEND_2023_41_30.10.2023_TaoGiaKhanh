using FlightDocsSystem.DTO;
using FlightDocsSystem.IServices;
using FlightDocsSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FlightDocsSystem.Services
{
    public class LoginService : ILoginService
    {
        private readonly IConfiguration _configuration;
        private readonly FlightDocsSystemContext _context;

        public LoginService(IConfiguration configuration, FlightDocsSystemContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<IActionResult> GenerateJwtToken(LoginDTO loginDTO)
        {
            if (loginDTO != null && !string.IsNullOrEmpty(loginDTO.Email) && !string.IsNullOrEmpty(loginDTO.Password))
            {
                var userData = await GetUser(loginDTO.Email, loginDTO.Password);
                var jwt = _configuration.GetSection("Jwt").Get<Jwt>();

                if (userData != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Email", loginDTO.Email),
                        new Claim("Password", loginDTO.Password),
                    };

                    // Kiểm tra xem người dùng có quyền "Admin System", "GO", "Pilot" hay "Flight Attendant" hay không
                    if (userData.RoleID >= 1 && userData.RoleID <= 4)
                    {
                        // Nếu có quyền, thêm quyền vào danh sách claims
                        var roleClaim = new Claim(ClaimTypes.Role, GetRoleName(userData.RoleID));
                        claims.Add(roleClaim);
                    }

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        jwt.Issuer,
                        jwt.Audience,
                        claims,
                        expires: DateTime.Now.AddMinutes(20),
                        signingCredentials: signIn
                    );

                    return new OkObjectResult(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return new BadRequestObjectResult("Invalid Credentials");
                }
            }
            else
            {
                return new BadRequestObjectResult("Invalid Credentials");
            }
        }

        private async Task<User> GetUser(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        private string GetRoleName(int roleId)
        {
            switch (roleId)
            {
                case 1:
                    return "Admin System";
                case 2:
                    return "GO";
                case 3:
                    return "Pilot";
                case 4:
                    return "Flight Attendant";
                default:
                    return string.Empty;
            }
        }
    }
}
