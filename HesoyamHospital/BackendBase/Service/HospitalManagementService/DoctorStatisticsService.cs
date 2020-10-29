using SIMS.Exceptions;
using SIMS.Model.ManagerModel;
using SIMS.Model.UserModel;
using SIMS.Repository.CSVFileRepository.HospitalManagementRepository;
using SIMS.Service.UsersService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service.HospitalManagementService
{
    class DoctorStatisticsService : IService<StatsDoctor, UserID>
    {

        private DoctorStatisticRepository _doctorStatisticRepository;


        public DoctorStatisticsService(DoctorStatisticRepository doctorStatisticRepository)
        {
            _doctorStatisticRepository = doctorStatisticRepository;

        }

        public StatsDoctor Create(StatsDoctor entity)
        {
            Validate(entity);
            return _doctorStatisticRepository.Create(entity);
        }
        public void Delete(StatsDoctor entity)
            => _doctorStatisticRepository.Delete(entity);

        public IEnumerable<StatsDoctor> GetAll()
            => _doctorStatisticRepository.GetAllEager();

        public StatsDoctor GetByID(UserID id)
            => this.GetAll().SingleOrDefault(stat => stat.GetId().Equals(id));

        public void Update(StatsDoctor entity)
        {
            Validate(entity);
            _doctorStatisticRepository.Update(entity);
        }

        public void Validate(StatsDoctor entity)
        {
            CheckNumAppointments(entity);
            CheckDoctor(entity);
        }

        private void CheckDoctor(StatsDoctor statsDoctor)
        {
            if (statsDoctor.Doctor == null)
            {
                throw new DoctorServiceException("DoctorStatistics - Doctor is not set!");
            }
        }

        private void CheckNumAppointments(StatsDoctor statsDoctor)
        {
            if (statsDoctor.NumberOfAppointments < 0)
            {
                throw new DoctorServiceException("DoctorStatistics - Average appointment number is less than zero!");
            }
        }
    }
}
