using System;

namespace Backend.DTOs
{
    public class PriorityIntervalDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string DoctorName { get; set; }

        public long DoctorId { get; set; }

        public bool Priority { get; set; }

        public PriorityIntervalDTO(DateTime startTime, DateTime endTime, string doctorName, long doctorId, bool priority)
        {
            StartTime = startTime;
            EndTime = endTime;
            DoctorName = doctorName;
            DoctorId = doctorId;
            Priority = priority;
        }

        public PriorityIntervalDTO(DateTime startTime, DateTime endTime, string doctorName, bool priority)
        {
            StartTime = startTime;
            EndTime = endTime;
            DoctorName = doctorName;
            Priority = priority;
        }

        public PriorityIntervalDTO(DateTime startTime, DateTime endTime, string doctorName, long doctorId)
        {
            StartTime = startTime;
            EndTime = endTime;
            DoctorName = doctorName;
            DoctorId = doctorId;
        }
    }
}
