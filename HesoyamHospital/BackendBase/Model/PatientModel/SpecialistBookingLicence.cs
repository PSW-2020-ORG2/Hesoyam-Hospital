// File:    SpecialistBookingLicence.cs
// Author:  Windows 10
// Created: 15. april 2020 21:47:38
// Purpose: Definition of Class SpecialistBookingLicence

using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract;
using SIMS.Util;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SIMS.Model.PatientModel
{
    public class SpecialistBookingLicence : IIdentifiable<long>
    {
        private long _id;
        private DoctorType _doctorAllowed;
        private int _numberOfAppointments;
        private bool _active;
        public Patient _patient;

        public TimeInterval _timeInterval;
        public List<Doctor> _handsOutLicence;

        //TODO: Constructors

        public SpecialistBookingLicence(long id, DoctorType doctorAllowed, int numberOfAppointments, bool Active, Patient patient, TimeInterval timeInterval, List<Doctor> handsOutLicence) 
        {
            _id = id;
            _doctorAllowed = doctorAllowed;
            _numberOfAppointments = numberOfAppointments;
            _active = Active;
            _patient = patient;
            _timeInterval = timeInterval;
            _handsOutLicence = handsOutLicence;
        }

        public SpecialistBookingLicence (DoctorType doctorAllowed, int numberOfAppointments, bool Active, Patient patient, TimeInterval timeInterval, List<Doctor> handsOutLicence)
        {
            _doctorAllowed = doctorAllowed;
            _numberOfAppointments = numberOfAppointments;
            _active = Active;
            _patient = patient;
            _timeInterval = timeInterval;
            _handsOutLicence = handsOutLicence;
        }


        public long GetId()
        {
            return _id;
        }

        public void SetId(long id)
        {
            _id = id;
        }

        public override bool Equals(object obj)
        {
            var licence = obj as SpecialistBookingLicence;
            return licence != null &&
                   _id == licence._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }
    }
}