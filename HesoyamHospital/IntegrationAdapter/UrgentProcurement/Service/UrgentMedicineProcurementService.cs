using Backend.Exceptions;
using Backend.Model.PharmacyModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Backend.Repository.Abstract.MiscAbstractRepository;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Grpc.Core;
using IntegrationAdapter.Protos;
using RestSharp;
using Backend.Model.PatientModel;

namespace IntegrationAdapter.UrgentProcurement.Service
{
    public class UrgentMedicineProcurementService : IUrgentMedicineProcurementService
    {
        private readonly IUrgentMedicineProcurementRepository _urgentMedicineProcurementRepository;
        private readonly IRegisteredPharmacyRepository _registeredPharmacyRepository;
        private readonly IMedicineRepository _medicineRepository;
        private readonly IWebHostEnvironment _environment;
        public UrgentMedicineProcurementService(IUrgentMedicineProcurementRepository urgentMedicineProcurementRepository,
            IRegisteredPharmacyRepository registeredPharmacyRepository,
            IMedicineRepository medicineRepository,
            IWebHostEnvironment environment)
        {
            _urgentMedicineProcurementRepository = urgentMedicineProcurementRepository;
            _registeredPharmacyRepository = registeredPharmacyRepository;
            _medicineRepository = medicineRepository;
            _environment = environment;
        }
        public UrgentMedicineProcurement Create(UrgentMedicineProcurement entity)
        {
            Validate(entity);
            return _urgentMedicineProcurementRepository.Create(entity);
        }

        public void Delete(UrgentMedicineProcurement entity)
        {
            _urgentMedicineProcurementRepository.Delete(entity);
        }

        public IEnumerable<UrgentMedicineProcurement> GetAll()
        {
            return _urgentMedicineProcurementRepository.GetAll();
        }

        public UrgentMedicineProcurement GetByID(long id)
        {
            return _urgentMedicineProcurementRepository.GetByID(id);
        }

        public IEnumerable<RegisteredPharmacy> GetPharmaciesByRequiredMedicine(UrgentMedicineProcurement urgentMedicine)
        {
            List<RegisteredPharmacy> retVal = new List<RegisteredPharmacy>();
            List<RegisteredPharmacy> allPharmacies = _registeredPharmacyRepository.GetAll().ToList();

            foreach(RegisteredPharmacy pharmacy in allPharmacies)
            {
                if (_environment.IsDevelopment() && !string.IsNullOrEmpty(pharmacy.GrpcPort))
                {
                    if(IsRequiredMedicineAvailableGrpc(pharmacy, urgentMedicine)) { retVal.Add(pharmacy); }
                } else
                {
                    if(IsRequiredMedicineAvailableHttp(pharmacy, urgentMedicine)) { retVal.Add(pharmacy); }
                }
            }
            return retVal;
        }

        private bool IsRequiredMedicineAvailableGrpc(RegisteredPharmacy pharmacy, UrgentMedicineProcurement urgentMedicine)
        {
            Channel channel = new Channel(pharmacy.Endpoint + ":" + pharmacy.GrpcPort, ChannelCredentials.Insecure);
            MedicineQuantityAvailableService.MedicineQuantityAvailableServiceClient client = new MedicineQuantityAvailableService.MedicineQuantityAvailableServiceClient(channel);
            MedicineProcurementProto request = new MedicineProcurementProto { MedicineName = urgentMedicine.Medicine, Quantity = urgentMedicine.Quantity };
            MedicineQuantityAvailableProto proto = client.IsQuantityAvailable(request);
            return proto.Available;
        }

        private bool IsRequiredMedicineAvailableHttp(RegisteredPharmacy pharmacy, UrgentMedicineProcurement urgentMedicine)
        {
            var client = new RestClient(pharmacy.Endpoint);
            var request = new RestRequest("/api/availablequantity");
            request.AddParameter("medicine", urgentMedicine.Medicine);
            request.AddParameter("quantity", urgentMedicine.Quantity);
            var response = client.Get<bool>(request);
            return response.Data;
        }

        public bool IsProcurementRequestSuccessfull(string pharmacyName, UrgentMedicineProcurement urgentMedicine)
        {
            RegisteredPharmacy pharmacy = _registeredPharmacyRepository.GetRegisteredPharmacyByName(pharmacyName);

            if (_environment.IsDevelopment() && !string.IsNullOrEmpty(pharmacy.GrpcPort))
            {
                if(SendMedicineProcurementRequestGrpc(pharmacy, urgentMedicine))
                {
                    PurchaseMedicine(urgentMedicine);
                    return true;
                }
            }
            else
            {
                if(SendMedicineProcurementRequestHttp(pharmacy, urgentMedicine))
                {
                    PurchaseMedicine(urgentMedicine);
                    return true;
                }
            }
            return false;
        }

        private void PurchaseMedicine(UrgentMedicineProcurement urgentMedicine)
        {
            Medicine medicine = _medicineRepository.GetMedicineByName(urgentMedicine.Medicine);
            medicine.InStock += (int)urgentMedicine.Quantity;
            _medicineRepository.Update(medicine);
            UrgentMedicineProcurement procurement = _urgentMedicineProcurementRepository.GetByID(urgentMedicine.Id);
            procurement.Conclude();
            _urgentMedicineProcurementRepository.Update(procurement);
        }

        private bool SendMedicineProcurementRequestGrpc(RegisteredPharmacy pharmacy, UrgentMedicineProcurement urgentMedicine)
        {
            Channel channel = new Channel(pharmacy.Endpoint + ":" + pharmacy.GrpcPort, ChannelCredentials.Insecure);
            MedicineProcurementService.MedicineProcurementServiceClient client = new MedicineProcurementService.MedicineProcurementServiceClient(channel);
            MedicineProcurementProto request = new MedicineProcurementProto { MedicineName = urgentMedicine.Medicine, Quantity = urgentMedicine.Quantity };
            MedicinePurchasedSuccessfullyProto proto = client.PurchaseMedicine(request);
            return proto.Success;
        }

        private bool SendMedicineProcurementRequestHttp(RegisteredPharmacy pharmacy, UrgentMedicineProcurement urgentMedicine)
        {
            var client = new RestClient(pharmacy.Endpoint);
            var request = new RestRequest("/api/purchasemedicine");
            request.AddParameter("medicine", urgentMedicine.Medicine);
            request.AddParameter("quantity", urgentMedicine.Quantity);
            var response = client.Post<bool>(request);
            return response.Data;
        }

        public void Update(UrgentMedicineProcurement entity)
        {
            Validate(entity);
            _urgentMedicineProcurementRepository.Update(entity);
        }

        public void Validate(UrgentMedicineProcurement entity)
        {
            if (entity.Medicine == null)
            {
                throw new MedicineNullException("Medicine is not set!");
            }
            if (entity.Medicine == "")
            {
                throw new MedicineNullException("Medicine cannot be empty!");
            }
            if (entity.Quantity <= 0)
            {
                throw new InvalidQuantityException("Quantity cannot be less than or equal to zero!");
            }
        }

        public IEnumerable<UrgentMedicineProcurement> GetAllUnconcluded()
        {
            return _urgentMedicineProcurementRepository.GetAllUnconcluded();
        }
    }
}
