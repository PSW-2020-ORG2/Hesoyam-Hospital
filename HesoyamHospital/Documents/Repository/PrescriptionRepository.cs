using Authentication.Model.MedicalRecordModel;
using Documents.Repository.Abstract;
using Documents.Repository.SQLRepository.Base;
using System.Collections.Generic;
using System.Linq;

namespace Documents.Repository
{
    public class PrescriptionRepository : SQLRepository<Prescription, long>, IPrescriptionRepository
    {
        public PrescriptionRepository(ISQLStream<Prescription> stream) : base(stream)
        {
        }

        public IEnumerable<Prescription> GetAllByPatient(long patientId)
            => GetAll().Where(presctiprion => presctiprion.Patient.Id == patientId).ToList();
    }
}
