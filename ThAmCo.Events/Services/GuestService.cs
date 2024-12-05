using ThAmCo.Events.Models;
using ThAmCo.Events.Repositories.Interfaces;

namespace ThAmCo.Events.Services
{
    public class GuestService
    {
        private readonly IGuestRepository _guestRepository;

        public GuestService(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<Guest> CreateGuestAsync(Guest singleGuest)
        {
            return await _guestRepository.CreateGuestAsync(singleGuest);
        }

        public async Task<bool> DeleteGuestAsync(int id)
        {
            return await _guestRepository.DeleteGuestAsync(id);
        }

        public async Task<IEnumerable<Guest>> GetAllGuestsAsync()
        {
            return await _guestRepository.GetAllGuestsAsync();
        }

        public async Task<Guest?> GetGuestAsync(int id)
        {
            return await _guestRepository.GetGuestAsync(id);
        }

        public async Task<Guest> UpdateGuestAsync(Guest guestData)
        {
            return await _guestRepository.UpdateGuestAsync(guestData);
        }
    }
}
