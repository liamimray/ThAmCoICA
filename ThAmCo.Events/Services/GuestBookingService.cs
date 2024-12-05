using ThAmCo.Events.Models;
using ThAmCo.Events.Repositories.Interfaces;

namespace ThAmCo.Events.Services
{
    public class GuestBookingService
    {
        private readonly IGuestBookingRepository _guestBookingRepository;

        public GuestBookingService(IGuestBookingRepository guestBookingRepository)
        {
            _guestBookingRepository = guestBookingRepository;
        }

        public async Task<GuestBooking> CreateGuestBookingAsync(GuestBooking singleGuestBooking)
        {
            return await _guestBookingRepository.CreateGuestBookingAsync(singleGuestBooking);
        }

        public async Task<bool> DeleteGuestBookingAsync(int id)
        {
            return await _guestBookingRepository.DeleteGuestBookingAsync(id);
        }

        public async Task<IEnumerable<GuestBooking>> GetAllGuestBookingsAsync()
        {
            return await _guestBookingRepository.GetAllGuestBookingsAsync();
        }

        public async Task<GuestBooking?> GetGuestBookingAsync(int id)
        {
            return await _guestBookingRepository.GetGuestBookingAsync(id);
        }

        public async Task<GuestBooking> UpdateGuestBookingAsync(GuestBooking guestBookingData)
        {
            return await _guestBookingRepository.UpdateGuestBookingAsync(guestBookingData);
        }
    }
}