using Medicines.Exceptions;
using Medicines.Model;
using Medicines.Repository.Abstract;
using Medicines.Service.Abstract;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using Medicines.DTOs;
using Medicines.Protos;
using Grpc.Core;
using Newtonsoft.Json;
using RestSharp;

namespace Medicines.Service
{
    public class MedicineService : IMedicineService
    {

        private readonly IMedicineRepository _medicineRepository;
        private readonly IWebHostEnvironment _environment;
        public MedicineService(IMedicineRepository medicineRepository, IWebHostEnvironment environment)
        {
            _medicineRepository = medicineRepository;
            _environment = environment;
        }

        public IEnumerable<Medicine> GetMedicineForDisease(Disease disease)
            => _medicineRepository.GetMedicineForDisease(disease);

        public IEnumerable<Medicine> GetMedicineByIngredient(Ingredient ingredient)
            => _medicineRepository.GetMedicineByIngredient(ingredient);

        public Medicine GetMedicineByName(string name)
            => _medicineRepository.GetMedicineByName(name);

        public IEnumerable<Medicine> GetMedicinesByPartName(string partOfTheName)
            => _medicineRepository.GetMedicinesByPartName(partOfTheName);

        public IEnumerable<Medicine> GetMedicinePendingApproval()
            => _medicineRepository.GetMedicinePendingApproval();

        public IEnumerable<Medicine> GetAll()
            => _medicineRepository.GetAll();

        public Medicine GetByID(long id)
            => _medicineRepository.GetByID(id);

        public IEnumerable<Medicine> GetMedicinesByRoomId(long roomId)
            => _medicineRepository.GetMedicinesByRoomId(roomId);

        public Medicine Create(Medicine entity)
        {
            Validate(entity);
            return _medicineRepository.Create(entity);
        }

        public void Update(Medicine entity)
        {
            Validate(entity);
            _medicineRepository.Update(entity);
        }

        public void Delete(Medicine entity)
            => _medicineRepository.Delete(entity);

        public void Validate(Medicine entity)
        {
            CheckInStock(entity.InStock);
            CheckMinNumber(entity.MinNumber);
            CheckName(entity.Name);
        }

        private void CheckName(string name)
        {
            if (!Regex.Match(name, @"[a-zA-Z0-9\\-\\! ]*").Success)
                throw new MedicineServiceException("Name contains illegal characters!");
        }

        private void CheckMinNumber(int minNumber)
        {
            if (minNumber < 0)
                throw new MedicineServiceException("Minimum number of medicines is less than zero!");
        }

        private void CheckInStock(int inStock)
        {
            if (inStock < 0)
                throw new MedicineServiceException("In stock amount is less than zero!");
        }

        public MedicineAvailabilityDTO GetMedicineAvailability(string medicineName, RegisteredPharmacyDTO registeredPharmacy)
        {
            MedicineAvailabilityDTO retVal;
            if (_environment.IsDevelopment() && !string.IsNullOrEmpty(registeredPharmacy.GrpcPort))
            {
                retVal = GetMedicineAvailabilityGrpc(medicineName, registeredPharmacy);
            }
            else
            {
                retVal = GetMedicineAvailabilityHttp(medicineName, registeredPharmacy);
            }
            return retVal;
        }

        private MedicineAvailabilityDTO GetMedicineAvailabilityGrpc(string medicineName, RegisteredPharmacyDTO registeredPharmacy)
        {
            Channel channel = new Channel(registeredPharmacy.Endpoint + ":" + registeredPharmacy.GrpcPort, ChannelCredentials.Insecure);
            MedicineAvailabilityService.MedicineAvailabilityServiceClient client = new MedicineAvailabilityService.MedicineAvailabilityServiceClient(channel);
            MedicineAvailabilityProto proto = client.IsMedicineAvailable(new MedicineNameProto { MedicineName = medicineName });
            return JsonConvert.DeserializeObject<MedicineAvailabilityDTO>(proto.ToString());
        }

        private MedicineAvailabilityDTO GetMedicineAvailabilityHttp(string medicineName, RegisteredPharmacyDTO registeredPharmacy)
        {
            var client = new RestClient(registeredPharmacy.Endpoint);
            var request = new RestRequest("/api/availablemedicine");
            request.AddParameter("medicine", medicineName);
            var response = client.Get<MedicineAvailabilityDTO>(request);
            MedicineAvailabilityDTO retVal = response.Data;
            return retVal;
        }
    }
}
