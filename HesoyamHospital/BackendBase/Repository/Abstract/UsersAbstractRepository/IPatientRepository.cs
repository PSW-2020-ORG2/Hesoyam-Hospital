// File:    IPatientRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 14:06:33
// Purpose: Definition of Interface IPatientRepository

using System;
using System.Collections.Generic;
using SIMS.Model.UserModel;

namespace SIMS.Repository.Abstract.UsersAbstractRepository
{
    public interface IPatientRepository : IRepository<Patient, UserID>
    {
        IEnumerable<Patient> GetPatientByType(PatientType patientType);

        IEnumerable<Patient> GetPatientByDoctor(Doctor doctor);

    }
}