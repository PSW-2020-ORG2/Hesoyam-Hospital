using Xunit;
using Backend.Service.UsersService;
using System.Collections;
using System.Windows.Documents;
using System.Collections.Generic;
using Backend.Model.UserModel;
using Shouldly;

namespace GraphicEditorTests
{
    public class LogInTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Checks_user_credentials(string userName, string password, bool expected)
        {
            UserService userService = Backend.AppResources.getInstance().userService;
            User user = userService.GetByUsername(userName);

            bool isUserFound = userService.CheckUserCredentials(user, password);

            isUserFound.ShouldBe(expected);
        }
        
        [Fact]
        public void Log_in_user()
        {
            UserService userService = Backend.AppResources.getInstance().userService;

            userService.Login("lenka", "lenka123");

            Assert.NotNull(Backend.AppResources.getInstance().loggedInUser);
        }


        [Fact]
        public void User_not_found()
        {
            UserService userService = Backend.AppResources.getInstance().userService;

            userService.Login("milos", "milos12345");

            Assert.Null(Backend.AppResources.getInstance().loggedInUser);
        }

        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[] {"lenka", "lenka123", true},
            new object[] {"milos", "milos12345", false}

        };
    }
}
