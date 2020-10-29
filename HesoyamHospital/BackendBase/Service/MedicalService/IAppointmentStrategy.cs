// File:    IAppointmentStrategy.cs
// Author:  vule
// Created: 26. maj 2020 16:37:17
// Purpose: Definition of Interface IAppointmentStrategy

using SIMS.Model.PatientModel;
using System;

namespace SIMS.Service.MedicalService
{
    public interface IAppointmentStrategy
    {
        void CheckType(Appointment appointment);

        void checkDateTimeValid(Appointment appointment);

        void Validate(Appointment appointment);

        bool isAppointmentChangeable(Appointment appointment);

    }
}