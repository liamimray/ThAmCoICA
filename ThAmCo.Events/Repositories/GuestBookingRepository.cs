using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Models;
using ThAmCo.Events.Repositories.Interfaces;

namespace ThAmCo.Events.Repositories
{
    public class GuestBookingRepository : IGuestBookingRepository
    {
        private readonly EventsDbContext _eventsDbContext;

        public GuestBookingRepository(EventsDbContext context)
        {
            _eventsDbContext = context;
        }

        public async Task<GuestBooking> CreateGuestBookingAsync(GuestBooking singleGuestBooking)
        {
            _eventsDbContext.GuestBookings.Add(singleGuestBooking);
            await _eventsDbContext.SaveChangesAsync();
            return singleGuestBooking;
        }

        public async Task<bool> DeleteGuestBookingAsync(int id)
        {
            var guestBooking = await _eventsDbContext.GuestBookings.FindAsync(id);

            if (guestBooking != null)
            {
                _eventsDbContext.GuestBookings.Remove(guestBooking);
                await _eventsDbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<GuestBooking>> GetAllGuestBookingsAsync()
        {
            return await _eventsDbContext.GuestBookings.ToListAsync();
        }

        public async Task<GuestBooking?> GetGuestBookingAsync(int id)
        {
            return await _eventsDbContext.GuestBookings.FindAsync(id);
        }

        public async Task<GuestBooking> UpdateGuestBookingAsync(GuestBooking guestBookingData)
        {
            _eventsDbContext.Entry(guestBookingData).State = EntityState.Modified;
            await _eventsDbContext.SaveChangesAsync();
            return guestBookingData;
        }
    }
}