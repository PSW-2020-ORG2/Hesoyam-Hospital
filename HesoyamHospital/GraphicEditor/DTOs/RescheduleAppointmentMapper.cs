using Backend.Model.PatientModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicEditor.DTOs
{
    public static class RescheduleAppointmentMapper
    {
        public static List<RescheduleAppointmentDTO> AppointmentToRescheduleAppointmentDto(Dictionary<Appointment, double> appointmentsForRescheduling)
        {
            List<RescheduleAppointmentDTO> rescheduleAppointmentDTOs = new List<RescheduleAppointmentDTO>();

            foreach(Appointment a in appointmentsForRescheduling.Keys)
            {
                rescheduleAppointmentDTOs.Add(new RescheduleAppointmentDTO(a.Id, a.DoctorInAppointment.FullName, a.Room.Id, appointmentsForRescheduling[a]));
            }

            return rescheduleAppointmentDTOs;
        }

    }
}
