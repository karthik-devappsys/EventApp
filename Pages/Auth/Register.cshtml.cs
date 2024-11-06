using EventManageApp.Core.Models.Auth;
using EventManageApp.Core.Services;
using EventManageApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventManageApp.Pages.Auth
{
    public class Register : PageModel
    {

        private readonly AuthService authService;

        public Register(AuthService service)
        {
            authService = service;
        }

        [BindProperty]
        public RegisterModel RegisterModel { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid) return Page();
            try
            {
                bool ContactExist = await authService.ContactExist(RegisterModel.Contact);

                if (ContactExist)
                {
                    ModelState.AddModelError("RegisterModel.Contact", "Contact Number already taken.");
                    return Page();
                }

                bool emailExist = await authService.EmailExist(RegisterModel.Email);

                if (emailExist)
                {
                    ModelState.AddModelError("RegisterModel.Email", "Email id already taken.");
                    return Page();
                }

                var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

                // Create the directory if it doesn't exist
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                var uniqueFileName = $"User_{Guid.NewGuid()}{Path.GetExtension(RegisterModel.ImageFile.FileName)}";
                var filePath = Path.Combine(uploadFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await RegisterModel.ImageFile.CopyToAsync(fileStream);
                }
                await authService.CreateAccount(RegisterModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return Page();
            }

            return Redirect("./Login");
        }
    }
}