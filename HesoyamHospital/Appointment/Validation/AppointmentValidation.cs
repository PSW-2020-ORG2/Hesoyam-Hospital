using Appointments.Model;

namespace Appointments.Validation
{
    public class AppointmentValidation
    {
        public bool IsPossibleToCancelAppointment(Appointment appointment, long patientId)
        =>  appointment.CanBeCancelled() && appointment.PatientId == patientId;
    }
}
