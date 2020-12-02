using Backend.Model.DoctorModel;
using Backend.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.MedicalRecords
{
    public static class DoctorMapper
    {
        public static DoctorDTO DoctorToDoctorDTO(Doctor doctor)
        {
            return (new DoctorDTO(doctor.Id, doctor.FullName));
        }

        public static List<DoctorDTO> DoctorListToDTOList(List<Doctor> doctors)
        {
            List<DoctorDTO> dtos = new List<DoctorDTO>();
            foreach (Doctor doctor in doctors)
            {
                dtos.Add(DoctorToDoctorDTO(doctor));
            }
            return dtos;
        }
        public static DoctorType TextToDoctorType(string type)
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
    }
}
