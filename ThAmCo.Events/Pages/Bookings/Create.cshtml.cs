using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Models;
using ThAmCo.Events.Models.DTO;

namespace ThAmCo.Events.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly ThAmCo.Events.Models.EventsDbContext _context;

        public CreateModel(ThAmCo.Events.Models.EventsDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BookGuestDto BookingDto { get; set; } = default!;

        public SelectList Guests { get; set; }
        public SelectList Events { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Guests = new SelectList(await _context.Guests.ToListAsync(), "Id", "Name");
            Events = new SelectList(await _context.Events.ToListAsync(), "Id", "Title");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Guests = new SelectList(await _context.Guests.ToListAsync(), "Id", "Name");
                Events = new SelectList(await _context.Events.ToListAsync(), "Id", "Title");
                return Page();
            }

            var existingBooking = await _context.GuestBookings
                .FirstOrDefaultAsync(gb => gb.GuestId == BookingDto.GuestId && gb.EventId == BookingDto.EventId);

            if (existingBooking != null)
            {
                ModelState.AddModelError(string.Empty, "This guest is already booked for the selected event.");
                Guests = new SelectList(await _context.Guests.ToListAsync(), "Id", "Name");
                Events = new SelectList(await _context.Events.ToListAsync(), "Id", "Title");
                return Page();
            }

            var guestBooking = new GuestBooking
            {
                GuestId = BookingDto.GuestId,
                EventId = BookingDto.EventId
            };

            _context.GuestBookings.Add(guestBooking);
            await _context.SaveChangesAsync();

            return RedirectToPage("/EventsList/Index");
        }
    }
}