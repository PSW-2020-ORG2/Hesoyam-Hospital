// File:    HospitalController.cs
// Author:  Geri
// Created: 20. maj 2020 11:07:40
// Purpose: Definition of Class HospitalController

using System;
using System.Collections.Generic;
using Controller;
using SIMS.Model.UserModel;
using SIMS.Service.HospitalManagementService;

namespace SIMS.Controller.HospitalManagementController
{
    public class HospitalController : IController<Hospital, long>
    {
        public HospitalService hospitalService;

        public HospitalController(HospitalService hospitalService)
        {
            this.hospitalService = hospitalService;
        }

        public IEnumerable<Hospital> GetHospitalByLocation(Location location)
            => hospitalService.GetHospitalByLocation(location);

        public IEnumerable<Hospital> GetAll()
            => hospitalService.GetAll();

        public Hospital GetByID(long id)
            => hospitalService.GetByID(id);

        public Hospital Create(Hospital entity)
            => hospitalService.Create(entity);

        public void Update(Hospital entity)
            => hospitalService.Update(entity);

        public void Delete(Hospital entity)
            => hospitalService.Delete(entity);

    }
}