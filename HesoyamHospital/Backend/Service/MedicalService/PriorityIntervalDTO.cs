using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.MedicalService
{
    public class PriorityIntervalDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string DoctorName { get; set; }

        public bool Priority { get; set; }

        public PriorityIntervalDTO(DateTime startTime, DateTime endTime, string doctorName, bool priority)
        {
            StartTime = startTime;
            EndTime = endTime;
            DoctorName = doctorName;
            Priority = priority;
        }
    }
}
