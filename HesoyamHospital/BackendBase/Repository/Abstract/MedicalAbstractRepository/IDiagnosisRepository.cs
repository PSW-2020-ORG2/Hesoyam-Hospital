// File:    IDiagnosisRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 14:03:26
// Purpose: Definition of Interface IDiagnosisRepository

using System;
using System.Collections.Generic;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;

namespace SIMS.Repository.Abstract.MedicalAbstractRepository
{
    public interface IDiagnosisRepository : IRepository<Diagnosis, long>
    {
        IEnumerable<Diagnosis> GetAllDiagnosisForPatient(Patient patient);

        IEnumerable<Diagnosis> GetDiagnosisByMedicine(Medicine medicine);

    }
}