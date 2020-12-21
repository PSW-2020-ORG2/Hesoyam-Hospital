using Xunit;
using Backend.Model.UserModel;
using System.Collections.Generic;
using Backend.Service.UsersService;

namespace GraphicEditorTests
{
    public class LogInTests
    {
        [Fact]
        public void log_in_user()
        {
            UserService userService = Backend.AppResources.getInstance().userService;
            userService.Login("lenka", "lenka123");
            Assert.NotNull(Backend.AppResources.getInstance().loggedInUser);
        }

    }
}
