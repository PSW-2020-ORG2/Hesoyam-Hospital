using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System.Net;
using Xunit;
using System.Net.Http;
using System.Collections.Generic;
using Authentication;

namespace WebApplicationTests.Integration.Authentication
{
    public class ActivationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public ActivationTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void Account_activation_by_id()
        {
            HttpClient client = _factory.CreateClient();
            long id = 1501;
            string prefix = "acdxFDRhijklmno88st3";
            string path = "/api/registration/activate/" + prefix + id.ToString();

            HttpResponseMessage response = await client.PostAsync(path, null);

            HttpStatusCode[] possibleStatusCodes = { HttpStatusCode.OK, HttpStatusCode.NotFound, HttpStatusCode.BadRequest };
            response.StatusCode.ShouldBeOneOf(possibleStatusCodes);
        }
    }
}
