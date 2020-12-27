using Appointments.Model.UserModel;
using Appointments.Model.Util;
using System;

namespace Appointments.Model.ScheduleModel
{
    public class Appointment
    {
        public long Id { get; set; }
        public bool Canceled { get; set; }
        public bool AbleToFillOutSurvey { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public virtual TimeInterval TimeInterval { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor DoctorInAppointment { get; set; }
        public virtual Room Room { get; set; }

        private const int _hoursToCancelBeforeAppointment = 48;

        public Appointment(long id) => Id = id;

        public Appointment(long id, Doctor doctor, Patient patient, Room room, AppointmentType appointmentType, TimeInterval timeInterval)
        {
            Id = id;
            DoctorInAppointment = doctor;
            Patient = patient;
            Room = room;
            AppointmentType = appointmentType;
            TimeInterval = timeInterval;
            Canceled = false;
        }

        public Appointment(long id, Doctor doctor, Patient patient, Room room, AppointmentType appointmentType, TimeInterval timeInterval, bool canceled)
        {
            Id = id;
            DoctorInAppointment = doctor;
            Patient = patient;
            Room = room;
            AppointmentType = appointmentType;
            TimeInterval = timeInterval;
            Canceled = canceled;
        }

        public Appointment(Doctor doctor,Patient patient,Room room,AppointmentType appointmentType,TimeInterval timeInterval)
        {
            DoctorInAppointment = doctor;
            Patient = patient;
            Room = room;
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