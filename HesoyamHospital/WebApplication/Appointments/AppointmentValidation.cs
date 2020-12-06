using Backend.Model.PatientModel;

namespace WebApplication.Appointments
{
    public class AppointmentValidation
    {
        public bool IsPossibleToCancelAppointment(Appointment appointment, long patientId)
        => !appointment.CanBeCancelled()
            && appointment.Patient.Id == patientId;
    }
}
