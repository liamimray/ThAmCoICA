using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;

namespace ThAmCo.Catering.Data
{
    public class CateringDbContext : DbContext
    {
        public DbSet<FoodBooking> FoodBookings { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuFoodItem> MenuFoodItems { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }

        private readonly IHostEnvironment _hostEnv;
        private readonly string DbPath;

        public CateringDbContext(DbContextOptions<CateringDbContext> options, IHostEnvironment env) : base(options)
        {
            _hostEnv = env;
            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "ThAmCo.Catering.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // FoodBooking primary key and foreign key to Menu
            builder.Entity<FoodBooking>()
                   .HasKey(fb => fb.FoodBookingId);

            builder.Entity<FoodBooking>()
                   .HasOne(fb => fb.Menu)
                   .WithMany(m => m.FoodBookings)
                   .HasForeignKey(fb => fb.MenuId);

            // Menu primary key
            builder.Entity<Menu>()
                   .HasKey(m => m.MenuId);

            builder.Entity<Menu>()
                   .HasMany(mfi => mfi.MenuFoodItems)
                   .WithOne(m => m.Menu)
                   .HasForeignKey(mfi => mfi.MenuId);

            // MenuFoodItem composite key (MenuId, FoodItemId)
            builder.Entity<MenuFoodItem>()
                   .HasKey(mf => new { mf.MenuId, mf.FoodItemId });


            // FoodItem primary key
            builder.Entity<FoodItem>()
                   .HasKey(fi => fi.FoodItemId);

            builder.Entity<FoodItem>()
                   .HasMany(mfi => mfi.MenuFoodItems)
                   .WithOne(m => m.FoodItem)
                   .HasForeignKey(mfi => mfi.FoodItemId);

            /*

            // Configure relationships for MenuFoodItem
            builder.Entity<MenuFoodItem>()
                   .HasOne(mf => mf.Menu)
                   .WithMany(m => m.MenuFoodItems)
                   .HasForeignKey(mf => mf.MenuId);

            builder.Entity<MenuFoodItem>()
                   .HasOne(mf => mf.FoodItem)
                   .WithMany(fi => fi.MenuFoodItems)
                   .HasForeignKey(mf => mf.FoodItemId);

            */



            // Seed data for development environments
            if (_hostEnv != null && _hostEnv.IsDevelopment())
            {
                builder.Entity<Menu>()
                       .HasData(
                            new Menu { MenuId = 1, MenuName = "Standard Menu" },
                            new Menu { MenuId = 2, MenuName = "Premium Menu" }
                       );

                builder.Entity<FoodItem>()
                       .HasData(
                            new FoodItem { FoodItemId = 1, Description = "Grilled Chicken", UnitPrice = 12.5f },
                            new FoodItem { FoodItemId = 2, Description = "Vegetarian Pasta", UnitPrice = 10.0f },
                            new FoodItem { FoodItemId = 3, Description = "Garden Salad", UnitPrice = 5.5f }
                       );

                builder.Entity<MenuFoodItem>()
                       .HasData(
                            new MenuFoodItem { MenuId = 1, FoodItemId = 1 },
                            new MenuFoodItem { MenuId = 1, FoodItemId = 2 },
                            new MenuFoodItem { MenuId = 2, FoodItemId = 1 },
                            new MenuFoodItem { MenuId = 2, FoodItemId = 3 }
                       );

                builder.Entity<FoodBooking>()
                       .HasData(
                            new FoodBooking { FoodBookingId = 1, ClientReferenceId = 101, NumberOfGuests = 50, MenuId = 1 },
                            new FoodBooking { FoodBookingId = 2, ClientReferenceId = 102, NumberOfGuests = 100, MenuId = 2 }
                       );
            }
        }
    }
}
