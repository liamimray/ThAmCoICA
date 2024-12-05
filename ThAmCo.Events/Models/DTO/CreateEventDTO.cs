namespace ThAmCo.Events.Models.DTO
{
    public class CreateEventDTO
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string EventType { get; set; }
        public bool IsCancelled { get; set; } = false;

        public int? VenueId { get; set; } // Assume nullable in case venue reservation is optional
    }
}
