using Authentication.Model.UserModel;
using System.Collections.Generic;

namespace Appointments.Repository.Abstract
{
    public interface IDoctorRepository : IRepository<Doctor, long>
    {
        public IEnumerable<Doctor> GetDoctorByType(DoctorType doctorType);
    }
}