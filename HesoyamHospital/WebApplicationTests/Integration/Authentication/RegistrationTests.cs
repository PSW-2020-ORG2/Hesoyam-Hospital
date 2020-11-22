﻿using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System.Net;
using Xunit;
using WebApplication;
using System.Net.Http;
using System;
using Backend.Util;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using WebApplication.Authentication;

namespace WebApplicationTests.Integration.Authentication
{
    public class RegistrationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public RegistrationTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async void Registration_Tests(NewPatientDTO newPatient, HttpStatusCode expectedStatusCode)
        {
            HttpClient client = _factory.CreateClient();
            StringContent bodyContent = new StringContent(JsonConvert.SerializeObject(newPatient));

            HttpResponseMessage response = await client.PostAsync("/api/registration", bodyContent);

            response.StatusCode.ShouldBeEquivalentTo(expectedStatusCode);
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { null, HttpStatusCode.InternalServerError },
            new object[] { new NewPatientDTO("Emina", "Turkovic", "Mirsad", "FEMALE", "team.psw18@gmail.com", "eminaturk", "perapera", new DateTime(1998, 11, 9), "27100785057", "0911998777025", "0605552233", "033244377", "A_NEGATIVE", new List<string>(), "Serbia", "Priboj", "Alekse Santica 4"), HttpStatusCode.OK }
        };
    }
}
