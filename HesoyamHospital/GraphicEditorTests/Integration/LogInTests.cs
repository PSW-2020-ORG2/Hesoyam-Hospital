using Xunit;
using Backend.Service.UsersService;

namespace GraphicEditorTests
{
    public class LogInTests
    {
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

    }
}
