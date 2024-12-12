namespace ThAmCo.Events.Models
{
    public class GuestBooking
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public bool IsAttending { get; set; } = true;
        public int GuestId { get; set; }
        public Guest Guest { get; set; }
    }
}