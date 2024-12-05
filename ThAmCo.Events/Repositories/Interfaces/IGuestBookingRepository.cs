using ThAmCo.Events.Models;

namespace ThAmCo.Events.Repositories.Interfaces
{
    public interface IGuestBookingRepository
    {
        Task<GuestBooking> CreateGuestBookingAsync(GuestBooking singleGuestBooking);
        Task<bool> DeleteGuestBookingAsync(int id);
        Task<GuestBooking> UpdateGuestBookingAsync(GuestBooking guestBookingData);
        Task<IEnumerable<GuestBooking>> GetAllGuestBookingsAsync();
        Task<GuestBooking?> GetGuestBookingAsync(int id);
    }
}