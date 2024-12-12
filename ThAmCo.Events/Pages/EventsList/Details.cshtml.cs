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
    public class DetailsModel : PageModel
    {
        private readonly ThAmCo.Events.Models.EventsDbContext _context;

        public DetailsModel(ThAmCo.Events.Models.EventsDbContext context)
        {
            _context = context;
        }

        public Event Event { get; set; } = default!;
        public List<Guest> Attendees { get; set; } = new List<Guest>();
        public int TotalAttendees => Attendees.Count(a => a.IsAttending);

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Events
                .Include(e => e.GuestBookings)
                .ThenInclude(gb => gb.Guest)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Event == null)
            {
                return NotFound();
            }

            Attendees = Event.GuestBookings.Select(gb => gb.Guest).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostRegisterAttendanceAsync(int? id, int guestId, bool isAttending)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Events
                .Include(e => e.GuestBookings)
                .ThenInclude(gb => gb.Guest)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Event == null)
            {
                return NotFound();
            }

            var guest = await _context.Guests.FindAsync(guestId);
            if (guest != null)
            {
                guest.IsAttending = isAttending;
                await _context.SaveChangesAsync();
            }

            return RedirectToPage(new { id = Event.Id });
        }
    }
}