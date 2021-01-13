using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Sourcing.Events
{
    public abstract class Event
    {
        public int Id { get; set; }
        public DateTime Timestamp;


        public Event(DateTime timestamp)
        {
            Timestamp = timestamp;
        }


    }
}
