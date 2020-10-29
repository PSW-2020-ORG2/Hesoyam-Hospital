// File:    ISymptomRepository.cs
// Author:  Geri
// Created: 23. maj 2020 19:56:20
// Purpose: Definition of Interface ISymptomRepository

using SIMS.Model.PatientModel;
using System;

namespace SIMS.Repository.Abstract.MedicalAbstractRepository
{
    public interface ISymptomRepository : IRepository<Symptom, long>
    {
    }
}