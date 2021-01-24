using Appointments.DTOs;
using Appointments.Repository.Abstract;
using Appointments.Service;
using Appointments.Service.Abstract;
using Moq;
using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace WebApplicationTests.Unit.Appointments
{
    public class GetSuspiciousPatientsTests
    {
        [Fact]
        public void Get_accurate_count_of_suspicious_patients()
        {
            AppointmentService service = new AppointmentService(CreateAppointmentStubRepository(), CreateCancellationStubRepository());

            List<BlockPatientDTO> blockedPatients = service.GetSuspiciousPatients(CreateStubRequestSender());

            blockedPatients.Count.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void Get_suspicious_patients()
        {
            AppointmentService service = new AppointmentService(CreateAppointmentStubRepository(), CreateCancellationStubRepository());

            List<BlockPatientDTO> blockedPatients = service.GetSuspiciousPatients(CreateStubRequestSender());

            blockedPatients[0].Username.ShouldBe("perapera");
        }

        private static IAppointmentRepository CreateAppointmentStubRepository()
        {
            return new Mock<IAppointmentRepository>().Object;
        }

        private static ICancellationRepository CreateCancellationStubRepository()
        {
            var stubRepository = new Mock<ICancellationRepository>();

            Dictionary<long, int> patientCancellationCount = new Dictionary<long, int>
            {
                [0] = 3,
                [1] = 1
            };

            stubRepository.Setup(r => r.GetCancelledCountForPatients()).Returns(patientCancellationCount);

            return stubRepository.Object;
        }

        private static IHttpRequestSender CreateStubRequestSender()
        {
            var stubRequestSender = new Mock<IHttpRequestSender>();

            stubRequestSender.Setup(s => s.GetPatientUsername(0)).Returns("perapera");

            return stubRequestSender.Object;
        }
    }
}
