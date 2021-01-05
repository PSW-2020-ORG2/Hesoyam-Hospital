using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSourcing.Model
{
    public abstract class Event
    {
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerat‌ed(System.ComponentM‌​odel.DataAnnotations‌​.Schema.DatabaseGeneratedOp‌​tion.None)]
        public int Id { get; set; }
        public DateTime Timestamp;

        public Event() { }
        

        public Event(DateTime timestamp)
        {
            Timestamp = timestamp;
        }





    }
}
