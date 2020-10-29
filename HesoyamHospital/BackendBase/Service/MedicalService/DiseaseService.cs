// File:    DiseaseService.cs
// Author:  Geri
// Created: 19. maj 2020 20:14:32
// Purpose: Definition of Class DiseaseService

using System;
using System.Collections.Generic;
using SIMS.Model.PatientModel;
using SIMS.Repository.Abstract.MedicalAbstractRepository;
using SIMS.Repository.CSVFileRepository.MedicalRepository;
using System.Text.RegularExpressions;
using SIMS.Util;
using SIMS.Exceptions;

namespace SIMS.Service.MedicalService
{
    public class DiseaseService : IService<Disease, long>
    {
        private DiseaseRepository _diseaseRepository;

        public DiseaseService(DiseaseRepository diseaseRepository)
        {
            _diseaseRepository = diseaseRepository;
        }

        public IEnumerable<Disease> GetDiseasesBySymptoms(IEnumerable<Symptom> symptoms)
            => _diseaseRepository.GetDiseasesBySymptoms(symptoms);

        public IEnumerable<Disease> GetDiseasesByType(DiseaseType type)
            => _diseaseRepository.GetDiseasesByType(type);

        public IEnumerable<Disease> GetAll()
            => _diseaseRepository.GetAllEager();

        public Disease GetByID(long id)
            => _diseaseRepository.GetEager(id);

        public Disease Create(Disease entity)
        {
            Validate(entity);
            return _diseaseRepository.Create(entity);
        }

        public void Delete(Disease entity)
            => _diseaseRepository.Delete(entity);

        public void Update(Disease entity)
        {
            Validate(entity);
            _diseaseRepository.Update(entity);
        }

        public void Validate(Disease entity)
        {
            if (Regex.IsMatch(Regexes.diseaseName, entity.Name))
                throw new DiseaseServiceException("Disease name is not valid!");
        }
    }
}