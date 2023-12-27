using FlightDocsSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace FlightDocsSystem.DTO
{
    public class UserDTO
    {
        public string? UserName { get; set; }
        [RegularExpression(@"^[0-9]{10,11}$", ErrorMessage = "Invalid phone number.")]
        public string? Phone { get; set; }

        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        [Required(ErrorMessage = "Email là trường bắt buộc.")]
        [CustomEmailValidation(ErrorMessage = "Email phải thuộc tên miền @vietjetair.com")]
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        [Required]
        public int GroupID { get; set; }
        [Required]
        public int RoleID { get; set; }
    }

    public class CustomEmailValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string email = value as string;

            if (email != null)
            {
                // Kiểm tra xem email có thuộc tên miền @vietjetair.com không
                if (!email.EndsWith("@vietjetair.com", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
