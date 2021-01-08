using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourceClasses.Authentication
{
    class BlockPatientEvent
    {
        public long Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Username { get; set; }

        public BlockPatientEvent() { }
        public BlockPatientEvent(string username) 
        {
            Username = username;
        }
        public BlockPatientEvent(string username, DateTime timestamp) 
        {
            Username = username;
            Timestamp = timestamp;
        }
    }
}
