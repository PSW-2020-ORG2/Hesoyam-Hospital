using Authentication.Controllers;
using Authentication.DTOs;
using Authentication.Model;
using Authentication.Repository.FileRepository;
using Authentication.Service;
using Authentication.Service.Abstract;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;

namespace WebApplicationTests.Unit.Authentication
{
    public class EmailServiceTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Token_to_id(string token, long id)
        {
            long patientId = new SendEmailService().TokenToId(token);

            patientId.ShouldBe(id);
        }

        [Fact]
        public void Id_to_token_to_id()
        {
            long patientId = new SendEmailService().TokenToId(new SendEmailService().CreateToken(35));

            patientId.ShouldBe(35);
        }

        [Fact]
        public void Sends_email_for_account_activation()
        {
            var sendEmail = new Mock<ISendEmailService>();
            var controller = new RegistrationController(sendEmail.Object, new Mock<ImageRepository>().Object, CreatePatientService(), CreateMedicalRecordService());

            controller.Add(new NewPatientDTO("Emina", "Turkovic", "Mirsad", "FEMALE", "team.psw18@gmail.com", new SendEmailService().RandomString(10, false), "perapera", new DateTime(1998, 11, 9), "27100785057", "0911998777025", "0605552233", "033244377", "A_NEGATIVE", new List<string>(), "Serbia", "Priboj", "Alekse Santica 4"));

            sendEmail.Verify(n => n.SendActivationEmail(It.IsAny<long>(), It.IsAny<string>()), Times.Once);
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { "xD3gRfdE349oO0PwcDEi35", 35 },
            new object[] { "xD3cDEi35", 0 },
            new object[] { "xD3gRfdE349oO0PwcDEi35w", 0 }
        };

        private static IPatientService CreatePatientService()
        {
            var patientService = new Mock<IPatientService>();

            patientService.Setup(r => r.GetAll()).Returns(new List<Patient>());

            return patientService.Object;
        }

        private static IMedicalRecordService CreateMedicalRecordService()
        {
            var medicalRecordService = new Mock<IMedicalRecordService>();

            MedicalRecord mr = new MedicalRecord(0)
            {
                Patient = new Patient(0)
                {
                    Email1 = "email@gmail.com"
                }
            };
            medicalRecordService.Setup(r => r.Create(new MedicalRecord(0))).Returns(mr);

            return medicalRecordService.Object;
        }
    }
}
