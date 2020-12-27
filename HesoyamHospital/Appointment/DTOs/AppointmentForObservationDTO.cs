using Authentication.Model.Util;

namespace Appointments.DTOs
{
    public class AppointmentForObservationDTO
    {
        public long AppointmentId { get; set; }
        public string AppointmentState { get; set; }
        public TimeInterval TimeInterval { get; set; }
        public string Department { get; set; }
        public string DoctorName { get; set; }
        public string RoomNumber { get; set; }
        public bool AbleToFillOutSurvey { get; set; }

        public AppointmentForObservationDTO() { }

        public AppointmentForObservationDTO(long appointmentId, string appointmentState, TimeInterval timeInterval, string department, string doctorName, string roomNumber, bool ableToFillOutSurvey)
        {
            AppointmentId = appointmentId;
            AppointmentState = appointmentState;
            TimeInterval = timeInterval;
            Department = department;
            DoctorName = doctorName;
            RoomNumber = roomNumber;
            AbleToFillOutSurvey = ableToFillOutSurvey;
        }
    }
}
