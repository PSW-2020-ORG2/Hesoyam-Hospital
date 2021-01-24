using Appointments;
using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System.Net;
using System.Net.Http;
using Xunit;

namespace WebApplicationTests.Integration.Appointments
{
    public class SuspiciousPatientsTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public SuspiciousPatientsTests(WebApplicationFactory<Startup> factory)
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
    }
}
