using Backend;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Scheduling
{
    public static class AppointmentMapper
    {
        public const long AppointmentDurationMinutes = 30;
        public static Appointment AppointmentDtoToAppointment(AppointmentDTO dto)
        {
            Appointment appointment = new Appointment();
            Doctor doctorInAppointment = AppResources.getInstance().doctorRepository.GetByID(dto.DoctorId);
            appointment.DoctorInAppointment = doctorInAppointment;
            appointment.Canceled = false;
            appointment.AbleToFillOutSurvey = false;
            appointment.AppointmentType = AppointmentType.checkup;
            appointment.Patient = AppResources.getInstance().patientRepository.GetByID(dto.PatientId);
            appointment.Room = doctorInAppointment.Office;
            appointment.TimeInterval = new TimeInterval();
            appointment.TimeInterval.StartTime = dto.DateAndTime;
            appointment.TimeInterval.EndTime = dto.DateAndTime.AddMinutes(AppointmentDurationMinutes);
            return appointment;
        }
    }
}
