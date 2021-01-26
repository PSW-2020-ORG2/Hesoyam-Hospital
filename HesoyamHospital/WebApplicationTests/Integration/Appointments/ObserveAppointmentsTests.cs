using Appointments;
using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System.Net;
using System.Net.Http;
using Xunit;

namespace WebApplicationTests.Integration.Appointments
{
    public class ObserveAppointmentsTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public ObserveAppointmentsTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void Observe_appointments_status_code()
        {
            HttpClient client = _factory.CreateClient();
            long patientId = 500;

            HttpResponseMessage response = await client.GetAsync("/api/appointment/" + patientId);

            HttpStatusCode[] possibleStatusCodes = { HttpStatusCode.OK, HttpStatusCode.BadRequest };
            response.StatusCode.ShouldBeOneOf(possibleStatusCodes);
        }
    }
}
