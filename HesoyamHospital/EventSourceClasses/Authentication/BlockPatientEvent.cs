using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace EventSourceClasses.Authentication
{
    public class BlockPatientEvent : Event
    {
        private readonly string LOG_END_POINT = Environment.GetEnvironmentVariable("blockPatientEventLoggerURL");
        public long Id { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
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

        public override void Log()
        {
            try
            {
                LogObject(LOG_END_POINT);
            }
            catch (JsonSerializationException e)
            {
                Console.WriteLine("Serilization error occured during block patient event logging.");
            }
        }
    }
}
