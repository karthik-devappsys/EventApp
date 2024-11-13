using EventManageApp.Core.Models.Event;
using EventManageApp.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventManageApp.Pages.Admin.Event
{
    public class Index : PageModel
    {
        private readonly EventService _service;
        public Index(EventService eventService)
        {
            _service = eventService;
        }

        public IList<ViewEvents> Events { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            Events = await _service.GetEventsAsync();
            return Page();
        }
    }
}