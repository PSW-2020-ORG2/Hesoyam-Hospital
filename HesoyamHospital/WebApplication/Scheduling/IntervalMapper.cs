using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Scheduling
{
    public static class IntervalMapper
    {
        public static IntervalDTO DateTimeToIntervalDTO(DateTime dateTime)
        {
            return new IntervalDTO(dateTime, dateTime.AddMinutes(AppointmentMapper.AppointmentDurationMinutes));
        }

        public static List<IntervalDTO> DateTimesToIntervalDTOs(List<DateTime> dateTimes)
        {
            List<IntervalDTO> dtos = new List<IntervalDTO>();
            foreach(DateTime dateTime in dateTimes)
            {
                dtos.Add(DateTimeToIntervalDTO(dateTime));
            }
            return dtos;
        }
    }
}
