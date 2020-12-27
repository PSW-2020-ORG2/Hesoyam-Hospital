using Authentication.Model.MedicalRecordModel;
using System.Collections.Generic;

namespace Documents.Repository.Abstract
{
    public interface IPrescriptionRepository : IRepository<Prescription, long>
    {
        IEnumerable<Prescription> GetAllByPatient(long patientId);
    }
}
