// File:    HospitalRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:33:41
// Purpose: Definition of Class HospitalRepository

using System;
using System.Collections.Generic;
using System.Linq;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.HospitalManagementAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;

namespace SIMS.Repository.CSVFileRepository.HospitalManagementRepository
{
    public class HospitalRepository : CSVRepository<Hospital, long>, IHospitalRepository, IEagerCSVRepository<Hospital, long>
    {
        private const string ENTITY_NAME = "Hospital";
        private IRoomRepository _roomRepository;
        private IEagerCSVRepository<Doctor, UserID> _doctorRepository;
        private IEagerCSVRepository<Manager, UserID> _managerRepository;
        private IEagerCSVRepository<Secretary, UserID> _secretaryRepository;

        public IEagerCSVRepository<Doctor, UserID> DoctorRepository { get => _doctorRepository; set => _doctorRepository = value; }
        public IEagerCSVRepository<Manager, UserID> ManagerRepository { get => _managerRepository; set => _managerRepository = value; }
        public IEagerCSVRepository<Secretary, UserID> SecretaryRepository { get => _secretaryRepository; set => _secretaryRepository = value; }

        public HospitalRepository(ICSVStream<Hospital> stream, ISequencer<long> sequencer, IRoomRepository roomRepository) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Hospital>())
        {
            _roomRepository = roomRepository;
        }

        private void BindHospitalWithRooms(IEnumerable<Hospital> hospitals, IEnumerable<Room> rooms)
            => hospitals.ToList().ForEach(hospital =>
            {
                hospital.Room = GetRoomsByIds(rooms, hospital.Room.Select(room => room.GetId()));
            });

        private List<Room> GetRoomsByIds(IEnumerable<Room> rooms, IEnumerable<long> ids)
            => rooms.ToList().Where(room => ids.Contains(room.GetId())).ToList();

        public IEnumerable<Hospital> GetHospitalByLocation(Location location)
            => GetAll().ToList().Where(hospital => hospital.Address == null ? false : hospital.Address.Location.Equals(location));

        public Hospital GetEager(long id)
            => GetAllEager().ToList().SingleOrDefault(hospital => hospital.GetId() == id);

        public IEnumerable<Hospital> GetAllEager()
        {
            IEnumerable<Hospital> hospitals = GetAll();
            IEnumerable<Room> rooms = _roomRepository.GetAll();

            BindHospitalWithRooms(hospitals, rooms);

            IEnumerable<Employee> doctors = _doctorRepository.GetAllEager();
            IEnumerable<Employee> managers = _managerRepository.GetAllEager();
            IEnumerable<Employee> secretaries = _secretaryRepository.GetAllEager();
            IEnumerable<Employee> employees = doctors.Concat(managers).Concat(secretaries);

            BindHospitalWithEmployees(hospitals, employees);

            return hospitals;
        }

        private void BindHospitalWithEmployees(IEnumerable<Hospital> hospitals, IEnumerable<Employee> employees)
            => hospitals.ToList().ForEach(hospital =>
            {
                hospital.Employee = GetEmployeesByIds(employees, hospital.Employee.Select(em => em.GetId()));
            });

        private List<Employee> GetEmployeesByIds(IEnumerable<Employee> employees, IEnumerable<UserID> ids)
            => employees.ToList().Where(em => ids.Contains(em.GetId())).ToList();
    }
}