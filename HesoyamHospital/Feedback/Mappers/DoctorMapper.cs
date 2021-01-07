using Feedbacks.DTOs;

namespace Feedbacks.Mappers
{
    public static class DoctorMapper
    {
        public static DoctorDTO DoctorToDoctorDTO(long doctorId, string doctorUsername)
        {
            return new DoctorDTO(doctorId, doctorUsername);
        }
    }
}
