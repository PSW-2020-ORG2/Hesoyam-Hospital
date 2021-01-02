using Authentication.Model.UserModel;
using Authentication.Repository.Abstract;
using Authentication.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Authentication.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public Doctor Create(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<long> GetAllDoctorIds()
            => _doctorRepository.GetAll().Select(doctor => doctor.Id);

        public Doctor GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetDoctorByType(DoctorType doctorType)
            => _doctorRepository.GetDoctorByType(doctorType);

        public string GetUsername(long doctorId)
            => _doctorRepository.GetByID(doctorId).UserName;

        public string GetFullName(long doctorId)
            => _doctorRepository.GetByID(doctorId).FullName;

        public void Update(Doctor entity)
        {
            throw new NotImplementedException();
        }
    }
}
