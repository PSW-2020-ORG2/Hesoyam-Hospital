// File:    StatsDoctor.cs
// Author:  vule
// Created: 18. april 2020 17:12:34
// Purpose: Definition of Class StatsDoctor

using SIMS.Model.UserModel;
using System;

namespace SIMS.Model.ManagerModel
{
    public class StatsDoctor : Stats
    {
        private double _numberOfAppointments;
        private string _avgAppointmentTime;
        private Doctor _doctor;


        public double NumberOfAppointments {get {return _numberOfAppointments ;} set { _numberOfAppointments = value; }}

        public string AvgAppointmentTime { get { return _avgAppointmentTime; } set { _avgAppointmentTime = value; } }

        public Doctor Doctor { get { return _doctor; } set { } }

        public StatsDoctor(double numberOfAppointments, string avgAppointmentTime, Doctor doctor): base()
        {
            _numberOfAppointments = numberOfAppointments;
            _avgAppointmentTime = avgAppointmentTime;
            _doctor = doctor;
        }

        public StatsDoctor(long id, double numberOfAppointments, string avgAppointmentTime, Doctor doctor) : base(id)
        {
            _numberOfAppointments = numberOfAppointments;
            _avgAppointmentTime = avgAppointmentTime;
            _doctor = doctor;
        }

        public StatsDoctor(long id): base(id)
        {
        }
    }
}