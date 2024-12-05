using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Models;
using ThAmCo.Events.Repositories.Interfaces;

namespace ThAmCo.Events.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly EventsDbContext _eventsDbContext;

        public StaffRepository(EventsDbContext context)
        {
            _eventsDbContext = context;
        }

        public async Task<Staff> CreateStaffAsync(Staff singleStaff)
        {
            _eventsDbContext.StaffMembers.Add(singleStaff);
            await _eventsDbContext.SaveChangesAsync();
            return singleStaff;
        }

        public async Task<bool> DeleteStaffAsync(int id)
        {
            var staff = await _eventsDbContext.StaffMembers.FindAsync(id);

            if (staff != null)
            {
                _eventsDbContext.StaffMembers.Remove(staff);
                await _eventsDbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Staff>> GetAllStaffAsync()
        {
            return await _eventsDbContext.StaffMembers.ToListAsync();
        }

        public async Task<Staff?> GetStaffAsync(int id)
        {
            return await _eventsDbContext.StaffMembers.FindAsync(id);
        }

        public async Task<Staff> UpdateStaffAsync(Staff staffData)
        {
            _eventsDbContext.Entry(staffData).State = EntityState.Modified;
            await _eventsDbContext.SaveChangesAsync();
            return staffData;
        }
    }
}