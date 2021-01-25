using Medicines.DTOs;
using Medicines.Exceptions;
using Medicines.Model;
using Medicines.Repository.Abstract;
using Medicines.Service.Abstract;
using Medicines.Util;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Medicines.Service
{
    public class TherapyService : ITherapyService
    {
        private readonly ITherapyRepository _therapyRepository;
        private readonly IWebHostEnvironment _environment;
        private readonly PrescriptionTextGenerator _prescriptionTextGenerator;

        public TherapyService(ITherapyRepository therapyRepository, IWebHostEnvironment environment)
        {
            _therapyRepository = therapyRepository;
            _environment = environment;
            _prescriptionTextGenerator = new PrescriptionTextGenerator();
        }

        public Therapy Create(Therapy entity)
        {
            Validate(entity);
            return _therapyRepository.Create(entity);
        }

        public void Delete(Therapy entity)
        {
            _therapyRepository.Delete(entity);
        }

        public IEnumerable<Therapy> GetAll()
        {
            return _therapyRepository.GetAll();
        }

        public Therapy GetByID(long id)
        {
            return _therapyRepository.GetByID(id);
        }

        public void SendTherapyToPharmacy(Therapy therapy, string patientFullName, string uidn, RegisteredPharmacyDTO registeredPharmacy)
        {
            string text = _prescriptionTextGenerator.GeneratePrescriptionText(therapy, patientFullName);
            if (_environment.IsDevelopment())
            {
                SendViaSFTP(text, patientFullName, uidn);
            }
            else
            {
                SendViaHttp(registeredPharmacy, text);
            }
        }

        private void SendViaSFTP(string text, string patientFullName, string uidn)
        {
            string startupPath = Directory.GetCurrentDirectory();
            string filepath = @"\PrescribedMedicineReport\prescriptions\" + patientFullName + "_" + uidn + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + ".txt";
            using (StreamWriter sw = System.IO.File.CreateText(startupPath + filepath))
            {
                sw.WriteLine(text);
            }
            SFTPService.ConnectAndSendPrescription(startupPath + filepath);
        }

        private void SendViaHttp(RegisteredPharmacyDTO registeredPharmacy, string text)
        {
            var client = new RestClient(registeredPharmacy.Endpoint);
            var request = new RestRequest("/prescription");
            request.AddParameter("prescription", text);
            client.Put<string>(request);
        }

        public void Update(Therapy entity)
        {
            Validate(entity);
            _therapyRepository.Update(entity);
        }

        public void Validate(Therapy entity)
        {
            if (entity.TimeInterval.StartTime > entity.TimeInterval.EndTime)
                throw new TherapyServiceException("Start time must be before end time!");
            if (entity.TimeInterval.StartTime < DateTime.Now)
                throw new TherapyServiceException("Therapy start time must be in the future!");
            if(!entity.Prescription.MedicalTherapies.Any())
            {
                throw new TherapyServiceException("Therapy must contain medicines!");
            }
        }

        public IEnumerable<Therapy> GetTherapyByDatePrescribed(TimeInterval dateRange)
        {
            return _therapyRepository.GetTherapyByDatePrescribed(dateRange);
        }
    }
}
