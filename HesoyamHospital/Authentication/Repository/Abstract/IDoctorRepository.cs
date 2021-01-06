using Authentication.Model;
using System.Collections.Generic;

namespace Authentication.Repository.Abstract
{
    public interface IDoctorRepository : IRepository<Doctor, long>
    {
        public IEnumerable<Doctor> GetDoctorByType(DoctorType doctorType);
        public List<long> GetDoctorsIdsByType(DoctorType doctorType);
    }
}
