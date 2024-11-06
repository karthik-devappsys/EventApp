using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManageApp.Core.Models.User;
using EventManageApp.Data.Context;
using EventManageApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EventManageApp.Pages.Admin.User
{
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;
        private readonly ApplicationDbContext _context;

        public Index(ILogger<Index> logger, ApplicationDbContext context)
        {
            _logger = logger;
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