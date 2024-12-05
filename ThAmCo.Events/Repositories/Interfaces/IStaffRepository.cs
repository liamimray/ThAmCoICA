using ThAmCo.Events.Models;

namespace ThAmCo.Events.Repositories.Interfaces
{
    public interface IStaffRepository
    {
        Task<Staff> CreateStaffAsync(Staff singleStaff);
        Task<bool> DeleteStaffAsync(int id);
        Task<Staff> UpdateStaffAsync(Staff staffData);
        Task<IEnumerable<Staff>> GetAllStaffAsync();
        Task<Staff?> GetStaffAsync(int id);
    }
}
