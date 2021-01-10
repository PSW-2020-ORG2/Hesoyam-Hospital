using System;

namespace Appointments.DTOs
{
    public class IntervalDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string StartTimeText { get; set; }
        public string DateText { get; set; }

        public IntervalDTO() { }

        public IntervalDTO(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
            StartTimeText = startTime.ToString("HH:mm") + " - " + endTime.ToString("HH:mm");
            DateText = startTime.ToString("dd.MM.yyyy");
        }
    }
}
