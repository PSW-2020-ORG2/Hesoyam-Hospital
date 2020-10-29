// File:    DiseaseController.cs
// Author:  nikola
// Created: 22. maj 2020 16:57:18
// Purpose: Definition of Class DiseaseController

using System;
using System.Collections.Generic;
using Controller;
using SIMS.Model.PatientModel;
using SIMS.Service.MedicalService;

namespace SIMS.Controller.MedicalController
{
    public class DiseaseController : IController<Disease, long>
    {
        public DiseaseService diseaseService;

        public DiseaseController(DiseaseService diseaseService)
        {
            this.diseaseService = diseaseService;
        }

        public IEnumerable<Disease> GetDiseasesBySymptoms(IEnumerable<Symptom> symptoms)
            => diseaseService.GetDiseasesBySymptoms(symptoms);

        public IEnumerable<Disease> GetDiseasesByType(DiseaseType type)
            => diseaseService.GetDiseasesByType(type);

        public IEnumerable<Disease> GetAll()
            => diseaseService.GetAll();

        public Disease GetByID(long id)
            => diseaseService.GetByID(id);

        public Disease Create(Disease entity)
            => diseaseService.Create(entity);

        public void Update(Disease entity)
            => diseaseService.Update(entity);

        public void Delete(Disease entity)
            => diseaseService.Delete(entity);

    }
}