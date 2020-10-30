// File:    StatisticsRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:33:39
// Purpose: Definition of Class StatisticsRepository

using Backend.Model.ManagerModel;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Backend.Repository.CSVFileRepository.Csv;
using Backend.Repository.CSVFileRepository.Csv.IdGenerator;
using Backend.Repository.CSVFileRepository.Csv.Stream;
using Backend.Repository.CSVFileRepository.UsersRepository;
using Backend.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Repository.CSVFileRepository.HospitalManagementRepository
{
    public class StatisticsRepository : CSVRepository<Stats, long>, IStatisticsRepository, IEagerCSVRepository<Stats, long>
    {
        public StatisticsRepository(string entityName, ICSVStream<Stats> stream, ISequencer<long> sequencer) : base(entityName, stream, sequencer, new LongIdGeneratorStrategy<Stats>())
        {
        }

        private void BindStatisticsWithDoctors(IEnumerable<StatsDoctor> statistics, IEnumerable<Doctor> doctors)
            => statistics.ToList().ForEach(stat => stat.Doctor = GetDoctorById(doctors, stat.Doctor.GetId()));

        private Doctor GetDoctorById(IEnumerable<Doctor> doctors, UserID id)
            => doctors.SingleOrDefault(doctor => doctor.GetId().Equals(id));

        private void BindStatisticsWithInventoryItems(IEnumerable<StatsInventory> statistics, IEnumerable<InventoryItem> inventoryItems)
            => statistics.ToList().ForEach(stat => stat.InventoryItem = GetInventoryItemById(inventoryItems, stat.InventoryItem.GetId()));

        private InventoryItem GetInventoryItemById(IEnumerable<InventoryItem> items, long id)
            => items.SingleOrDefault(item => item.GetId() == id);

        private void BindStatisticsWithMedicine(IEnumerable<StatsInventory> statistics, IEnumerable<Medicine> medicine)
            => statistics.ToList().ForEach(stat => stat.Medicine = GetMedicineById(medicine, stat.Medicine.GetId()));

        private Medicine GetMedicineById(IEnumerable<Medicine> medicine, long id)
            => medicine.SingleOrDefault(med => med.Id == id);

        private void BindStatisticsWithRoom(IEnumerable<StatsRoom> statistics, IEnumerable<Room> rooms)
            => statistics.ToList().ForEach(stat => stat.Room = GetRoomById(rooms, stat.Room.GetId()));

        private Room GetRoomById(IEnumerable<Room> rooms, long id)
            => rooms.SingleOrDefault(room => room.GetId() == id);

        public IEnumerable<StatsDoctor> GetDoctorStatistics()
            => (IEnumerable<StatsDoctor>) GetAll().Where(stat => stat.GetType().Equals(new StatsDoctor(100).GetType()));

        public Doctor GetStatisticsByDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public StatsInventory GetStatisticsByItem(Item item)
        {
            throw new NotImplementedException();
        }

        public StatsRoom GetStatisticsByRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StatsRoom> GetRoomStatistics()
        {
            throw new NotImplementedException();
        }

        public StatsInventory GetInventoryStatistics()
        {
            throw new NotImplementedException();
        }

        public Stats GetEager(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Stats> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public RoomRepository roomRepository;
        public MedicineRepository medicineRepository;
        public InventoryRepository inventoryRepository;
        public DoctorRepository doctorRepository;

    }
}