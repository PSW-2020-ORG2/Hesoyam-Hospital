using Appointments.Model.UserModel;
using System.Collections.Generic;

namespace Appointments.Service.Abstract
{
    public interface IDoctorService : IService<Doctor, long>
    {
        public IEnumerable<Doctor> GetDoctorByType(DoctorType doctorType);
    }
}
