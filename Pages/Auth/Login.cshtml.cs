using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManageApp.Core.Models.Auth;
using EventManageApp.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EventManageApp.Pages.Auth
{
    public class Login : PageModel
    {
        private readonly AuthService authService;

        public Login(AuthService service)
        {
            authService = service;
        }
        [BindProperty]
        public LoginModel LoginModel { get; set; }

        public string ErrorMessage { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            try
            {
                HttpContext.Session.SetString("User", "Karna");

                bool isAdmin = await authService.Login(LoginModel, HttpContext);

                if (isAdmin) return RedirectToPage("../Admin/Home");


                return RedirectToPage("../User/Home");

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message.ToString();
                Console.WriteLine(ex);
                return Page();
            }

        }
    }
}