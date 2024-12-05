using ThAmCo.Events.Models;
using ThAmCo.Events.Repositories.Interfaces;
using ThAmCo.Events.Repositories;
using ThAmCo.Events.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Register database context with the framework
builder.Services.AddDbContext<EventsDbContext>();

// Register repositories
builder.Services.AddScoped<IGuestRepository, GuestRepository>();
builder.Services.AddScoped<IGuestBookingRepository, GuestBookingRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IStaffRepository, StaffRepository>();

// Register services
builder.Services.AddScoped<GuestService>();
builder.Services.AddScoped<GuestBookingService>();
builder.Services.AddScoped<StaffService>();

// Register HttpClient and EventsService
builder.Services.AddHttpClient<EventsService>()
    .ConfigureHttpClient(client =>
    {
        client.BaseAddress = new Uri("https://localhost:7011/api");
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();