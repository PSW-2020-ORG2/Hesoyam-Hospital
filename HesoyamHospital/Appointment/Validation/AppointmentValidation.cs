﻿using Backend.Model.PatientModel;

namespace Appointments.Validation
{
    public class AppointmentValidation
    {
        public bool IsPossibleToCancelAppointment(Appointment appointment, long patientId)
        =>  appointment.CanBeCancelled() && appointment.Patient.Id == patientId;
    }
}