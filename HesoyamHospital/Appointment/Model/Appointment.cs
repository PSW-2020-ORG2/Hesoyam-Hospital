using Appointments.Util;
using System;

namespace Appointments.Model
{
    public class Appointment
    {
        public long Id { get; set; }
        public bool Canceled { get; set; }
        public bool AbleToFillOutSurvey { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public virtual TimeInterval TimeInterval { get; set; }
        public long PatientId { get; set; }
        public long DoctorInAppointmentId { get; set; }
        public long RoomId { get; set; }

        private const int _hoursToCancelBeforeAppointment = 48;

        public Appointment(long id) => Id = id;

        public Appointment(long id, long doctorId, long patientId, long roomId, AppointmentType appointmentType, TimeInterval timeInterval)
        {
            Id = id;
            DoctorInAppointmentId = doctorId;
            PatientId = patientId;
            RoomId = roomId;
            AppointmentType = appointmentType;
            TimeInterval = timeInterval;
            Canceled = false;
        }

        public Appointment(long id, long doctorId, long patientId, long roomId, AppointmentType appointmentType, TimeInterval timeInterval, bool canceled)
        {
            Id = id;
            DoctorInAppointmentId = doctorId;
            PatientId = patientId;
            RoomId = roomId;
            AppointmentType = appointmentType;
            TimeInterval = timeInterval;
            Canceled = canceled;
        }

        public Appointment(long doctorId, long patientId, long roomId, AppointmentType appointmentType, TimeInterval timeInterval)
        {
            DoctorInAppointmentId = doctorId;
            PatientId = patientId;
            RoomId = roomId;
            AppointmentType = appointmentType;
            TimeInterval = timeInterval;
            Canceled = false;
        }

        public Appointment()
        {
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        public bool IsCompleted()
            => TimeInterval.EndTime <= DateTime.Now;

        public bool IsInFuture()
            => TimeInterval.StartTime >= DateTime.Now;

        public bool CanBeCancelled()
            => TimeInterval.EndTime.AddHours(-_hoursToCancelBeforeAppointment) > DateTime.Now;

        public override bool Equals(object obj)
        {
            var appointment = obj as Appointment;
            return appointment != null && Id == appointment.Id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }
    }
}