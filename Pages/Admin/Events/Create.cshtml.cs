using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManageApp.Core.Models.Event;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EventManageApp.Pages.Admin.Events
{
    public class Create : PageModel
    {
        [BindProperty]
        public required CreateEvent Event { get; set; }


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            return Page();
        }
    }
}