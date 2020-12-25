using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Service.UsersService;
using Backend.Util;

namespace Backend.DTOs
{
    public static class AppointmentMapper
    {
        public const long AppointmentDurationMinutes = 30;
        private static readonly DoctorService doctorService = AppResources.getInstance().doctorService;

        public static Appointment AppointmentDtoToAppointment(AppointmentDTO dto)
        {
            Doctor doctorInAppointment = doctorService.GetByID(dto.DoctorId);

            return new Appointment(doctorInAppointment, false, true, AppointmentType.checkup, GetRoom(doctorInAppointment), 
                                    new TimeInterval(dto.DateAndTime, dto.DateAndTime.AddMinutes(AppointmentDurationMinutes)));
        }

        private static Room GetRoom(Doctor doctor)
        {
            if (doctor == null || doctor.Office == null) return null;
            return doctor.Office;
        }
    }

}
