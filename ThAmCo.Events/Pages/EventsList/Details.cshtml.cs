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
        private readonly EventsDbContext _context;

        public DetailsModel(EventsDbContext context)
        {
            _context = context;
        }

        public Event Event { get; set; } = default!;
        public List<GuestBooking> Attendees { get; set; } = new List<GuestBooking>();

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

            Attendees = Event.GuestBookings.ToList();

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
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Event == null)
            {
                return NotFound();
            }

            var guestBooking = Event.GuestBookings.FirstOrDefault(gb => gb.GuestId == guestId);
            if (guestBooking != null)
            {
                guestBooking.IsAttending = isAttending;
                await _context.SaveChangesAsync();
            }

            return RedirectToPage(new { id = Event.Id });
        }
    }
}