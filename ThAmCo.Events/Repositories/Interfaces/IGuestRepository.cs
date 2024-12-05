using ThAmCo.Events.Models;

namespace ThAmCo.Events.Repositories.Interfaces
{
    public interface IGuestRepository
    {
        Task<Guest> CreateGuestAsync(Guest singleGuest);
        Task<bool> DeleteGuestAsync(int id);
        Task<Guest> UpdateGuestAsync(Guest guestData);
        Task<IEnumerable<Guest>> GetAllGuestsAsync();
        Task<Guest?> GetGuestAsync(int id);
    }
}
