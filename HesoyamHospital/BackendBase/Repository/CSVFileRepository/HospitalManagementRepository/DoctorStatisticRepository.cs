using SIMS.Model.ManagerModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.HospitalManagementAbstractRepository;
using SIMS.Repository.Abstract.UsersAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Repository.CSVFileRepository.HospitalManagementRepository
{
    public class DoctorStatisticRepository : CSVRepository<StatsDoctor, long>, IDoctorStatisticRepository, IEagerCSVRepository<StatsDoctor, long>
    {
        private const string ENTITY_NAME = "Doctor Statistics Repository";
        private IDoctorRepository _doctorRepository;
        public DoctorStatisticRepository(ICSVStream<StatsDoctor> stream, ISequencer<long> sequencer, IDoctorRepository doctorRepository) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<StatsDoctor>())
        {
            _doctorRepository = doctorRepository;
        }

        public IEnumerable<StatsDoctor> GetAllEager()
        {
            IEnumerable<StatsDoctor> allStats = GetAll();
            IEnumerable<Doctor> doctors = _doctorRepository.GetAll();

            BindStatisticsWithDoctors(allStats, doctors);

            return allStats;
        }

        public void BindStatisticsWithDoctors(IEnumerable<StatsDoctor> allStats, IEnumerable<Doctor> doctors)
            => allStats.ToList().ForEach(stat => stat.Doctor = GetDoctorById(doctors, stat.Doctor.GetId()));

        private Doctor GetDoctorById(IEnumerable<Doctor> doctors, UserID userID)
            => doctors.SingleOrDefault(doctor => doctor.GetId().Equals(userID));

        public IEnumerable<StatsDoctor> GetDoctorStatistics()
            => GetAll();

        public StatsDoctor GetEager(long id)
            => GetAllEager().SingleOrDefault(stat => stat.GetId() == id);

        public IEnumerable<StatsDoctor> GetStatisticsByDoctor(Doctor doctor)
            => GetAll().Where(stat => stat.Doctor.GetId().Equals(doctor));
    }
}
