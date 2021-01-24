using System;

namespace EventSourcing.Model.Scheduling
{
    public class SchedulingStartedEvent
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string PatientUsername { get; set; }

        public SchedulingStartedEvent() { }
        public SchedulingStartedEvent(DateTime timestamp, string patientUsername)
        {
            Timestamp = timestamp;
            PatientUsername = patientUsername;
        }
    }
}
