using Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Xunit;

namespace WebApplicationTests.Integration.Authentication
{
    public class DoctorTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public DoctorTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [MemberData(nameof(DoctorTypeData))]
        public async void Getting_all_doctors_for_selected_type(string type)
        {
            HttpClient client = _factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/doctor/getDoctorsByType/" + type);

            HttpStatusCode[] possibleStatusCodes = { HttpStatusCode.OK, HttpStatusCode.NotFound };
            response.StatusCode.ShouldBeOneOf(possibleStatusCodes);
        }

        public static IEnumerable<object[]> DoctorTypeData =>
            new List<object[]>
            {
                new object[] { "GENERAL_PRACTITIONER" },
                new object[] { "GENERAL_DOCTOR" }
            };
    }
}
