using Backend;
using Backend.Model.PatientModel;
using Backend.Repository.MySQLRepository.HospitalManagementRepository;
using Backend.Service.HospitalManagementService;
using System.Collections.Generic;
using Xunit;
using Shouldly;

namespace GraphicEditorTests
{
    public class SearchMedicinesTests
    {
        [Fact]
        public void Finds_medicines_by_part_of_the_name()
        {
            MedicineRepository medicineRepository = AppResources.getInstance().medicineRepository;

            MedicineService medicineService = new MedicineService(medicineRepository);

            List<Medicine> medicines = (List<Medicine>)medicineService.GetMedicinesByPartName("B");

            medicines.ShouldNotBeEmpty();
        }

        [Fact]
        public void Not_find_medicine_by_id()
        {
            MedicineRepository medicineRepository = AppResources.getInstance().medicineRepository;

            MedicineService medicineService = new MedicineService(medicineRepository);

            Medicine medicine1 = new Medicine(109, "Marisol", MedicineType.SUPPOSITORIES, true, null, null, 20, 5, 101);

            Medicine medicine = medicineService.GetByID(medicine1.Id);

            medicine.ShouldBeNull();
        }
    }
}