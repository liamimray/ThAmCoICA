namespace ThAmCo.Events.Models.DTO
{
    public class GuestAttendanceDTO
    {
        public int GuestId { get; set; }
        public string GuestName { get; set; }
        public bool IsAttending { get; set; }
    }
}