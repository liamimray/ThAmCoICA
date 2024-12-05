using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Models;
using ThAmCo.Events.Repositories.Interfaces;

namespace ThAmCo.Events.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly EventsDbContext _eventsDbContext;

        public GuestRepository(EventsDbContext context)
        {
            _eventsDbContext = context;
        }

        public async Task<Guest> CreateGuestAsync(Guest singleGuest)
        {
            _eventsDbContext.Guests.Add(singleGuest);
            await _eventsDbContext.SaveChangesAsync();
            return singleGuest;
        }

        public async Task<bool> DeleteGuestAsync(int id)
        {
            var guest = await _eventsDbContext.Guests.FindAsync(id);

            if (guest != null)
            {
                _eventsDbContext.Guests.Remove(guest);
                await _eventsDbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Guest>> GetAllGuestsAsync()
        {
            return await _eventsDbContext.Guests.ToListAsync();
        }

        public async Task<Guest?> GetGuestAsync(int id)
        {
            return await _eventsDbContext.Guests.FindAsync(id);
        }

        public async Task<Guest> UpdateGuestAsync(Guest guestData)
        {
            _eventsDbContext.Entry(guestData).State = EntityState.Modified;
            await _eventsDbContext.SaveChangesAsync();
            return guestData;
        }
    }
}
