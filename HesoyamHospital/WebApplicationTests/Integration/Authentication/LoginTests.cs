using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using System.Net;
using Authentication.DTOs;
using System.Net.Http;
using Shouldly;
using Newtonsoft.Json;
using Authentication;

namespace WebApplicationTests.Integration.Authentication
{
    public class LoginTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public LoginTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void UnsuccessfulLoginNullObjectSent()
        {
            HttpClient client = _factory.CreateClient();
            StringContent bodyContent = new StringContent("", System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("/api/login/login", bodyContent);

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async void LoginPatient()
        {
            HttpClient client = _factory.CreateClient();
            UserLoginDTO patient = new UserLoginDTO("username", "password", "Patient");
            StringContent bodyContent = new StringContent(JsonConvert.SerializeObject(patient), System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("/api/login/login", bodyContent);

            HttpStatusCode[] possibleStatusCodes = { HttpStatusCode.OK, HttpStatusCode.NotFound, HttpStatusCode.BadRequest };
            response.StatusCode.ShouldBeOneOf(possibleStatusCodes);
        }

        [Fact]
        public async void LoginAdmin()
        {
            HttpClient client = _factory.CreateClient();
            UserLoginDTO admin = new UserLoginDTO("username", "password", "Admin");
            StringContent bodyContent = new StringContent(JsonConvert.SerializeObject(admin), System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("/api/login/login", bodyContent);

            HttpStatusCode[] possibleStatusCodes = { HttpStatusCode.OK, HttpStatusCode.NotFound, HttpStatusCode.BadRequest };
            response.StatusCode.ShouldBeOneOf(possibleStatusCodes);
        }
    }
}
