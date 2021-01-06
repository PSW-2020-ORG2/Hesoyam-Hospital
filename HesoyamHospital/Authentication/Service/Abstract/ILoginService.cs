using Authentication.DTOs;

namespace Authentication.Service.Abstract
{
    public interface ILoginService
    {
        public string LogIn(UserLoginDTO user);
    }
}
