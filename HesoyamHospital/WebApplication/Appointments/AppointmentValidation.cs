using Backend.Model.PatientModel;
using System;

namespace WebApplication.Appointments
{
    public class AppointmentValidation
    {
        private int _hoursToCancelBeforeAppointment;

        public AppointmentValidation(int hoursToCancelBeforeAppointment)
        {
            _hoursToCancelBeforeAppointment = hoursToCancelBeforeAppointment;
        }

        public bool IsPossibleToCancelAppointment(Appointment appointment, long patientId)
        => !appointment.TimeInterval.IsInThePast()
            && !appointment.TimeInterval.IsDateTimeBetween(DateTime.Now)
            && !appointment.Canceled
            && appointment.Patient.Id == patientId
            && appointment.TimeInterval.EndTime.AddHours(-_hoursToCancelBeforeAppointment) > DateTime.Now;
    }
}
