using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using WebApplication;
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

        [Theory]
        [MemberData(nameof(Data))]
        public async void Observe_appointments_status_code(long patientId, HttpStatusCode expectedStatusCode)
        {
            HttpClient client = _factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/appointment/" + patientId);

            response.StatusCode.ShouldBeEquivalentTo(expectedStatusCode);
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { 400, HttpStatusCode.BadRequest },
            new object[] { 500, HttpStatusCode.OK }
        };
    }
}
