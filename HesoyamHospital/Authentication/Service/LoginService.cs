using Authentication.DTOs;
using Authentication.Exceptions;
using Authentication.Model;
using Authentication.Repository.Abstract;
using Authentication.Service.Abstract;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication.Service
{
    public class LoginService : ILoginService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IAdminRepository _adminRepository;

        public LoginService(IPatientRepository patientRepository, IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
            _patientRepository = patientRepository;
        }
        public string LogIn(UserLoginDTO user)
        {
            User currentUser;
            if (user.Role.Equals("Patient"))
            {
                currentUser = PatientExists(user.Username, user.Password);

            }
            else if (user.Role.Equals("Admin"))
            {
                currentUser = AdminExists(user.Username, user.Password);
            }
            else throw new InvalidRoleException("Role " + user.Role + " is not supported");
            return GenerateJwtToken(currentUser, user.Role);
        }

        private User PatientExists(string username, string password)
        {
            Patient patient = _patientRepository.GetPatientByUsername(username);
            if (patient == null)
                throw new InvalidUsernameException("Patient with the given username does not exist. Try again!");
            if (!patient.Password.Equals(password))
                throw new InvalidPasswordException("Password is incorrect.");
            if (patient.Blocked)
                throw new PatientBlockedException("Your account is blocked. You are not allowed to log in!");
            if (!patient.Active)
                throw new PatientInactiveException("Your account has not been activated. Go check your mail!");
            return patient;
        }

        private User AdminExists(string username, string password)
        {
            SystemAdmin admin = _adminRepository.GetByUsername(username);
            if (admin == null)
                throw new InvalidUsernameException("System administrator with the given username does not exist. Try again!");
            if (!admin.Password.Equals(password))
                throw new InvalidPasswordException("Password is incorrect.");
            return admin;
        }

        private string GenerateJwtToken(User user, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SecretKey")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
            new Claim("Role", role)
            };

            var token = new JwtSecurityToken(
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials,
              claims: claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
