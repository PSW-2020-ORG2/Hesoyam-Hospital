using System.Collections.Generic;
using Backend.Model.DoctorModel;
using Backend.Model.UserModel;
using Backend.Repository.MySQLRepository.UsersRepository;
using Backend.Util;

namespace Backend.Service.UsersService
{
    public class DoctorService : IService<Doctor, long>
    {
        private readonly DoctorRepository _doctorRepository;
        private readonly UserValidation _userValidation;

        public DoctorService(DoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
            _userValidation = new UserValidation();
        }

        public IEnumerable<Doctor> GetDoctorByType(DoctorType doctorType)
            => _doctorRepository.GetDoctorByType(doctorType);

        public IEnumerable<Doctor> GetFilteredDoctors(Util.DoctorFilter filter)
            => _doctorRepository.GetFilteredDoctors(filter);

        public IEnumerable<Doctor> GetAll()
            => _doctorRepository.GetAllEager();

        public Doctor GetByID(long id)
              => _doctorRepository.GetByID(id);

        public Doctor Create(Doctor entity)
        {
            Validate(entity);
            return _doctorRepository.Create(entity);
        }

        public void Delete(Doctor entity)
            => _doctorRepository.Delete(entity);
        
        public void Validate(Doctor user)
            => _userValidation.Validate(user);

        public void Update(Doctor entity)
            => _doctorRepository.Update(entity);
    }
}