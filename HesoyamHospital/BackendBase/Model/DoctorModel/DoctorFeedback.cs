// File:    DoctorFeedback.cs
// Author:  Geri
// Created: 18. april 2020 20:50:38
// Purpose: Definition of Class DoctorFeedback

using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;

namespace SIMS.Model.DoctorModel
{
    public class DoctorFeedback : Feedback
    {
        private Doctor _doctor;

        public DoctorFeedback(User user, string comment, Dictionary<Question, Rating> rating, Doctor doctor) : base(user, comment, rating) => _doctor = doctor;
        public DoctorFeedback(long id, User user, string comment, Dictionary<Question, Rating> rating, Doctor doctor) : base(id, user, comment, rating) => _doctor = doctor;

        public DoctorFeedback(long id) : base(id)
        {
        }

        public Doctor Doctor { get => _doctor; set => _doctor = value; }
    }
}