// File:    Therapy.cs
// Author:  Windows 10
// Created: 15. april 2020 22:03:13
// Purpose: Definition of Class Therapy

using SIMS.Repository.Abstract;
using SIMS.Util;
using System;
using System.Collections.Generic;

namespace SIMS.Model.PatientModel
{
    public class Therapy : IIdentifiable<long>
    {
        private long _id;
        private TimeInterval _timeInterval;
        private Prescription _prescription;

        public TimeInterval TimeInterval { get => _timeInterval; set => _timeInterval = value; }
        public Prescription Prescription { get => _prescription; set => _prescription = value; }

        public Therapy(long id)
        {
            _id = id;
        }

        public Therapy(long id, TimeInterval timeInterval, Prescription prescription)
        {
            _id = id;
            _timeInterval = timeInterval;
            _prescription = prescription;
        }

        public Therapy(TimeInterval timeInterval, Prescription prescription)
        {
            _timeInterval = timeInterval;
            _prescription = prescription;
        }

        public long GetId()
            => _id;

        public void SetId(long id)
            => _id = id;

        public override bool Equals(object obj)
        {
            var therapy = obj as Therapy;
            return therapy != null &&
                   _id == therapy._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }
    }
}