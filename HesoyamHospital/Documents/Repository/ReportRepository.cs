using Backend.Model.PatientModel;
using Documents.Repository.Abstract;
using Documents.Repository.SQLRepository.Base;
using System.Collections.Generic;
using System.Linq;

namespace Documents.Repository
{
    public class ReportRepository : SQLRepository<Report, long>, IReportRepository
    {
        public ReportRepository(ISQLStream<Report> stream) : base(stream)
        {
        }

        public IEnumerable<Report> GetAllByPatient(long patientId)
            => (GetAll().Where(report => report.Patient.Id == patientId)).ToList();
    }
}