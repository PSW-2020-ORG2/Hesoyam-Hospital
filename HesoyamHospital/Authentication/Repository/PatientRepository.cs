using Authentication.Repository.Abstract;
using Authentication.Repository.SQLRepository.Base;
using Authentication.Model;
using System.Linq;

namespace Authentication.Repository
{
    public class PatientRepository : SQLRepository<Patient, long>, IPatientRepository
    {
        public PatientRepository(ISQLStream<Patient> stream) : base(stream)
        {
        }

        public Patient GetPatientByUsername(string username)
            => GetAll().SingleOrDefault(patient => patient.UserName == username);
    }
}
