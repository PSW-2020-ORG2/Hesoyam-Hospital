using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System.Net;
using System.Net.Http;
using System;
using System.Text;
using WebApplication;
using Xunit;
using System.Collections.Generic;

namespace WebApplicationTests.Integration.Appointments
{
    public class BlockPatientsTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public BlockPatientsTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void Get_list_of_patients_with_three_or_more_cancellations()
        {
            HttpClient client = _factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/appointment/getSuspiciousPatients");

            HttpStatusCode[] possibleStatusCodes = { HttpStatusCode.OK, HttpStatusCode.NotFound };
            response.StatusCode.ShouldBeOneOf(possibleStatusCodes);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async void Block_suspicious_patient(string patientUsername, HttpStatusCode httpStatusCode)
        {
            HttpClient client = _factory.CreateClient();

            HttpResponseMessage response = await client.PutAsync("/api/appointment/block/" + patientUsername, new StringContent(""));

            response.StatusCode.ShouldBe(httpStatusCode);
        }


        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { "username", HttpStatusCode.BadRequest }
        };
    }
}
