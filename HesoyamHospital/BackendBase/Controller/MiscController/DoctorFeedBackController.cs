// File:    DoctorFeedBackController.cs
// Author:  nikola
// Created: 22. maj 2020 17:30:10
// Purpose: Definition of Class DoctorFeedBackController

using System;
using System.Collections.Generic;
using Controller;
using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;
using SIMS.Service.MiscService;

namespace SIMS.Controller.MiscController
{
    public class DoctorFeedBackController : IController<DoctorFeedback, long>
    {

        public DoctorFeedbackService doctorFeedbackService;

        public DoctorFeedBackController(DoctorFeedbackService doctorFeedbackService)
        {
            this.doctorFeedbackService = doctorFeedbackService;
        }

        public DoctorFeedback GetByPatientDoctor(Patient patient, Doctor doctor)
            => doctorFeedbackService.GetByPatientDoctor(patient, doctor);

        public IEnumerable<DoctorFeedback> GetByDoctor(Doctor doctor)
            => doctorFeedbackService.GetByDoctor(doctor);

        public double GetAverageRatingByDoctor(Doctor doctor)
            => doctorFeedbackService.GetAverageRatingByDoctor(doctor);


        //TODO: 
        public IEnumerable<DoctorFeedback> GetRecentRatingsByDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DoctorFeedback> GetAll()
            => doctorFeedbackService.GetAll();

        public DoctorFeedback GetByID(long id)
            => doctorFeedbackService.GetByID(id);

        public DoctorFeedback Create(DoctorFeedback entity)
            => doctorFeedbackService.Create(entity);

        public void Update(DoctorFeedback entity)
            => doctorFeedbackService.Update(entity);

        public void Delete(DoctorFeedback entity)
            => doctorFeedbackService.Delete(entity);

    }
}