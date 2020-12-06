using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System.Net;
using System.Net.Http;
using System.Text;
using WebApplication;
using Xunit;

namespace WebApplicationTests.Integration.Appointments
{
    public class CancelAppointmentsTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public CancelAppointmentsTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void Cancel_appointment()
        {
            HttpClient client = _factory.CreateClient();

            HttpResponseMessage response = await client.PutAsync("/api/appointment/cancel", new StringContent("1", Encoding.UTF8, "application/json"));

            HttpStatusCode[] possibleStatusCodes = { HttpStatusCode.OK, HttpStatusCode.NotFound};
            response.StatusCode.ShouldBeOneOf(possibleStatusCodes);
        }
    }
}
