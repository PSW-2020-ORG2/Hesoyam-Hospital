// File:    TherapyDose.cs
// Author:  nikola
// Created: 24. maj 2020 10:53:22
// Purpose: Definition of Class TherapyDose

using System;
using System.Collections.Generic;

namespace SIMS.Model.PatientModel
{
    public class TherapyDose
    {

        private Dictionary<TherapyTime, double> _dosage;

        public Dictionary<TherapyTime, double> Dosage { get => _dosage; set => _dosage = value; }

        public TherapyDose(Dictionary<TherapyTime,double> dosage)
        {
            _dosage = dosage;
        }
    }
}