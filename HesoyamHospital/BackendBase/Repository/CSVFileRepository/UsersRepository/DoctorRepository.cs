// File:    DoctorRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:27:33
// Purpose: Definition of Class DoctorRepository

using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.HospitalManagementAbstractRepository;
using SIMS.Repository.Abstract.UsersAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;
using SIMS.Specifications;
using SIMS.Specifications.Converter;
using SIMS.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIMS.Repository.CSVFileRepository.UsersRepository
{
    public class DoctorRepository : CSVRepository<Doctor, UserID>, IDoctorRepository, IEagerCSVRepository<Doctor, UserID>
    {
        private const string ENTITY_NAME = "Doctor";
        private readonly ITimeTableRepository _timeTableRepository;
        private readonly IHospitalRepository _hospitalRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IUserRepository _userRepository;
        private const string NOT_UNIQUE_ERROR = "Doctor username {0} is not unique!";

        public DoctorRepository(ICSVStream<Doctor> stream, ISequencer<UserID> sequencer, ITimeTableRepository timeTableRepository, IHospitalRepository hospitalRepository, IRoomRepository roomRepository, IUserRepository userRepository)
            : base(ENTITY_NAME, stream, sequencer, new DoctorIdGeneratorStrategy())
        {
            _timeTableRepository = timeTableRepository;
            _hospitalRepository = hospitalRepository;
            _roomRepository = roomRepository;
            _userRepository = userRepository;
        }

        public new Doctor Create(Doctor doctor)
        {
            if (IsUsernameUnique(doctor.UserName))
            {
                doctor.DateCreated = DateTime.Now;
                doctor = base.Create(doctor);
                _userRepository.AddUser(doctor);
                return doctor;
            }
            else
                throw new NotUniqueException(string.Format(NOT_UNIQUE_ERROR, doctor.UserName));
        }

        public new void Update(Doctor doctor)
        {
            _userRepository.Update(doctor);
            base.Update(doctor);
        }

        private bool IsUsernameUnique(string userName)
            => _userRepository.GetByUsername(userName) == null;

        public IEnumerable<Doctor> GetDoctorByType(DoctorType doctorType)
            => _stream.ReadAll().Where(doctor => doctor.DoctorType == doctorType);

        public IEnumerable<Doctor> GetFilteredDoctors(DoctorFilter filter)
        {
            ISpecification<Doctor> specification = new DoctorSpecificationConverter(filter).GetSpecification();
            var doctors = Find(specification);
            Bind(doctors);
            return doctors;
        }

        public Doctor GetEager(UserID id)
        {
            var doctor = GetByID(id);

            var hospitals = _hospitalRepository.GetAll();
            doctor.Hospital = GetHospitalById(doctor.Hospital, hospitals);

            var timetables = _timeTableRepository.GetAll();
            doctor.TimeTable = GetTimeTableById(doctor.TimeTable, timetables);

            var rooms = _roomRepository.GetAll();
            doctor.Office = GetOfficeById(doctor.Office, rooms);

            return doctor;
        }

        private Room GetOfficeById(Room officeId, IEnumerable<Room> rooms)
            => officeId == null ? null : rooms.SingleOrDefault(r => r.GetId() == officeId.GetId());

        private TimeTable GetTimeTableById(TimeTable timeTableId, IEnumerable<TimeTable> timetables)
            => timeTableId == null ? null : timetables.SingleOrDefault(t => t.GetId() == timeTableId.GetId());

        private Hospital GetHospitalById(Hospital hospitalId, IEnumerable<Hospital> hospitals)
            => hospitalId == null ? null : hospitals.SingleOrDefault(h => h.GetId() == hospitalId.GetId());

        public IEnumerable<Doctor> GetAllEager()
        {
            var doctors = GetAll();
            Bind(doctors);
            return doctors;
        }
        private void Bind(IEnumerable<Doctor> doctors)
        {
            var hospitals = _hospitalRepository.GetAll();
            BindDoctorsWithHospitals(doctors, hospitals);

            var timetables = _timeTableRepository.GetAll();
            BindDoctorsWithTimeTables(doctors, timetables);

            var rooms = _roomRepository.GetAll();
            BindDoctorsWithRooms(doctors, rooms);
        }

        private void BindDoctorsWithRooms(IEnumerable<Doctor> doctors, IEnumerable<Room> rooms)
            => doctors.ToList().ForEach(doctor => doctor.Office = GetOfficeById(doctor.Office, rooms));

        private void BindDoctorsWithTimeTables(IEnumerable<Doctor> doctors, IEnumerable<TimeTable> timetables)
            => doctors.ToList().ForEach(doctor => doctor.TimeTable = GetTimeTableById(doctor.TimeTable, timetables));

        private void BindDoctorsWithHospitals(IEnumerable<Doctor> doctors, IEnumerable<Hospital> hospitals)
            => doctors.ToList().ForEach(doctor => doctor.Hospital = GetHospitalById(doctor.Hospital, hospitals));

    }
}