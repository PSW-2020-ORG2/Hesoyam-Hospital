// File:    Appointment.cs
// Author:  Windows 10
// Created: 15. april 2020 21:19:22
// Purpose: Definition of Class Appointment

using Backend.Model.UserModel;
using System;
using Backend.Repository.Abstract;
using Backend.Util;
using Backend.Exceptions;

namespace Backend.Model.PatientModel
{
    public class Appointment : IIdentifiable<long>
    {
        public long Id { get; set; }
        public bool Canceled { get; set; }
        public bool AbleToFillOutSurvey { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public virtual TimeInterval TimeInterval { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor DoctorInAppointment { get; set; }
        public virtual Room Room { get; set; }

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


      
        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        public bool IsCompleted()
            => TimeInterval.EndTime <= DateTime.Now;

        public bool IsInFuture()
            => TimeInterval.StartTime >= DateTime.Now;

        public override bool Equals(object obj)
        {
            var appointment = obj as Appointment;
            return appointment != null &&
                   Id == appointment.Id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }
    }
}