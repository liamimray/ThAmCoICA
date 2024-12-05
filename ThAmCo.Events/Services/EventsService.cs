using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using ThAmCo.Events.Models;
using ThAmCo.Events.Models.DTO;
using ThAmCo.Events.Repositories.Interfaces;

namespace ThAmCo.Events.Services
{
    public class 

    {
        private readonly HttpClient _httpClient; // Private property for the HttpClient object.
        private readonly IEventRepository _eventRepository;
        // Constructor that accepts an HttpClient instance via dependency injection.
        public EventsService(HttpClient httpClient, IEventRepository eventRepository)
        {
            _httpClient = httpClient; // Initialise the HttpClient property.
            _eventRepository = eventRepository;
        }
        JsonSerializerOptions jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<EventDTO> CreateEventAsync(CreateEventDTO singleEvent)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteEventAsync(int id)
        {
            var response = await _eventRepository.DeleteEventAsync(id);
            return response;
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            var response = await _eventRepository.GetAllEventsAsync();
            return response;
        }

        public async Task<Event?> GetEventAsync(int id)
        {
            var response = await _eventRepository.GetEventAsync(id);
            return response;
        }

        public async Task<Event> UpdateEventAsync(Event eventData)
        {
            var response = await _eventRepository.UpdateEventAsync(eventData);
            return response;
        }

        private async Task<IEnumerable<EventTypeDTO>> GetEventTypesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<EventTypeDTO>>("/EventTypes");
            return response ?? new List<EventTypeDTO>();
        }

    }
}
