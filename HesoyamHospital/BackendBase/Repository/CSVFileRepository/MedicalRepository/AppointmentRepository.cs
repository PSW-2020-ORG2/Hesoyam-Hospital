// File:    AppointmentRepository.cs
// Author:  Geri
// Created: 23. maj 2020 18:19:34
// Purpose: Definition of Class AppointmentRepository

using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.HospitalManagementAbstractRepository;
using SIMS.Repository.Abstract.MedicalAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;
using SIMS.Specifications;
using SIMS.Specifications.Converter;
using SIMS.Util;
using System.Collections.Generic;
using System.Linq;

namespace SIMS.Repository.CSVFileRepository.MedicalRepository
{
    public class AppointmentRepository : CSVRepository<Appointment, long>, IAppointmentRepository, IEagerCSVRepository<Appointment, long>
    {
        private const string ENTITY_NAME = "Appointment";
        private IEagerCSVRepository<Patient,UserID> _patientRepository;
        private IEagerCSVRepository<Doctor,UserID> _doctorRepository;
        private IRoomRepository _roomRepository;

        public AppointmentRepository(ICSVStream<Appointment> stream, ISequencer<long> sequencer, IEagerCSVRepository<Patient,UserID> patientRepository, IEagerCSVRepository<Doctor,UserID> doctorRepository, IRoomRepository roomRepository) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Appointment>())
        {
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
            _roomRepository = roomRepository;
        }

        private void Bind(IEnumerable<Appointment> appointments)
        {
            var patients = _patientRepository.GetAllEager();
            BindAppointmentsWithPatient(appointments, patients);

            var doctors = _doctorRepository.GetAllEager();
            BindAppointmentsWithDoctor(appointments, doctors);

            var rooms = _roomRepository.GetAll();
            BindAppointmentsWithRoom(appointments, rooms);
        }

        private void BindAppointmentsWithDoctor(IEnumerable<Appointment> appointments, IEnumerable<Doctor> doctors)
            => appointments.ToList().ForEach(appointment => appointment.DoctorInAppointment = GetDoctorById(doctors,appointment.DoctorInAppointment));

        private void BindAppointmentsWithPatient(IEnumerable<Appointment> appointments, IEnumerable<Patient> patients)
            => appointments.ToList().ForEach(appointment => appointment.Patient = GetPatientById(patients, appointment.Patient));

        private void BindAppointmentsWithRoom(IEnumerable<Appointment> appointments, IEnumerable<Room> rooms)
            => appointments.ToList().ForEach(appointment => appointment.Room = GetRoomById(rooms, appointment.Room));

        public IEnumerable<Appointment> GetPatientAppointments(Patient patient)
            => GetAllEager().Where(appointment => IsUserIdsEquals(appointment.Patient, patient));

        private bool IsUserIdsEquals(User appointmentUser, User selectedUser)
            => appointmentUser == null ? false : appointmentUser.GetId().Equals(selectedUser.GetId());

        public IEnumerable<Appointment> GetAppointmentsByTime(TimeInterval timeInterval) //Note (Gergo) : Ima vise smisla da trazimo termine koje se sudaraju sa prosledjenim intervalom
            => GetAllEager().Where(appointment => appointment.TimeInterval.IsOverlappingWith(timeInterval));

        public IEnumerable<Appointment> GetAppointmentsByDoctor(Doctor doctor)
            => GetAllEager().Where(appointment => IsUserIdsEquals(appointment.DoctorInAppointment, doctor));

        public IEnumerable<Appointment> GetCanceledAppointments()
            => GetAllEager().Where(appointment => appointment.Canceled == true);

        public IEnumerable<Appointment> GetAppointmentsByRoom(Room room)
            => GetAllEager().Where(appointment => IsRoomIdsEquals(appointment.Room, room));

        private bool IsRoomIdsEquals(Room appointmentRoom, Room selectedRoom)
            => appointmentRoom == null ? false : appointmentRoom.GetId() == selectedRoom.GetId();

        public IEnumerable<Appointment> GetFilteredAppointment(AppointmentFilter appointmentFilter)
        {
            ISpecification<Appointment> specification = new AppointmentSpecificationConverter(appointmentFilter).GetSpecification();
            var appointments = Find(specification);
            Bind(appointments);
            return appointments;            
        }

        public Appointment GetEager(long id)
        {
            var appointment = GetByID(id);

            var patients = _patientRepository.GetAllEager();
            appointment.Patient = GetPatientById(patients, appointment.Patient);

            var doctors = _doctorRepository.GetAllEager();
            appointment.DoctorInAppointment = GetDoctorById(doctors, appointment.DoctorInAppointment);

            var rooms = _roomRepository.GetAll();
            appointment.Room = GetRoomById(rooms, appointment.Room);

            return appointment;
        }

        public IEnumerable<Appointment> GetAllEager()
        {
            IEnumerable<Appointment> appointments = GetAll();
            Bind(appointments);

            return appointments;
        }

        private Doctor GetDoctorById(IEnumerable<Doctor> doctors, Doctor doctorId)
            => doctorId == null ? null : doctors.SingleOrDefault(d => d.GetId().Equals(doctorId.GetId()));

        private Patient GetPatientById(IEnumerable<Patient> patients, Patient patientId)
            => patientId == null ? null : patients.SingleOrDefault(p => p.GetId().Equals(patientId.GetId()));

        private Room GetRoomById(IEnumerable<Room> rooms, Room roomId)
            => roomId == null ? null : rooms.SingleOrDefault(r => r.GetId() == roomId.GetId());

        
    }
}