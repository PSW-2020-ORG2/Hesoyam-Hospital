using Backend.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service
{
    public static class PriorityIntervalMapper
    {
        public static PriorityIntervalDTO ToDto(Doctor doctor, DateTime dateTime)
        {
            return new PriorityIntervalDTO(dateTime, dateTime.AddMinutes(AppointmentMapper.AppointmentDurationMinutes), doctor.FullName, doctor.Id);
        }

        public static List<PriorityIntervalDTO> ListToDtoListForOneDoctor(Doctor doctor, List<DateTime> dateTimes)
        {
            List<PriorityIntervalDTO> dtos = new List<PriorityIntervalDTO>();
            foreach (DateTime dateTime in dateTimes)
            {
                dtos.Add(ToDto(doctor, dateTime));
            }
            return dtos;
        }
     }
}
