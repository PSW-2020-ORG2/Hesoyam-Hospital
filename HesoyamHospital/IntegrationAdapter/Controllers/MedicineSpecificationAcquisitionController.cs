using Backend;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
            string text = System.IO.File.ReadAllText(@"D:\Users\Marko\Desktop\RebexTinySftpServer-Binaries-Latest\data\specifications\"+name+".txt");
            return Ok(text);
        }
        [HttpPut("prescription")]
        public IActionResult CreatePrescriptionFile(long id,string text)
        {
            //Patient patient = AppResources.getInstance().patientService.GetByID(id);
            string filepath = @"D:\Users\Marko\Desktop\RebexTinySftpServer-Binaries-Latest\data\prescriptions\" + id +"_"+ DateTime.Now.Hour +"-" + DateTime.Now.Minute + ".txt";   //id promeniti na patient.Name
            using (StreamWriter sw = System.IO.File.CreateText(filepath))
            {
                sw.WriteLine(text);
            }
            return Ok();
        }
    }
}
