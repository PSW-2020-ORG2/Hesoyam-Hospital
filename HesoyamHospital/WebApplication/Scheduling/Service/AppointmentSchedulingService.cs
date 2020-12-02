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

        public AppointmentSchedulingService(IDoctorRepository doctorRepository, IAppointmentRepository appointmentRepository)
        {
            _doctorRepository = doctorRepository;
            _appointmentRepository = appointmentRepository;
        }
        public Appointment Create(Appointment entity)
        {
            Appointment appointment = _appointmentRepository.Create(entity);
            return appointment;
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

        public List<Doctor> GetDoctorsByType(string type)
        {
            DoctorType doctorType = DoctorMapper.TextToDoctorType(type);
            if (doctorType == DoctorType.UNDEFINED) return null;
            List<Doctor> doctors = _doctorRepository.GetDoctorByType(doctorType).ToList();
            return doctors;
        }

        public IEnumerable<TimeInterval> GetTimesForDoctorAndDate(long id, DateTime date)
        {
            return null;
        }

        public Appointment SaveAppointment(Appointment appointment)
        {
            Doctor doctor = _doctorRepository.GetByID(appointment.DoctorInAppointment.Id);
            if (doctor == null || doctor.TimeTable.GetShiftByDate(appointment.TimeInterval.StartTime) == null) return null;
            doctor.TimeTable.GetShiftByDate(appointment.TimeInterval.StartTime).Appointments.Add(appointment);
            Create(appointment);
            return appointment;
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
