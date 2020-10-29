// File:    IMedicalRecordRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 14:04:43
// Purpose: Definition of Interface IMedicalRecordRepository

using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using System;

namespace SIMS.Repository.Abstract.MedicalAbstractRepository
{
    public interface IMedicalRecordRepository : IRepository<MedicalRecord, long>
    {

        MedicalRecord GetPatientMedicalRecord(Patient patient);



    }
}