using System.Security.Claims;
using EventManageApp.Core.Models.Auth;
using EventManageApp.Data.Context;
using EventManageApp.Data.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace EventManageApp.Core.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public string HashPassword(string Password)
        {
            int rounds = 10;
            string salt = BCrypt.Net.BCrypt.GenerateSalt(rounds);
            return BCrypt.Net.BCrypt.HashPassword(Password, salt);
        }

        private bool VerifyPassword(string Password, string HashedPassword)
        {
            return !BCrypt.Net.BCrypt.Verify(Password, HashedPassword);
        }

        public async Task<bool> ContactExist(string Contact)
        {
            return await _context.Users.AnyAsync(u => u.Contact == Contact);
        }
        public async Task<bool> EmailExist(string Email)
        {
            return await _context.Users.AnyAsync(u => u.Email == Email);
        }


        public async Task<bool> CreateAccount(RegisterModel register)
        {
            var newAccount = new Users
            {
                Name = register.Name,
                Contact = register.Contact,
                Email = register.Email,
                Password = HashPassword(register.Password)
            };
            await _context.Users.AddAsync(newAccount);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Login(LoginModel login, HttpContext httpContext)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == login.Email);

            if (user == null || VerifyPassword(login.Password, user.Password))
            {
                throw new Exception("Invalid Login Credentials...");
            };

            if (user.Status != UserStatus.Active)
            {
                throw new Exception("Unable to access your account. Please contact admin for future assistance...");
            }

            await SignInAsync(httpContext, user.Id.ToString(), user.UserType.ToString());

            return user.UserType == UserType.Admin;
        }

        private async Task SignInAsync(HttpContext httpContext, string userId, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,userId),
                new Claim(ClaimTypes.Role,role)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = false // Keeps the cookie even after closing the browser
            };

            // Sign in user
            await httpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        private async Task SignOutAsync(HttpContext httpContext)
        {
            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }


}