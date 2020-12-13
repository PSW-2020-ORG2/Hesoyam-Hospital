using System;

namespace WebApplication.Scheduling
{
    public class PriorityDTO
    {
        public long Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool PriorityDoctor { get; set; }

        public PriorityDTO() { }
        public PriorityDTO(long id, DateTime startDate, DateTime endDate, bool priorityDoctor)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            PriorityDoctor = priorityDoctor;
        }
    }
}
