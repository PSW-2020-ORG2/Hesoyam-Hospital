using Authentication.Model.UserModel;
using Feedbacks.DTOs;

namespace Feedbacks.Mappers
{
    public class DoctorMapper
    {
        public static DoctorDTO DoctorToDoctorDTO(Doctor doctor)
        {
            return new DoctorDTO(doctor.Id, doctor.UserName);
        }
    }
}
