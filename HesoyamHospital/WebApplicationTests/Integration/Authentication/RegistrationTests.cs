using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System.Net;
using Xunit;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Authentication;
using Authentication.DTOs;
using Authentication.Service;

namespace WebApplicationTests.Integration.Authentication
{
    public class RegistrationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public RegistrationTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void Registration_tests()
        {
            HttpClient client = _factory.CreateClient();
            NewPatientDTO newPatient = new NewPatientDTO("Emina", "Turkovic", "Mirsad", "FEMALE", "team.psw18@gmail.com", new SendEmailService().RandomString(10, false), "perapera", new DateTime(1998, 11, 9), "27100785057", "0911998777025", "0605552233", "033244377", "A_NEGATIVE", new List<string>(), "Serbia", "Priboj", "Alekse Santica 4");
            StringContent bodyContent = new StringContent(JsonConvert.SerializeObject(newPatient), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("/api/registration", bodyContent);

            HttpStatusCode[] possibleStatusCodes = { HttpStatusCode.OK, HttpStatusCode.BadRequest };
            response.StatusCode.ShouldBeOneOf(possibleStatusCodes);
        }
    }
}
