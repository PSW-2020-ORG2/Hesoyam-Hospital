using Medicines.Model;
using Medicines.Repository.Abstract;
using Medicines.Repository.SQLRepository.Base;
using Medicines.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicines.Repository
{
    public class TherapyRepository : SQLRepository<Therapy, long>, ITherapyRepository
    {
        public TherapyRepository(ISQLStream<Therapy> stream) : base(stream)
        {
        }

        public IEnumerable<Therapy> GetTherapyByDatePrescribed(TimeInterval dateRange)
            => GetAll().Where(therapy => dateRange.IsDateTimeBetween(therapy.Prescription.DateCreated));
    }
}
