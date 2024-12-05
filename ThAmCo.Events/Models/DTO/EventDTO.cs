namespace ThAmCo.Events.Models.DTO
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string EventType { get; set; } = string.Empty;
        public bool IsCancelled { get; set; }
        public int? VenueId { get; set; } // Assume nullable in case venue reservation is optional
        public int? FoodBookingId { get; set; }
    }
}