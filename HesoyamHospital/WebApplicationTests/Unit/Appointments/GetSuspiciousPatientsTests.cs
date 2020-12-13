using Backend.Model.UserModel;
using Backend.Repository.Abstract.UsersAbstractRepository;
using Moq;
using Shouldly;
using System.Collections.Generic;
using Xunit;
using WebApplication.Appointments.Service;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using WebApplication.Appointments.DTOs;
using Backend.Model.PatientModel;

namespace WebApplicationTests.Unit.Appointments
{
    public class GetSuspiciousPatientsTests
    {

        [Fact]
        public void Get_accurate_count_of_suspicious_patients()
        {
            AppointmentService service = new AppointmentService(CreateStubRepository(), CreateAppointmentStubRepository(), CreateCancellationStubRepository());

            List<BlockPatientDTO> blockedPatients = service.GetSuspiciousPatients();

            blockedPatients.Count.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void Get_suspicious_patients()
        {
            AppointmentService service = new AppointmentService(CreateStubRepository(), CreateAppointmentStubRepository(), CreateCancellationStubRepository());

            List<BlockPatientDTO> blockedPatients = service.GetSuspiciousPatients();

            blockedPatients[0].Username.ShouldBe("perapera");
        }


        private static IPatientRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IPatientRepository>();
            Patient patient1 = new Patient(0);
            patient1.Appointments = new List<Appointment>();
            patient1.UserName = "perapera";
            patient1.Name = "Pera";
            patient1.Surname = "Peric";
            patient1.Blocked = false;
            Patient patient2 = new Patient(1);
            patient2.Appointments = new List<Appointment>();
            patient2.UserName = "mikamika";
            patient2.Name = "Mika";
            patient2.Surname = "Mikic";
            patient2.Blocked = false;

            stubRepository.Setup(r => r.GetPatientByUsername("perapera")).Returns(patient1);
            stubRepository.Setup(r => r.GetPatientByUsername("mikamika")).Returns(patient2);
            stubRepository.Setup(r => r.GetByID(0)).Returns(patient1);
            stubRepository.Setup(r => r.GetByID(1)).Returns(patient2);

            return stubRepository.Object;
        }

        private static IAppointmentRepository CreateAppointmentStubRepository()
        {
            return new Mock<IAppointmentRepository>().Object;
        }

        private static ICancellationRepository CreateCancellationStubRepository()
        {
            var stubRepository = new Mock<ICancellationRepository>();

            Dictionary<long, int> patientCancellationCount = new Dictionary<long, int>();
            patientCancellationCount[0] = 3;
            patientCancellationCount[1] = 1;

            stubRepository.Setup(r => r.GetCancelledCountForPatients()).Returns(patientCancellationCount);

            return stubRepository.Object;
        }
    }
}
