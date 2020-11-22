// File:    Diagnosis.cs
// Author:  Windows 10
// Created: 16. april 2020 18:22:13
// Purpose: Definition of Class Diagnosis

using System;
using System.Collections.Generic;
using Backend.Repository.Abstract;
using System.Linq;

namespace Backend.Model.PatientModel
{
    public class Diagnosis : IIdentifiable<long>
    {
        private long _id;
        public long Id { get => _id; set => _id = value; }

        private string _diagnosisCode;
        public string DiagnosisCode { get => _diagnosisCode; set => _diagnosisCode = value; }

        private string _diagnosisName;
        public string diagnosisName { get => _diagnosisName; set => _diagnosisName = value; }


        public Diagnosis(long id)
        {
            _id = id;
        }

        public Diagnosis(long id, string diagnosisName, string diagnosisCode)
        {
            _id = id;
            _diagnosisName = diagnosisName;
            _diagnosisCode = diagnosisCode;
        }

        public long GetId() => _id;

        public void SetId(long id) => _id = id;

        public override bool Equals(object obj)
        {
            var diagnosis = obj as Diagnosis;
            return diagnosis != null &&
                   _id == diagnosis._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }
    }
}