using System;

namespace Appointments.DTOs
{
    public class PriorityIntervalDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string StartTimeText { get; set; }
        public string DateText { get; set; }
        public long DoctorId { get; set; }
        public string FullName { get; set; }

        public PriorityIntervalDTO() { }

        public PriorityIntervalDTO(DateTime startTime, DateTime endTime, long doctorId, string fullName)
        {
            StartTime = startTime;
            EndTime = endTime;
            StartTimeText = startTime.ToString("HH:mm") + " - " + endTime.ToString("HH:mm");
            DateText = startTime.ToString("dd.MM.yyyy");
            DoctorId = doctorId;
            FullName = fullName;
        }
    }
}
