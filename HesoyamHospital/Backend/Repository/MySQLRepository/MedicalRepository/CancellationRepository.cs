using Backend.Model.PatientModel;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.Sequencer;

namespace Backend.Repository.MySQLRepository.MedicalRepository
{
    public class CancellationRepository : MySQLRepository<Cancellation, long>, ICancellationRepository
    {
        private const string ENTITY_NAME = "Cancellation";
        public CancellationRepository(IMySQLStream<Cancellation> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Cancellation>())
        {
        }
    }
}
