using Controller;
using SIMS.Model.ManagerModel;
using SIMS.Model.UserModel;
using SIMS.Service.HospitalManagementService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Controller.HospitalManagementController
{
    class DoctorStatisticsController : IController<StatsDoctor, UserID>
    {

        DoctorStatisticsService _doctorStatisticsService;

        public DoctorStatisticsController(DoctorStatisticsService doctorStatisticsService)
        {
            _doctorStatisticsService = doctorStatisticsService;
        }

        public StatsDoctor Create(StatsDoctor entity)
            => _doctorStatisticsService.Create(entity);

        public void Delete(StatsDoctor entity)
            => _doctorStatisticsService.Delete(entity);

        public IEnumerable<StatsDoctor> GetAll()
            => _doctorStatisticsService.GetAll();

        public StatsDoctor GetByID(UserID id)
            => _doctorStatisticsService.GetByID(id);

        public void Update(StatsDoctor entity)
            => _doctorStatisticsService.Update(entity);
    }
}
