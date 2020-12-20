using Backend;
using Backend.Model.PatientModel;
using Backend.Repository.MySQLRepository.HospitalManagementRepository;
using Backend.Service.HospitalManagementService;
using System.Collections.Generic;
using Xunit;

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

            Assert.NotEmpty(medicines);
        }

        [Fact]
        public void Not_Find_medicine_by_id()
        {
            MedicineRepository medicineRepository = AppResources.getInstance().medicineRepository;

            MedicineService medicineService = new MedicineService(medicineRepository);

            Medicine medicine1 = new Medicine(107, "Marisol", MedicineType.SUPPOSITORIES, true, null, null, 20, 5, 204);

            Medicine medicine = medicineService.GetByID(medicine1.Id);

            Assert.Null(medicine);
        }
    }
}