using Authentication.Model.UserModel;
using System.Collections.Generic;

namespace Authentication.Service.Abstract
{
    public interface IDoctorService : IService<Doctor, long>
    {
        public IEnumerable<long> GetAllDoctorIds();
        public string GetUsername(long doctorId);
        public string GetFullName(long doctorId);
        public IEnumerable<Doctor> GetDoctorByType(DoctorType doctorType);
        public List<Doctor> GetDoctorsByType(string type);
        public string GetSpecialization(long id);
        public long GetTimeTableId(long doctorId);
        public List<long> GetSameSpecializationDoctors(long id);
        public long GetOfficeIdByDoctorId(long id);
        public string GetOfficeNumberByDoctorId(long id);
    }
}
