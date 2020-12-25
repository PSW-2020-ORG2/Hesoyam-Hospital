using Documents.Repository.Abstract;
using Documents.Repository.SQLRepository.Base;
using Backend.Model.UserModel;
using System.Linq;

namespace Documents.Repository
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