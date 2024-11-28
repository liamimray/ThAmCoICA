namespace ThAmCo.Events.Data
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string EventType { get; set; }
        public bool IsCancelled { get; set; }

        public int? VenueId { get; set; } // Assume nullable in case venue reservation is optional
        public ICollection<GuestBooking> GuestBookings { get; set; } = new List<GuestBooking>();
        public ICollection<Staffing> Staffings { get; set; } = new List<Staffing>();
    }
}