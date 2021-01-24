using Authentication.Model;
using Authentication.Repository.Abstract;
using Authentication.Service;
using Moq;
using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace WebApplicationTests.Unit.Appointments
{
    public class BlockPatientsTest
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Blocking_suspicious_patients(Patient patient)
        {
            PatientService service = new PatientService(CreatePatientStubRepository(), null, null);

            Patient blockedPatient = service.BlockPatient(patient);

            blockedPatient.Blocked.ShouldBe(true);
        }

        private static IPatientRepository CreatePatientStubRepository()
        {
            return new Mock<IPatientRepository>().Object;
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { new Patient(0) }
        };
    }
}
