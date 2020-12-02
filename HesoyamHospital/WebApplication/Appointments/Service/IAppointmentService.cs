using Backend.Model.PatientModel;
using Backend.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Appointments.Service
{
    interface IAppointmentService : IService<Appointment, long>
    {
        public IEnumerable<Appointment> GetAllByPatient(long patientId);
    }
}
