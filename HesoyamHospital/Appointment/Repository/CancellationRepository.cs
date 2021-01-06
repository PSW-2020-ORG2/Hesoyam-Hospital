using Appointments.Model;
using Appointments.Repository.Abstract;
using Appointments.Repository.SQLRepository.Base;
using System.Collections.Generic;
using System.Linq;

namespace Appointments.Repository
{
    public class CancellationRepository : SQLRepository<Cancellation, long>, ICancellationRepository
    {
        public CancellationRepository(ISQLStream<Cancellation> stream) : base(stream)
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
                    cancellationCounts.TryGetValue(cancellation.Appointment.PatientId, out int currentCount);
                    cancellationCounts[cancellation.Appointment.PatientId] = currentCount + 1;
                }
            }
            return cancellationCounts;
        }
    }
}
