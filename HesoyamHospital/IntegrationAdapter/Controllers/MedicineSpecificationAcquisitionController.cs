using Backend;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using IntegrationAdapter.DTOs;
using IntegrationAdapter.PrescribedMedicineReport;
using IntegrationAdapter.SFTPServiceSupport;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace IntegrationAdapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineSpecificationAcquisitionController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllMedicines()
        {
            List<Medicine> medicineList = (List<Medicine>)AppResources.getInstance().medicineService.GetAll();
            return Ok(medicineList);
        }
        [HttpGet]
        public IActionResult GetAllPatients()
        {
            List<Patient> patientList = (List<Patient>)AppResources.getInstance().patientService.GetAll();
            return Ok(patientList);
        }

        [HttpGet("specification/{name}")]
        public IActionResult GetSpecification(string name)
        {
            string text = SFTPService.ConnectAndReceiveSpecifications(name + ".txt");
            return Ok(text);
        }

        [HttpPut("prescription")]
        public IActionResult AddTherapy(TherapyDTO dto)
        {
            Therapy therapy = TherapyDTO.TherapyDTOToTherapy(dto);
            AppResources.getInstance().therapyService.Create(therapy);
            string startupPath = Directory.GetCurrentDirectory();
            PrescriptionTextGenerator generator = new PrescriptionTextGenerator(therapy);
            string text = generator.GeneratePrescriptionText();
            string filepath = @"\PrescribedMedicineReport\prescriptions\" + therapy.Prescription.Patient.Jmbg +"_"+ DateTime.Now.Hour +"-" + DateTime.Now.Minute + ".txt";
            using (StreamWriter sw = System.IO.File.CreateText(startupPath + filepath))
            {
                sw.WriteLine(text);
            }
            SFTPService.ConnectAndSendPrescription(startupPath + filepath);
            return Ok();
        }
    }
}
