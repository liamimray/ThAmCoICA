using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Models;

public class EventsDbContext : DbContext
{
    public DbSet<Event> Events { get; set; }
    public DbSet<Guest> Guests { get; set; }
    public DbSet<GuestBooking> GuestBookings { get; set; }
    public DbSet<Staff> StaffMembers { get; set; }
    public DbSet<Staffing> Staffings { get; set; }


    private readonly IHostEnvironment _hostEnv;
    private readonly string DbPath;
    public EventsDbContext(DbContextOptions<EventsDbContext> options, IHostEnvironment env) : base(options)
    {

        _hostEnv = env;
        var folder = Environment.SpecialFolder.MyDocuments;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "ThAmCo.Events.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Event primary key
        builder.Entity<Event>()
               .HasKey(e => e.Id);

        // Guest primary key
        builder.Entity<Guest>()
               .HasKey(g => g.Id);

        // GuestBooking composite key (EventId, GuestId)
        builder.Entity<GuestBooking>()
               .HasKey(gb => new { gb.EventId, gb.GuestId });

        builder.Entity<GuestBooking>()
               .HasOne(gb => gb.Event)
               .WithMany(e => e.GuestBookings)
               .HasForeignKey(gb => gb.EventId);

        builder.Entity<GuestBooking>()
               .HasOne(gb => gb.Guest)
               .WithMany(g => g.GuestBookings)
               .HasForeignKey(gb => gb.GuestId);

        // Staff primary key
        builder.Entity<Staff>()
               .HasKey(s => s.Id);

        // Staffing composite key (EventId, StaffId)
        builder.Entity<Staffing>()
               .HasKey(s => new { s.EventId, s.StaffId });

        builder.Entity<Staffing>()
               .HasOne(s => s.Event)
               .WithMany(e => e.Staffings)
               .HasForeignKey(s => s.EventId);

        builder.Entity<Staffing>()
               .HasOne(s => s.Staff)
               .WithMany(s => s.Staffings)
               .HasForeignKey(s => s.StaffId);

        // Seed data for development environments
        if (_hostEnv != null && _hostEnv.IsDevelopment())
        {
            builder.Entity<Event>()
                   .HasData(
                        new Event { Id = 1, Title = "Annual Gala", Date = DateTime.Now.AddMonths(1), EventType = "Gala", IsCancelled = false },
                        new Event { Id = 2, Title = "Tech Summit", Date = DateTime.Now.AddMonths(2), EventType = "Conference", IsCancelled = false }
                   );

            builder.Entity<Guest>()
                   .HasData(
                        new Guest { Id = 1, Name = "John Doe", Email = "john@example.com"},
                        new Guest { Id = 2, Name = "Jane Smith", Email = "jane@example.com"}
                   );

            builder.Entity<GuestBooking>()
                   .HasData(
                        new GuestBooking { EventId = 1, GuestId = 1 },
                        new GuestBooking { EventId = 1, GuestId = 2 }
                   );

            builder.Entity<Staff>()
                   .HasData(
                        new Staff { Id = 1, Name = "Alice Johnson", Role = "Coordinator", IsFirstAider = true },
                        new Staff { Id = 2, Name = "Bob Brown", Role = "Security", IsFirstAider = false }
                   );

            builder.Entity<Staffing>()
                   .HasData(
                        new Staffing { EventId = 1, StaffId = 1 },
                        new Staffing { EventId = 1, StaffId = 2 }
                   );
        }
    }
  }