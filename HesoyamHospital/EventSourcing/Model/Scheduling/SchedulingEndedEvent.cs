using System;

namespace EventSourcing.Model.Scheduling
{
    public class SchedulingEndedEvent
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string PatientUsername { get; set; }
        public SchedulingOutcome Outcome { get; set; }

        public SchedulingEndedEvent() { }
        public SchedulingEndedEvent(DateTime timestamp, string patientUsername, SchedulingOutcome outcome)
        {
            Timestamp = timestamp;
            PatientUsername = patientUsername;
            Outcome = outcome;
        }
    }
}
