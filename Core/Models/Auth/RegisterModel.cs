
using System.ComponentModel.DataAnnotations;

namespace EventManageApp.Core.Models.Auth
{
    public class RegisterModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Contact { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Imagefile is required")]
        [DataType(DataType.Upload)]
        // [FileExtensions(Extensions = ".jpg,.jpeg,.png", ErrorMessage = "Please upload valid image file")]
        public IFormFile ImageFile { get; set; }
    }
}