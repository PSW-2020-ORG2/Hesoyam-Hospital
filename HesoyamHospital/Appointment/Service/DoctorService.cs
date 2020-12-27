using Appointments.Model.UserModel;
using Appointments.Repository;
using Appointments.Service.Abstract;
using System.Collections.Generic;

namespace Appointments.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly DoctorRepository _doctorRepository;

        public DoctorService(DoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public IEnumerable<Doctor> GetDoctorByType(DoctorType doctorType)
            => _doctorRepository.GetDoctorByType(doctorType);

        public IEnumerable<Doctor> GetAll()
            => _doctorRepository.GetAll();

        public Doctor GetByID(long id)
            => _doctorRepository.GetByID(id);

        public Doctor Create(Doctor entity)
            => _doctorRepository.Create(entity);

        public void Delete(Doctor entity)
            => _doctorRepository.Delete(entity);

        public void Update(Doctor entity)
            => _doctorRepository.Update(entity);
    }
}
