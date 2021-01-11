using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Repository.Abstract.UsersAbstractRepository;
using Moq;
using Shouldly;
using System.Collections.Generic;
using WebApplication.Appointments.Service;
using Xunit;

namespace WebApplicationTests.Unit.Appointments
{
    public class CancelAppointmentsTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Cancel_appointment(long patientId, long appointmentId, bool canceledStatus)
        {
            AppointmentService service = new AppointmentService(CreatePatientStubRepository(), CreateAppointmentStubRepository(), CreateCancellationStubRepository());

            service.Cancel(patientId, appointmentId);

            service.GetByID(appointmentId).Canceled.ShouldBe(canceledStatus);
        }

        private static IPatientRepository CreatePatientStubRepository()
        {
            var stubRepository = new Mock<IPatientRepository>();

            Patient patient = new Patient(0)
            {
                Appointments = new List<Appointment>()
            };
            patient.Appointments.Add(Appointment);

            stubRepository.Setup(r => r.GetByID(0)).Returns(patient);

            return stubRepository.Object;
        }

        private static IAppointmentRepository CreateAppointmentStubRepository()
        {
            var stubRepository = new Mock<IAppointmentRepository>();

            stubRepository.Setup(r => r.GetByID(0)).Returns(Appointment);

            return stubRepository.Object;
        }

        private static ICancellationRepository CreateCancellationStubRepository()
        {
            return new Mock<ICancellationRepository>().Object;
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { 0, 0, true },
        };

        public static Appointment Appointment =>
        new Appointment()
        {
            Canceled = false
        };
    }
}
