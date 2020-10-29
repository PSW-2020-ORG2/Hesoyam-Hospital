using Controller;
using SIMS.Model.ManagerModel;
using SIMS.Service.HospitalManagementService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Controller.HospitalManagementController
{
    class RoomStatisticsController : IController<StatsRoom, long>
    {

        private RoomStatisticsService _roomStatisticsService;

        public RoomStatisticsController(RoomStatisticsService roomStatisticsServce)
        {
            _roomStatisticsService = roomStatisticsServce;
        }

        public StatsRoom Create(StatsRoom entity)
            => _roomStatisticsService.Create(entity);

        public void Delete(StatsRoom entity)
            => _roomStatisticsService.Delete(entity);

        public IEnumerable<StatsRoom> GetAll()
            => _roomStatisticsService.GetAll();

        public StatsRoom GetByID(long id)
            => _roomStatisticsService.GetByID(id);

        public void Update(StatsRoom entity)
            => _roomStatisticsService.Update(entity);
    }
}
