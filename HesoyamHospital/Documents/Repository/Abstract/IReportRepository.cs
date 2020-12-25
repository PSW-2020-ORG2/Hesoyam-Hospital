using Backend.Model.PatientModel;
using System.Collections.Generic;

namespace Documents.Repository.Abstract
{
    public interface IReportRepository : IRepository<Report, long>
    {
        public IEnumerable<Report> GetAllByPatient(long patientId);
    }
}
