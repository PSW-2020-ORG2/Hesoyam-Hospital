using Feedbacks.DTOs;

namespace Feedbacks.Mappers
{
    public class DoctorMapper
    {
        public static DoctorDTO DoctorToDoctorDTO(long doctorId, string doctorUsername)
        {
            return new DoctorDTO(doctorId, doctorUsername);
        }
    }
}
