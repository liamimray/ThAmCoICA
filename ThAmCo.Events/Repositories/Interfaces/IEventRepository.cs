using ThAmCo.Events.Models;

namespace ThAmCo.Events.Repositories.Interfaces
{
    public interface IEventRepository
    {
        Task<Event> CreateEventAsync(Event singleEvent);
        Task<bool> DeleteEventAsync(int id);
        Task<Event> UpdateEventAsync(Event eventData);
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<Event?> GetEventAsync(int id);
    }
}
