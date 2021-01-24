using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using EventSourcing;
using System.Net.Http;
using System.Net;
using Shouldly;

namespace WebApplicationTests.Integration.Scheduling
{
    public class SchedulingProcessAnalysisTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public SchedulingProcessAnalysisTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void Get_percentage_of_successfully_scheduled_appointments()
        {
            HttpClient client = _factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/schedulingevent/percentage-of-successful");

            HttpStatusCode[] possibleStatusCodes = { HttpStatusCode.OK, HttpStatusCode.BadRequest};
            response.StatusCode.ShouldBeOneOf(possibleStatusCodes);
        }

        [Fact]
        public async void Get_percentage_of_going_back_by_step()
        {
            HttpClient client = _factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/schedulingevent/percentage-of-going-back-by-step");

            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        [Fact]
        public async void Get_average_number_of_steps_per_scheduling()
        {
            HttpClient client = _factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/schedulingevent/mean-value-of-steps-per-scheduling");

            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        [Fact]
        public async void Get_average_number_of_back_steps_per_scheduling()
        {
            HttpClient client = _factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/schedulingevent/mean-value-of-back-steps-per-scheduling");

            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        [Fact]
        public async void Get_percentage_of_quitting_by_step()
        {
            HttpClient client = _factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/schedulingevent/percantage-of-quitting-by-step");

            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        [Fact]
        public async void Get_average_time_needed_for_scheduling()
        {
            HttpClient client = _factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/schedulingevent/average-time-for-scheduling");

            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        [Fact]
        public async void Get_average_time_needed_for_successful_scheduling()
        {
            HttpClient client = _factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/schedulingevent/average-time-for-successful-scheduling");

            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        [Fact]
        public async void Get_average_time_needed_for_unsuccessful_scheduling()
        {
            HttpClient client = _factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/schedulingevent/average-time-for-unsuccessful-scheduling");

            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        [Fact]
        public async void Get_average_time_needed_for_each_step()
        {
            HttpClient client = _factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/schedulingevent/average-time-for-each-step");

            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }
    }
}
