using System;
using System.Collections.Generic;
using System.Text;

namespace dfEvents.Models
{
    public class CreateEventRequest
    {
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public string EventType { get; set; }
        public DateTime EventDate { get; set; }
        public double EventCost { get; set; }
    }
}
