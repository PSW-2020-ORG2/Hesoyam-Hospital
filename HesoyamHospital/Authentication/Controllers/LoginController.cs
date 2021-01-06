using Authentication.DTOs;
using Authentication.Exceptions;
using Authentication.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("login")]
        public IActionResult LogIn([FromBody] UserLoginDTO user)
        {
            if (user == null) return BadRequest();
            try
            {
                return Ok(_loginService.LogIn(user));
            }
            catch (InvalidUsernameException e)
            {
                return NotFound(e.Message);
            }
            catch (InvalidPasswordException e)
            {
                return NotFound(e.Message);
            }
            catch (InvalidRoleException e)
            {
                return BadRequest(e.Message);
            }
            catch (PatientBlockedException e)
            {
                return BadRequest(e.Message);
            }
            catch (PatientInactiveException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
