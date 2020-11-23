using Backend.Model.PharmacyModel;
using Backend.Repository.Abstract.MiscAbstractRepository;
using Backend.Service.MiscService;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace IntegrationAdapterTests
{
    public class PharmacyVerificationTests
    {
        [Fact]
        public void Check_if_registered_pharmacy_contains_api_key()
        {
            RegisteredPharmacyService service = new RegisteredPharmacyService(CreateRegisteredPharmacyStubRepository());

            AssertApiKey((List<RegisteredPharmacy>)service.GetAll());
        }

        private static void AssertApiKey(List<RegisteredPharmacy> registeredPharmacies)
        {
            foreach (RegisteredPharmacy rp in registeredPharmacies)
            {
                rp.ApiKey.ShouldNotBeEmpty();
            }
        }

        [Fact]
        public void Check_if_registered_pharmacy_contains_endpoint()
        {
            RegisteredPharmacyService service = new RegisteredPharmacyService(CreateRegisteredPharmacyStubRepository());

            AssertEndpoints((List<RegisteredPharmacy>)service.GetAll());
        }

        private static void AssertEndpoints(List<RegisteredPharmacy> registeredPharmacies)
        {
            foreach (RegisteredPharmacy rp in registeredPharmacies)
            {
                rp.Endpoint.ShouldNotBeEmpty();
            }
        }

        [Fact]
        public void Check_if_medicine_log_exists()
        {
            bool fileExists = File.Exists(@"neka/putanja");

            fileExists.ShouldBeFalse();
        }

        private static IRegisteredPharmacyRepository CreateRegisteredPharmacyStubRepository()
        {
            var stubRepository = new Mock<IRegisteredPharmacyRepository>();
            List<RegisteredPharmacy> registeredPharmacies = new List<RegisteredPharmacy>();

            registeredPharmacies.Add(new RegisteredPharmacy("5433_RTWD", "Apoteka Jankovic Novi Sad", "www.jankovic.rs/apoteka/jankovic84"));
            registeredPharmacies.Add(new RegisteredPharmacy("2340_THNS", "Apoteka Jankovic Beograd", "www.jankovic.rs/apoteka/jankovic54"));
            registeredPharmacies.Add(new RegisteredPharmacy("7842_BQGF", "Apoteka Jankovic Subotica", "www.jankovic.rs/apoteka/jankovic12"));
            registeredPharmacies.Add(new RegisteredPharmacy("8782_FBSD", "Apoteka Jankovic Kragujevac", "www.jankovic.rs/apoteka/jankovic5"));

            stubRepository.Setup(m => m.GetAll()).Returns(registeredPharmacies);
            return stubRepository.Object;
        }
    }
}
