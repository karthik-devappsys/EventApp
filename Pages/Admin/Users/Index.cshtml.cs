using EventManageApp.Core.Enums;
using EventManageApp.Core.Models.User;
using EventManageApp.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EventManageApp.Pages.Admin.User
{
    public class Index : PageModel
    {
        private readonly ApplicationDbContext _context;

        public Index(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<UserModel> Users { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var name = HttpContext.Session.GetString("User")!;
            Console.Write("UserName: " + name);
            Users = await _context.Users
            .Where(user => user.UserType == UserType.User)
            .Select(user => new UserModel
            {
                Id = user.Id,
                Contact = user.Contact,
                Email = user.Email,
                Name = user.Name,
                Status = user.Status
            })
             .ToListAsync();

            return Page();
        }
    }
}