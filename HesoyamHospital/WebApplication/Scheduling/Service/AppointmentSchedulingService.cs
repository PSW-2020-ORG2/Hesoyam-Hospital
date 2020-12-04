using Backend.Model.DoctorModel;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Repository.Abstract.UsersAbstractRepository;
using Backend.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.MedicalRecords;

namespace WebApplication.Scheduling.Service
{
    public class AppointmentSchedulingService : IAppointmentSchedulingService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPatientRepository _patientRepository;
        public readonly long APPOINTMENT_DURATION_MINUTES = 30;

        public AppointmentSchedulingService(IDoctorRepository doctorRepository, IAppointmentRepository appointmentRepository, IPatientRepository patientRepository)
        {
            _doctorRepository = doctorRepository;
            _appointmentRepository = appointmentRepository;
            _patientRepository = patientRepository;
        }
        public Appointment Create(Appointment entity)
        {
            return _appointmentRepository.Create(entity);
        }

        public List<Doctor> GetDoctorsByType(string type)
        {
            DoctorType doctorType = DoctorMapper.TextToDoctorType(type);
            if (doctorType == DoctorType.UNDEFINED) return null;
            List<Doctor> doctors = _doctorRepository.GetDoctorByType(doctorType).ToList();
            return doctors;
        }

        public Appointment SaveAppointment(Appointment appointment)
        {
            Doctor doctor = _doctorRepository.GetByID(appointment.DoctorInAppointment.Id);
            if (doctor == null || doctor.TimeTable.GetShiftByDate(appointment.TimeInterval.StartTime) == null) return null;
            doctor.TimeTable.GetShiftByDate(appointment.TimeInterval.StartTime).Appointments.Add(appointment);
            _doctorRepository.Update(doctor);
            return appointment;
        }

        public IEnumerable<DateTime> GetTimesForDoctorAndDate(long id, DateTime date)
        {
            Doctor doctor = _doctorRepository.GetByID(id);
            if (doctor == null || doctor.TimeTable == null || doctor.TimeTable.GetShiftByDate(date) == null) return new List<DateTime>();
            return doctor.TimeTable.GetShiftByDate(date).GetAvailableTimes(APPOINTMENT_DURATION_MINUTES);
        }

        public IEnumerable<DateTime> GetTimesForSelectedDoctor(Patient patient)
        {
            Doctor doctor = patient.SelectedDoctor;
            if (doctor.TimeTable == null || doctor.TimeTable.Shifts == null) return new List<DateTime>();
            return doctor.TimeTable.GetFirstTenAppointments(APPOINTMENT_DURATION_MINUTES);
        }

        public void Delete(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Appointment GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public void Validate(Appointment entity)
        {
            throw new NotImplementedException();
        }
    }
}
