// File:    Appointment.cs
// Author:  Windows 10
// Created: 15. april 2020 21:19:22
// Purpose: Definition of Class Appointment

using SIMS.Model.UserModel;
using System;
using SIMS.Repository.Abstract;
using SIMS.Util;

namespace SIMS.Model.PatientModel
{
    public class Appointment : IIdentifiable<long>
    {
        private long _id;
        private bool _canceled;

        private AppointmentType _appointmentType;
        private TimeInterval _timeInterval;
        private Patient _patient;
        private Doctor _doctorInAppointment;
        public Room _room;

        public Appointment(long id) => _id = id;

        public Appointment(long id, Doctor doctor, Patient patient, Room room, AppointmentType appointmentType, TimeInterval timeInterval)
        {
            _id = id;
            _doctorInAppointment = doctor;
            _patient = patient;
            _room = room;
            _appointmentType = appointmentType;
            _timeInterval = timeInterval;
            _canceled = false;
        }

        public Appointment(long id, Doctor doctor, Patient patient, Room room, AppointmentType appointmentType, TimeInterval timeInterval, bool canceled)
        {
            _id = id;
            _doctorInAppointment = doctor;
            _patient = patient;
            _room = room;
            _appointmentType = appointmentType;
            _timeInterval = timeInterval;
            _canceled = canceled;
        }

        public Appointment(Doctor doctor,Patient patient,Room room,AppointmentType appointmentType,TimeInterval timeInterval)
        {
            _doctorInAppointment = doctor;
            _patient = patient;
            _room = room;
            _appointmentType = appointmentType;
            _timeInterval = timeInterval;
            _canceled = false;
        }


        public long Id { get => _id; set => _id = value; }
        public bool Canceled { get => _canceled; set => _canceled = value; }
        public AppointmentType AppointmentType { get => _appointmentType; set => _appointmentType = value; }
        public TimeInterval TimeInterval { get => _timeInterval; set => _timeInterval = value; }
        public Patient Patient { get => _patient; set => _patient = value; }
        public Room Room { get => _room; set => _room = value; }
        public Doctor DoctorInAppointment { get => _doctorInAppointment; set => _doctorInAppointment = value; }

        public long GetId() => _id;

        public void SetId(long id) => _id = id;

        public bool IsCompleted()
            => TimeInterval.EndTime <= DateTime.Now;

        public bool IsInFuture()
            => TimeInterval.StartTime >= DateTime.Now;

        public override bool Equals(object obj)
        {
            var appointment = obj as Appointment;
            return appointment != null &&
                   _id == appointment._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }
    }
}