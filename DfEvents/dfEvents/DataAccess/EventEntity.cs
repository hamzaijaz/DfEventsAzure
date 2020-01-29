using NPoco;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace dfEvents.DataAccess
{
    [ExcludeFromCodeCoverage]
    [TableName("Event")]
    [PrimaryKey("EventId", AutoIncrement = true)]
    public class EventEntity
    {
        public int EventId { get; set; }
        public string EventIdentity { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public int Rsvp { get; set; }
        public string EventType { get; set; }
        public DateTime EventDate { get; set; }
        public double EventCost { get; set; }
    }
}
