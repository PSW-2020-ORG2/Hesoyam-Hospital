using Backend.Model.DoctorModel;
using Backend.Model.UserModel;
using Feedbacks.Repository;
using Feedbacks.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedbacks.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly DoctorRepository _doctorRepository;

        public DoctorService(DoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

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
