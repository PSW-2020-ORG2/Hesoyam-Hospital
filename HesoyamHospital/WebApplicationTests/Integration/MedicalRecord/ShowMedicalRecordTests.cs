using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System.Net;
using Xunit;
using System.Net.Http;
using Authentication;

namespace WebApplicationTests.Integration.MedicalRecords
{
    public class ShowMedicalRecordTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public ShowMedicalRecordTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void Medical_record_status_code_test()
        {
            HttpClient client = _factory.CreateClient();
            long id = 1500;

            var response = await client.GetAsync("/api/medicalrecord/show/" + id);

            HttpStatusCode[] possibleStatusCodes = { HttpStatusCode.OK, HttpStatusCode.NotFound };
            response.StatusCode.ShouldBeOneOf(possibleStatusCodes);
        }
    }
}
