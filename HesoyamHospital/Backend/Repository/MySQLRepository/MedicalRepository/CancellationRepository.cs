using Backend.Model.PatientModel;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.Sequencer;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Repository.MySQLRepository.MedicalRepository
{
    public class CancellationRepository : MySQLRepository<Cancellation, long>, ICancellationRepository
    {
        private const string ENTITY_NAME = "Cancellation";
        public CancellationRepository(IMySQLStream<Cancellation> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Cancellation>())
        {
        }

        public Dictionary<long, int> GetCancelledCountForPatients()
        {
            Dictionary<long, int> cancellationCounts = new Dictionary<long, int>();
            List<Cancellation> cancelledAppointments = GetAll().ToList();
            if (cancelledAppointments == null || cancelledAppointments.Count == 0) return new Dictionary<long, int>();
            foreach (Cancellation cancellation in cancelledAppointments)
            {
                if (cancellation.InPreviousMonth())
                {
                    cancellationCounts.TryGetValue(cancellation.Appointment.Patient.Id, out int currentCount);
                    cancellationCounts[cancellation.Appointment.Patient.Id] = currentCount + 1;
                }
            }
            return cancellationCounts;
        }
    }
}
