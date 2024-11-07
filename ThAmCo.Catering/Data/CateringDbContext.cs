using Microsoft.EntityFrameworkCore;

namespace ThAmCo.Catering.Data
{
    public class CateringDbContext : DbContext
    {
        public DbSet<FoodBooking> FoodBookings { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<MenuFoodItem> MenuFoodItems { get; set; }
        public DbSet<Menu>  Menu { get; set; }
    }
}
