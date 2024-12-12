namespace ThAmCo.Events.Models
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
        public int TotalBookings => GuestBookings.Count;
        public int ConfirmedAttendees => GuestBookings.Count(gb => gb.IsAttending);
    }
}