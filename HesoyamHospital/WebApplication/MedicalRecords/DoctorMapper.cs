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
    }
}
