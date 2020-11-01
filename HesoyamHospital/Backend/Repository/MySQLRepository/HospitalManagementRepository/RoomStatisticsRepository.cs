using Backend.Model.ManagerModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repository.MySQLRepository.HospitalManagementRepository
{
    public class RoomStatisticsRepository : MySQLRepository<StatsRoom, long>, IRoomStatisticsRepository, IEagerRepository<StatsRoom, long>
    {
        private const string ENTITY_NAME = "Room Statistics Repository";
        private IRoomRepository _roomRepository;
        public RoomStatisticsRepository(IMySQLStream<StatsRoom> stream, ISequencer<long> sequencer, IRoomRepository roomRepository) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<StatsRoom>())
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
