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
            => _doctorRepository.GetByID(id);

        public long GetTimeTableId(long doctorId)
            => _doctorRepository.GetByID(doctorId).TimeTable.Id;

        public List<Doctor> GetDoctorsByType(string type)
        {
            DoctorType doctorType = TextToDoctorType(type);
            if (doctorType == DoctorType.UNDEFINED) return new List<Doctor>();
            List<Doctor> doctors = _doctorRepository.GetDoctorByType(doctorType).ToList();
            return doctors;
        }

        private DoctorType TextToDoctorType(string type)
        {
            try
            {
                DoctorType DoctorTypeEnum = (DoctorType)Enum.Parse(typeof(DoctorType), type, false);
                if (Enum.IsDefined(typeof(DoctorType), DoctorTypeEnum))
                    return DoctorTypeEnum;
                else
                    return DoctorType.UNDEFINED;
            }
            catch (ArgumentException)
            {
                return DoctorType.UNDEFINED;
            }
        }

        public string GetSpecialization(long id)
            => _doctorRepository.GetByID(id).Specialisation.ToString();

        public long GetOfficeIdByDoctorId(long id)
            => _doctorRepository.GetByID(id).Office.Id;

        public string GetOfficeNumberByDoctorId(long id)
            => _doctorRepository.GetByID(id).Office.RoomNumber;

        public List<long> GetSameSpecializationDoctors(long id)
            => _doctorRepository.GetDoctorsIdsByType(_doctorRepository.GetByID(id).Specialisation).ToList();

        public IEnumerable<Doctor> GetDoctorByType(DoctorType doctorType)
            => _doctorRepository.GetDoctorByType(doctorType).ToList();

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
