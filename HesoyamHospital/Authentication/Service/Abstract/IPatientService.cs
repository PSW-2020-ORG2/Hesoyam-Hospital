using Authentication.Model;

namespace Authentication.Service.Abstract
{
    public interface IPatientService : IService<Patient, long>
    {
        public Patient Activate(long id);
        public Patient GetByUsername(string username);
        public Patient ChangeSelectedDoctor(long doctorId, long patientId);
        public Patient BlockPatient(Patient patient);
        public long GetTimeTableForSelectedDoctor(long id);
        public string GetUsername(long id);
        public string GetFullName(long id);
        public bool IsBlocked(long id);
        public long GetSelectedDoctor(long id);
    }
}
