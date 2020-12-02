using Backend.Model.PatientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Scheduling
{
    public static class AppointmentMapper
    {
        public static Appointment AppointmentDtoToAppointment(AppointmentDTO dto)
        {
            Appointment appointment = new Appointment();
            return appointment;
        }
    }
}
