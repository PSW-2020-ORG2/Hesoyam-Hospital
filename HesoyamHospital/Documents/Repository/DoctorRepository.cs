using Backend.Model.DoctorModel;
using Backend.Model.UserModel;
using Documents.Repository.Abstract;
using Documents.Repository.SQLRepository.Base;
using System.Collections.Generic;
using System.Linq;

namespace Documents.Repository
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
