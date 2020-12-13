using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Repository.Abstract.UsersAbstractRepository;
using Backend.Repository.MySQLRepository.UsersRepository;
using Moq;
using Shouldly;
using System.Collections.Generic;
using WebApplication.Appointments.Service;
using Xunit;

namespace WebApplicationTests.Unit.Appointments
{
    public class BlockPatientsTest
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Blocking_suspicious_patients(Patient patient)
        {
            AppointmentService service = new AppointmentService(CreatePatientStubRepository(), CreateAppointmentStubRepository(), CreateCancellationStubRepository());

            Patient blockedPatient = service.BlockPatient(patient);

            blockedPatient.Blocked.ShouldBe(true);
        }

        private static IPatientRepository CreatePatientStubRepository()
        {
            return new Mock<IPatientRepository>().Object;
        }

        private static IAppointmentRepository CreateAppointmentStubRepository()
        {
            return new Mock<IAppointmentRepository>().Object;
        }

        private static ICancellationRepository CreateCancellationStubRepository()
        {
            return new Mock<ICancellationRepository>().Object;
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { new Patient(0) }
        };
    }
}
