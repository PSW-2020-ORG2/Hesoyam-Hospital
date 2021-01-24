using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System.Net;
using System.Net.Http;
using Xunit;
using Authentication;

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
        public async void Block_suspicious_patient()
        {
            HttpClient client = _factory.CreateClient();
            string patientUsername = "username";

            HttpResponseMessage response = await client.PutAsync("/api/patient/block/" + patientUsername, new StringContent(""));

            HttpStatusCode[] possibleStatusCodes = { HttpStatusCode.OK, HttpStatusCode.BadRequest };
            response.StatusCode.ShouldBeOneOf(possibleStatusCodes);
        }
    }
}
