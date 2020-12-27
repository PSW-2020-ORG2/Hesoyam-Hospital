using Appointments.Model.UserModel;
using Appointments.Repository.Abstract;
using Appointments.Repository.SQLRepository.Base;
using System.Collections.Generic;
using System.Linq;

namespace Appointments.Repository
{
    public class DoctorRepository : SQLRepository<Doctor, long>, IDoctorRepository
    {
        public DoctorRepository(ISQLStream<Doctor> stream) : base(stream)
        {
        }

        public IEnumerable<Doctor> GetDoctorByType(DoctorType doctorType)
            => _stream.ReadAll().Where(doctor => doctor.Specialisation == doctorType);
    }
}
