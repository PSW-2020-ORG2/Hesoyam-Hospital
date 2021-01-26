using Backend;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Service.UsersService;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicEditor.DTOs
{
    public static class ScheduledAppointmentMapper
    {
        public static List<ScheduledAppointmentDTO> ScheduledAppointmentToAppointmentDto(List<Appointment> appointments)
        {
            List<ScheduledAppointmentDTO> appointmentsDto = new List<ScheduledAppointmentDTO>();

            foreach (Appointment a in appointments)
            {
                appointmentsDto.Add(new ScheduledAppointmentDTO(a.Id,a.TimeInterval.StartTime, a.DoctorInAppointment.Id));
            }

            return appointmentsDto;
        }
    }
}
