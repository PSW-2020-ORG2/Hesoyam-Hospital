using Backend;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using IntegrationAdapter.DTOs;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntegrationAdapterTests.Integration
{
    public class TherapyTests
    {
        [Fact]
        public void check_if_correctly_converted_patient_to_DTO()
        {
            Patient patient = AppResources.getInstance().patientService.GetByID(1);
            PatientDTO patientDTO = PatientDTO.PatientToPatientDTO(patient);
            patientDTO.Jmbg.ShouldBe("111111111111");
        }
        [Fact]
        public void check_if_correct_medicine_returned()
        {
            Medicine medicine = AppResources.getInstance().medicineService.GetByID(2);
            medicine.Name.ShouldBe("Andol");
        }
    }
}
