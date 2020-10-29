// File:    DoctorController.cs
// Author:  nikola
// Created: 22. maj 2020 17:03:50
// Purpose: Definition of Class DoctorController

using System;
using System.Collections.Generic;
using Controller;
using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;
using SIMS.Service.MedicalService;
using SIMS.Service.UsersService;
using SIMS.Util;

namespace SIMS.Controller.UsersController
{
    public class DoctorController : IController<Doctor, UserID>
    {
        private DoctorService _doctorService;
        private DiagnosisService _diagnosisService;
        private TherapyService _therapyService;
        private MedicalRecordService _medicalRecordService;

        public DoctorController(DoctorService doctorService, DiagnosisService diagnosisService, TherapyService therapyService, MedicalRecordService medicalRecordService)
        {
            _doctorService = doctorService;
            _diagnosisService = diagnosisService;
            _therapyService = therapyService;
            _medicalRecordService = medicalRecordService;
        }

        public IEnumerable<Doctor> GetActiveDoctors()
            => _doctorService.GetActiveDoctors();

        public IEnumerable<Doctor> GetDoctorByType(DoctorType doctorType)
            => _doctorService.GetDoctorByType(doctorType);

        public IEnumerable<Doctor> GetAvailableDoctorsByTime(TimeInterval timeInterval)
            => _doctorService.GetAvailableDoctorsByTime(timeInterval);

        public IEnumerable<Doctor> GetFilteredDoctors(DoctorFilter filter)
            => _doctorService.GetFilteredDoctors(filter);

        public IEnumerable<Doctor> GetAll()
            => _doctorService.GetAll();

        public Doctor GetByID(UserID id)
            => _doctorService.GetByID(id);

        public Doctor Create(Doctor entity)
            => _doctorService.Create(entity);

        public void Update(Doctor entity)
            => _doctorService.Update(entity);

        public void Delete(Doctor entity)
            => _doctorService.Delete(entity);

    }
}