using Authentication.Model.UserModel;
using Authentication.Repository.Abstract;
using Authentication.Repository.SQLRepository.Base;
using System.Collections.Generic;
using System.Linq;

namespace Authentication.Repository
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
