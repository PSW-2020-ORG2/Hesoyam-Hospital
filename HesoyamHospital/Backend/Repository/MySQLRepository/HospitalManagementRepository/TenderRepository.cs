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
    public class TenderRepository : MySQLRepository<Tender, long>, ITenderRepository
    {
        private const string ENTITY_NAME = "Tender";
        public TenderRepository(IMySQLStream<Tender> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Tender>())
        {
        }

        public IEnumerable<Tender> GetAllActiveTenders()
            => GetAll().Where(tender => tender.IsActive() == true);
        public IEnumerable<Tender> GetAllUnconcludedTenders()
            => GetAll().Where(tender => tender.Concluded == false && tender.IsActive() == false);
    }
}
