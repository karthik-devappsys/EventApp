using EventManageApp.Core.Common;
using EventManageApp.Core.Models.Event;
using EventManageApp.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventManageApp.Pages.Admin.Events
{
    public class Create : PageModel
    {
        private readonly EventService _eventService;

        public Create(EventService eventService)
        {
            _eventService = eventService;
        }
        [BindProperty]
        public required CreateEvent Event { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            bool isSuccess = await _eventService.CreateEvent(Event);

            if (isSuccess) return RedirectToPage("./Index");

            return Page();
        }
    }
}