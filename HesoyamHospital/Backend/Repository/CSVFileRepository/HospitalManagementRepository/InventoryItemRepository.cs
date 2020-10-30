using Backend.Model.PatientModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Backend.Repository.CSVFileRepository.Csv;
using Backend.Repository.CSVFileRepository.MedicalRepository;
using Backend.Specifications.Converter;
using Backend.Util;
using System;
using System.Collections.Generic;

using Backend.Model.ManagerModel;
using Backend.Model.UserModel;
using Backend.Repository.CSVFileRepository.Csv.IdGenerator;
using Backend.Repository.CSVFileRepository.Csv.Stream;
using Backend.Repository.Sequencer;
using System.Linq;

namespace Backend.Repository.CSVFileRepository.HospitalManagementRepository
{
    public class InventoryItemRepository : CSVRepository<InventoryItem, long>, IInventoryItemRepository, IEagerCSVRepository<InventoryItem, long>
    {
        private const string ENTITY_NAME = "InventoryItem";
        private IRoomRepository _roomRepository;
        public InventoryItemRepository(ICSVStream<InventoryItem> stream, ISequencer<long> sequencer, IRoomRepository roomRepository) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<InventoryItem>())
        {
            _roomRepository = roomRepository;
        }

        public IEnumerable<InventoryItem> GetAllEager()
        {
            IEnumerable<InventoryItem> inventoryItems = GetAll();
            IEnumerable<Room> rooms = _roomRepository.GetAll();

            Bind(inventoryItems, rooms);

            return inventoryItems;
        }

        public InventoryItem GetEager(long id)
            => GetAllEager().ToList().SingleOrDefault(item => item.GetId() == id);


        private void BindInventoryItemsWithRooms(IEnumerable<InventoryItem> inventoryItems, IEnumerable<Room> rooms)
            => inventoryItems.ToList().ForEach(item => item.Room = GetRoomById(rooms, item.Id));

        private Room GetRoomById(IEnumerable<Room> rooms, long id)
            => rooms.ToList().SingleOrDefault(room => room.GetId() == id);

        public void Bind(IEnumerable<InventoryItem> inventoryItems, IEnumerable<Room> rooms)
        {
            BindInventoryItemsWithRooms(inventoryItems, rooms);
        }

        public IEnumerable<InventoryItem> GetInventoryItemsForRoom(Room room)
            => GetAll().ToList().Where(item => item.Room.Equals(room));

        public IEnumerable<InventoryItem> GetInventoryItems()
            => GetAll();
    }
}
