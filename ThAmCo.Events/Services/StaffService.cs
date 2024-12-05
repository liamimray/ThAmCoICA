using ThAmCo.Events.Models;
using ThAmCo.Events.Repositories.Interfaces;

namespace ThAmCo.Events.Services
{
    public class StaffService
    {
        private readonly IStaffRepository _staffRepository;

        public StaffService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public async Task<Staff> CreateStaffAsync(Staff singleStaff)
        {
            return await _staffRepository.CreateStaffAsync(singleStaff);
        }

        public async Task<bool> DeleteStaffAsync(int id)
        {
            return await _staffRepository.DeleteStaffAsync(id);
        }

        public async Task<IEnumerable<Staff>> GetAllStaffAsync()
        {
            return await _staffRepository.GetAllStaffAsync();
        }

        public async Task<Staff?> GetStaffAsync(int id)
        {
            return await _staffRepository.GetStaffAsync(id);
        }

        public async Task<Staff> UpdateStaffAsync(Staff staffData)
        {
            return await _staffRepository.UpdateStaffAsync(staffData);
        }
    }
}