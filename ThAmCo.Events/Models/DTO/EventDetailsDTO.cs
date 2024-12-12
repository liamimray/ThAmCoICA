using System;
using System.Collections.Generic;

namespace ThAmCo.Events.Models.DTO
{
    public class EventDetailsDTO
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public List<GuestAttendanceDTO> Attendees { get; set; }
    }
}