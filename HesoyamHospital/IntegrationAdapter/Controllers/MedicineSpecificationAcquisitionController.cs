using Backend;
using Backend.Model.PatientModel;
using Backend.Model.PharmacyModel;
using Backend.Model.UserModel;
using IntegrationAdapter.DTOs;
using IntegrationAdapter.PrescribedMedicineReport;
using IntegrationAdapter.SFTPServiceSupport;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;

namespace IntegrationAdapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineSpecificationAcquisitionController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public MedicineSpecificationAcquisitionController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet("getALL/medicines")]
        public IActionResult GetAllMedicines()
        {
            List<Medicine> medicineList = (List<Medicine>)AppResources.getInstance().medicineService.GetAll();
            List<MedicineDTO> medicineDTOList = new List<MedicineDTO>();
            foreach (Medicine medicine in medicineList)
            {
                medicineDTOList.Add(MedicineDTO.MedicineToMedicineDTO(medicine));
            }
            return Ok(medicineDTOList);
        }
        [HttpGet("getALL/patients")]
        public IActionResult GetAllPatients()
        {
            List<Patient> patientList = (List<Patient>)AppResources.getInstance().patientService.GetAll();
            List<PatientDTO> patientDTOList = new List<PatientDTO>();
            foreach (Patient patient in patientList)
            {
                patientDTOList.Add(PatientDTO.PatientToPatientDTO(patient));
            }
            return Ok(patientDTOList);
        }

        [HttpGet("specification/{name}")]
        public IActionResult GetSpecification(string name)
        {
            string text = SFTPService.ConnectAndReceiveSpecifications(name + ".txt");
            return Ok(text);
        }

        [HttpPut("prescription/{pharmacyName}")]
        public IActionResult AddTherapy(TherapyDTO dto, string pharmacyName)
        {
            RegisteredPharmacy pharmacy = AppResources.getInstance().registeredPharmacyService.GetRegisteredPharmacyByName(pharmacyName);
            Therapy therapy = TherapyDTO.TherapyDTOToTherapy(dto);
            AppResources.getInstance().therapyService.Create(therapy);
            PrescriptionTextGenerator generator = new PrescriptionTextGenerator(therapy);
            string text = generator.GeneratePrescriptionText();
            if (_environment.IsDevelopment())
            {
                SendViaSFTP(therapy, text);
            }
            else
            {
                SendViaHttp(pharmacy, text);
            }
            return Ok(text);
        }

        private void SendViaHttp(RegisteredPharmacy pharmacy, string text)
        {
            var client = new RestClient(pharmacy.Endpoint);
            var request = new RestRequest("/prescription");
            request.AddParameter("prescription", text);
            client.Put<string>(request);
        }

        private void SendViaSFTP(Therapy therapy, string text)
        {
            string startupPath = Directory.GetCurrentDirectory();
            string filepath = @"\PrescribedMedicineReport\prescriptions\" + therapy.Prescription.Patient.Jmbg + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + ".txt";
            using (StreamWriter sw = System.IO.File.CreateText(startupPath + filepath))
            {
                sw.WriteLine(text);
            }
            SFTPService.ConnectAndSendPrescription(startupPath + filepath);
        }
    }
}
