using Backend.Model.DoctorModel;
using Backend.Model.UserModel;
using System.Collections.Generic;

namespace Documents.Repository.Abstract
{
    public interface IDoctorRepository : IRepository<Doctor, long>
    {
        public IEnumerable<Doctor> GetDoctorByType(DoctorType doctorType);
    }
}
