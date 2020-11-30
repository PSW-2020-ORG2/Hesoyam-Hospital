using Backend.Model.PharmacyModel;
using Backend.Repository.Abstract.MiscAbstractRepository;
using Moq;
using System;
using System.Collections.Generic;

namespace IntegrationAdapterTests.Unit
{
    public class RegisteredPharmacyStubRepository
    {
        public static IRegisteredPharmacyRepository CreateRepository()
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

        public static List<ActionBenefit> CreateIncomingActionsAndBenefits()
        {
            List<ActionBenefit> receivedMessages = new List<ActionBenefit>();
            receivedMessages.Add(new ActionBenefit("Action", DateTime.Now));
            receivedMessages.Add(new ActionBenefit("Is", DateTime.Now));
            receivedMessages.Add(new ActionBenefit("Coming", DateTime.Now));
            receivedMessages.Add(new ActionBenefit("this winter", DateTime.Now));

            return receivedMessages;
        }

    }
}
