using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System.Net;
using Xunit;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using Feedbacks;
using Feedbacks.DTOs;

namespace WebApplicationTests.Integration.HospitalSurvey
{
    public class SendAnswersTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public SendAnswersTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async void Sending_answers_status_code_tests(SurveyDTO dto)
        {
            HttpClient client = _factory.CreateClient();
            StringContent bodyContent = new StringContent(JsonConvert.SerializeObject(dto), System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("/api/survey/send-answers/0", bodyContent);

            HttpStatusCode[] possibleStatusCodes = { HttpStatusCode.OK, HttpStatusCode.BadRequest };
            response.StatusCode.ShouldBeOneOf(possibleStatusCodes);
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { null },
            new object[] { new SurveyDTO( 1, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5) },
            new object[] { new SurveyDTO( 1, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 8) }
        };
    }
}
