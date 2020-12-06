using Backend.Model.PatientModel;
using System;

namespace WebApplication.Appointments
{
    public class AppointmentValidation
    {
        private readonly int hoursToCancelBeforeAppointment = 48;
        public bool IsPossibleToCancelAppointment(Appointment appointment, long patientId)
            => !appointment.TimeInterval.IsInThePast() 
            && !appointment.TimeInterval.IsDateTimeBetween(DateTime.Now) 
            && !appointment.Canceled 
            && appointment.Patient.Id == patientId 
            && appointment.TimeInterval.EndTime.AddHours(hoursToCancelBeforeAppointment) < DateTime.Now;
    }
}
