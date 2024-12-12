using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ThAmCo.Events.Models;
using ThAmCo.Events.Models.DTO;

namespace ThAmCo.Events.Pages.EventsList
{
    public class CreateModel : PageModel
    {
        private readonly EventsDbContext _context;

        public CreateModel(EventsDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CreateEventDTO EventDto { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var evnt = new Event
            {
                Title = EventDto.Title,
                Date = EventDto.Date,
                EventType = EventDto.EventType,
                IsCancelled = EventDto.IsCancelled,
                VenueId = EventDto.VenueId
            };

            _context.Events.Add(evnt);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}