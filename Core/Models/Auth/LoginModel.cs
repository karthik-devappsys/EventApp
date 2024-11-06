
using System.ComponentModel.DataAnnotations;

namespace EventManageApp.Core.Models.Auth
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}