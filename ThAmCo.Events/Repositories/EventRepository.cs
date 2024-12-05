using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;
using ThAmCo.Events.Models;
using ThAmCo.Events.Repositories.Interfaces;

namespace ThAmCo.Events.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventsDbContext _eventsDbContext;
        public EventRepository(EventsDbContext context)
        {
            _eventsDbContext = context;
        }
        public async Task<Event> CreateEventAsync(Event singleEvent)
        {
             _eventsDbContext.Events.Add(singleEvent);
            await _eventsDbContext.SaveChangesAsync();
            return singleEvent;
        }

        public async Task<bool> DeleteEventAsync(int id)
        {
            var evnt = await _eventsDbContext.Events.FindAsync(id);

            if (evnt != null)
            {
                _eventsDbContext.Events.Remove(evnt);
                await _eventsDbContext.SaveChangesAsync();
                return true;
            }

            return false;

        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            var events = _eventsDbContext.Events.ToList();
            return events;
        }

        public async Task<Event?> GetEventAsync(int id)
        {
            var evnt = await _eventsDbContext.Events.FindAsync(id);

            if (evnt != null)
            {
               return evnt;
            }

            return null;
        }

        public async Task<Event> UpdateEventAsync(Event eventData)
        {
            _eventsDbContext.Entry(eventData).State = EntityState.Modified;
            await _eventsDbContext.SaveChangesAsync();
            return eventData;
        }
    }
}
