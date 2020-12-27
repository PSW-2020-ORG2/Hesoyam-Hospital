using Appointments.Model.UserModel;
using Appointments.Repository.Abstract;
using Appointments.Repository.SQLRepository.Base;
using System.Linq;

namespace Appointments.Repository
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
