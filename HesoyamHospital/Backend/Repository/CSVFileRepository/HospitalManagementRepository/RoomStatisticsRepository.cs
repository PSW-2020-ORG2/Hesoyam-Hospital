using Backend.Model.ManagerModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Backend.Repository.CSVFileRepository.Csv;
using Backend.Repository.CSVFileRepository.Csv.IdGenerator;
using Backend.Repository.CSVFileRepository.Csv.Stream;
using Backend.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repository.CSVFileRepository.HospitalManagementRepository
{
    public class RoomStatisticsRepository : CSVRepository<StatsRoom, long>, IRoomStatisticsRepository, IEagerCSVRepository<StatsRoom, long>
    {
        private const string ENTITY_NAME = "Room Statistics Repository";
        private IRoomRepository _roomRepository;
        public RoomStatisticsRepository(ICSVStream<StatsRoom> stream, ISequencer<long> sequencer, IRoomRepository roomRepository) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<StatsRoom>())
        {
            _roomRepository = roomRepository;
        }

        public IEnumerable<StatsRoom> GetAllEager()
        {
            IEnumerable<StatsRoom> allStats = GetAll();
            IEnumerable<Room> rooms = _roomRepository.GetAll();

            BindStatsWithRooms(allStats, rooms);

            return allStats;
        }

        public void BindStatsWithRooms(IEnumerable<StatsRoom> allStats, IEnumerable<Room> rooms)
            => allStats.ToList().ForEach(stat => stat.Room = GetRoomById(rooms, stat.Room.GetId()));

        private Room GetRoomById(IEnumerable<Room> rooms, long v)
            => rooms.SingleOrDefault(room => room.GetId() == v);

        public StatsRoom GetEager(long id)
            => GetAllEager().SingleOrDefault(stat => stat.GetId() == id);

        public IEnumerable<StatsRoom> GetRoomStatistics()
            => GetAll();

        public StatsRoom GetStatisticsByRoom(Room room)
            => GetAll().SingleOrDefault(stat => stat.Room.GetId() == room.GetId());

    }
}
