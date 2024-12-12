using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Models;

namespace ThAmCo.Events.Pages.EventsList
{
    public class IndexModel : PageModel
    {
        private readonly EventsDbContext _context;

        public IndexModel(EventsDbContext context)
        {
            _context = context;
        }

        public IList<EventViewModel> Event { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Event = await _context.Events
                .Include(e => e.GuestBookings)
                .ThenInclude(gb => gb.Guest)
                .Select(e => new EventViewModel
                {
                    Id = e.Id,
                    Title = e.Title,
                    Date = e.Date,
                    EventType = e.EventType,
                    IsCancelled = e.IsCancelled,
                    VenueId = e.VenueId,
                    TotalBookings = e.GuestBookings.Count(),
                    ConfirmedAttendees = e.GuestBookings.Count(gb => gb.IsAttending)
                })
                .ToListAsync();
        }

        public class EventViewModel
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public DateTime Date { get; set; }
            public string EventType { get; set; }
            public bool IsCancelled { get; set; }
            public int? VenueId { get; set; }
            public int TotalBookings { get; set; }
            public int ConfirmedAttendees { get; set; }
        }
    }
}