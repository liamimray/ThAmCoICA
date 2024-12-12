using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Models;

namespace ThAmCo.Events.Pages.EventsList
{
    public class EditModel : PageModel
    {
        private readonly ThAmCo.Events.Models.EventsDbContext _context;

        public EditModel(ThAmCo.Events.Models.EventsDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EditEventDto EventDto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evnt = await _context.Events.FirstOrDefaultAsync(m => m.Id == id);
            if (evnt == null)
            {
                return NotFound();
            }

            EventDto = new EditEventDto
            {
                Id = evnt.Id,
                Title = evnt.Title,
                VenueId = evnt.VenueId
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var evnt = await _context.Events.FirstOrDefaultAsync(m => m.Id == id);
            if (evnt == null)
            {
                return NotFound();
            }

            evnt.Title = EventDto.Title;
            evnt.VenueId = EventDto.VenueId;

            _context.Attach(evnt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(EventDto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}