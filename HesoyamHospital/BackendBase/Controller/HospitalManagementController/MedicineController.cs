// File:    MedicineController.cs
// Author:  Geri
// Created: 20. maj 2020 11:07:40
// Purpose: Definition of Class MedicineController

using System;
using System.Collections.Generic;
using Controller;
using SIMS.Model.PatientModel;
using SIMS.Service.HospitalManagementService;
using SIMS.Util;

namespace SIMS.Controller.HospitalManagementController
{
    public class MedicineController : IController<Medicine, long>
    {

        public MedicineService medicineService;

        public MedicineController(MedicineService medicineService)
        {
            this.medicineService = medicineService;
        }

        public IEnumerable<Medicine> GetMedicineForDisease(Disease disease)
            => medicineService.GetMedicineForDisease(disease);

        public IEnumerable<Medicine> GetMedicineByIngredient(Ingredient ingredient)
            => medicineService.GetMedicineByIngredient(ingredient);

        public Medicine GetMedicineByName(string name)
            => medicineService.GetMedicineByName(name);

        public IEnumerable<Medicine> GetFilteredMedicine(MedicineFilter medicineFilter)
            => medicineService.GetFilteredMedicine(medicineFilter);

        public IEnumerable<Medicine> GetMedicinePendingApproval()
            => medicineService.GetMedicinePendingApproval();

        public IEnumerable<Medicine> GetAll()
            => medicineService.GetAll();

        public Medicine GetByID(long id)
            => medicineService.GetByID(id);

        public Medicine Create(Medicine entity)
            => medicineService.Create(entity);

        public void Update(Medicine entity)
            => medicineService.Update(entity);

        public void Delete(Medicine entity)
            => medicineService.Delete(entity);
    }
}