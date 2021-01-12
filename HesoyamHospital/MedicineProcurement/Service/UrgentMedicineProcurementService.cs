using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Hosting;
using Grpc.Core;
using RestSharp;
using MedicineProcurement.Service.Abstract;
using MedicineProcurement.Repository.Abstract;
using MedicineProcurement.DTOs;
using MedicineProcurement.Model;
using MedicineProcurement.Exceptions;

namespace MedicineProcurement.Service
{
    public class UrgentMedicineProcurementService : IUrgentMedicineProcurementService
    {
        private readonly IUrgentMedicineProcurementRepository _urgentMedicineProcurementRepository;
        private readonly IWebHostEnvironment _environment;
        public UrgentMedicineProcurementService(IUrgentMedicineProcurementRepository urgentMedicineProcurementRepository, IWebHostEnvironment environment)
        {
            _urgentMedicineProcurementRepository = urgentMedicineProcurementRepository;
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

        public IEnumerable<RegisteredPharmacyDTO> GetPharmaciesByRequiredMedicine(List<RegisteredPharmacyDTO> allPharmacies, UrgentMedicineProcurement urgentMedicine)
        {
            List<RegisteredPharmacyDTO> retVal = new List<RegisteredPharmacyDTO>();

            foreach(RegisteredPharmacyDTO pharmacy in allPharmacies)
            {
                if (_environment.IsDevelopment() && !string.IsNullOrEmpty(pharmacy.GrpcPort))
                {
                    //if(IsRequiredMedicineAvailableGrpc(pharmacy, urgentMedicine)) { retVal.Add(pharmacy); }
                } else
                {
                    if(IsRequiredMedicineAvailableHttp(pharmacy, urgentMedicine)) { retVal.Add(pharmacy); }
                }
            }
            return retVal;
        }

      /*  private bool IsRequiredMedicineAvailableGrpc(RegisteredPharmacyDTO pharmacy, UrgentMedicineProcurement urgentMedicine)
        {
            Channel channel = new Channel(pharmacy.Endpoint + ":" + pharmacy.GrpcPort, ChannelCredentials.Insecure);
            MedicineQuantityAvailableService.MedicineQuantityAvailableServiceClient client = new MedicineQuantityAvailableService.MedicineQuantityAvailableServiceClient(channel);
            MedicineProcurementProto request = new MedicineProcurementProto { MedicineName = urgentMedicine.Medicine, Quantity = urgentMedicine.Quantity };
            MedicineQuantityAvailableProto proto = client.IsQuantityAvailable(request);
            return proto.Available;
        }*/

        private bool IsRequiredMedicineAvailableHttp(RegisteredPharmacyDTO pharmacy, UrgentMedicineProcurement urgentMedicine)
        {
            var client = new RestClient(pharmacy.Endpoint);
            var request = new RestRequest("/api/availablequantity");
            request.AddParameter("medicine", urgentMedicine.Medicine);
            request.AddParameter("quantity", urgentMedicine.Quantity);
            var response = client.Get<bool>(request);
            return response.Data;
        }

        public bool IsProcurementRequestSuccessfull(RegisteredPharmacyDTO pharmacy, long urgentMedicineId)
        {
            UrgentMedicineProcurement urgentMedicine = _urgentMedicineProcurementRepository.GetByID(urgentMedicineId);
            if (_environment.IsDevelopment() && !string.IsNullOrEmpty(pharmacy.GrpcPort))
            {
                if (SendMedicineProcurementRequestGrpc(pharmacy, urgentMedicine))
                {
                    Conclude(urgentMedicine);
                    return true;
                }
            }
            else
            {
                if(SendMedicineProcurementRequestHttp(pharmacy, urgentMedicine))
                {
                    Conclude(urgentMedicine);
                    return true;
                }
            }
            return false;
        }

        private void Conclude(UrgentMedicineProcurement urgentMedicine)
        {
            //TODO: Povecati kolicinu u bazi
            UrgentMedicineProcurement procurement = _urgentMedicineProcurementRepository.GetByID(urgentMedicine.Id);
            procurement.Conclude();
            _urgentMedicineProcurementRepository.Update(procurement);
        }

        private bool SendMedicineProcurementRequestGrpc(RegisteredPharmacyDTO pharmacy, UrgentMedicineProcurement urgentMedicine)
        {
            Channel channel = new Channel(pharmacy.Endpoint + ":" + pharmacy.GrpcPort, ChannelCredentials.Insecure);
            MedicineProcurementService.MedicineProcurementServiceClient client = new MedicineProcurementService.MedicineProcurementServiceClient(channel);
            MedicineProcurementProto request = new MedicineProcurementProto { MedicineName = urgentMedicine.Medicine, Quantity = urgentMedicine.Quantity };
            MedicinePurchasedSuccessfullyProto proto = client.PurchaseMedicine(request);
            return proto.Success;
        }

        private bool SendMedicineProcurementRequestHttp(RegisteredPharmacyDTO pharmacy, UrgentMedicineProcurement urgentMedicine)
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
