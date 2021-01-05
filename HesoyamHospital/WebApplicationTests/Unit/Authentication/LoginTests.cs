using Authentication.DTOs;
using Authentication.Exceptions;
using Authentication.Model;
using Authentication.Repository.Abstract;
using Authentication.Service;
using Moq;
using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace WebApplicationTests.Unit.Authentication
{
    public class LoginTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Unsuccessful_login_incorrect_username(UserLoginDTO user)
        {
            LoginService service = new LoginService(CreateStubPatientRepository(), CreateStubAdminRepository());

            Should.Throw<InvalidUsernameException>(() => service.LogIn(user));
        }

        [Theory]
        [MemberData(nameof(Data2))]
        public void Unsuccessful_login_incorrect_password(UserLoginDTO user)
        {
            LoginService service = new LoginService(CreateStubPatientRepository(), CreateStubAdminRepository());

            Should.Throw<InvalidPasswordException>(() => service.LogIn(user));
        }

        [Theory]
        [MemberData(nameof(Data3))]
        public void Successful_login(UserLoginDTO user)
        {
            LoginService service = new LoginService(CreateStubPatientRepository(), CreateStubAdminRepository());

            string token = service.LogIn(user);

            token.Length.ShouldBeGreaterThan(0);
        }

        private static IPatientRepository CreateStubPatientRepository()
        {
            var stubRepository = new Mock<IPatientRepository>();

            Patient patient = new Patient(1);
            patient.UserName = "pera";
            patient.Password = "pera";

            stubRepository.Setup(r => r.GetPatientByUsername("pera")).Returns(patient);

            return stubRepository.Object;
        }

        private static IAdminRepository CreateStubAdminRepository()
        {
            var stubRepository = new Mock<IAdminRepository>();

            SystemAdmin admin = new SystemAdmin(1);
            admin.UserName = "pera";
            admin.Password = "pera";

            stubRepository.Setup(r => r.GetByUsername("pera")).Returns(admin);

            return stubRepository.Object;
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { new UserLoginDTO("username", "password", "Patient") },
            new object[] { new UserLoginDTO("username", "password", "Admin") }
        };

        public static IEnumerable<object[]> Data2 =>
        new List<object[]>
        {
            new object[] { new UserLoginDTO("pera", "password", "Patient") },
            new object[] { new UserLoginDTO("pera", "password", "Admin") }
        };

        public static IEnumerable<object[]> Data3 =>
        new List<object[]>
        {
            new object[] { new UserLoginDTO("pera", "pera", "Patient") },
            new object[] { new UserLoginDTO("pera", "pera", "Admin") }
        };
    }
}
