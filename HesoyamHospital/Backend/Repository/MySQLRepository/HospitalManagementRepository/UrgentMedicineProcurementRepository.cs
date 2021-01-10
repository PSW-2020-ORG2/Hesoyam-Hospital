using Backend.Model.PharmacyModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.Sequencer;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Repository.MySQLRepository.HospitalManagementRepository
{
    public class UrgentMedicineProcurementRepository : MySQLRepository<UrgentMedicineProcurement, long>, IUrgentMedicineProcurementRepository
    {
        private const string ENTITY_NAME = "UrgentMedicineProcurement";
        public UrgentMedicineProcurementRepository(IMySQLStream<UrgentMedicineProcurement> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<UrgentMedicineProcurement>())
        {
        }

        public IEnumerable<UrgentMedicineProcurement> GetAllUnconcluded()
            => GetAll().Where(medicine => medicine.Concluded == false);
    }
}
