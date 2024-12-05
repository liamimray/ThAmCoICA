namespace ThAmCo.Events.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsAttending { get; set; }

        public ICollection<GuestBooking> GuestBookings { get; set; } = new List<GuestBooking>();
    }
}