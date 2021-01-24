using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using System.Net;
using System.Net.Http;
using Shouldly;
using System;
using Newtonsoft.Json;
using Appointments;
using Appointments.DTOs;
using System.Text;

namespace WebApplicationTests.Integration.Scheduling
{
    public class AppointmentSchedulingTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public AppointmentSchedulingTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void Getting_all_times_for_selected_date_and_doctor_successful()
        {
            HttpClient client = _factory.CreateClient();
            StringContent bodyContent = new StringContent(JsonConvert.SerializeObject(new DoctorDateDTO(501, new DateTime(2020, 12, 3))), System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync("/api/appointmentscheduling/getTimesForDoctor", bodyContent);

            HttpStatusCode[] possibleStatusCodes = { HttpStatusCode.OK, HttpStatusCode.NotFound };
            response.StatusCode.ShouldBeOneOf(possibleStatusCodes);
        }

        [Fact]
        public async void Getting_all_times_for_selected_date_and_doctor_unsuccessful()
        {
            HttpClient client = _factory.CreateClient();
            StringContent bodyContent = new StringContent(JsonConvert.SerializeObject(null), System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync("/api/appointmentscheduling/getTimesForDoctor", bodyContent);

            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async void Getting_appointments_for_selected_doctor()
        {
            HttpClient client = _factory.CreateClient();
            long id = 0;

            HttpResponseMessage response = await client.GetAsync("/api/appointmentscheduling/getTimesForSelectedDoctor/" + id.ToString());

            HttpStatusCode[] possibleStatusCodes = { HttpStatusCode.OK, HttpStatusCode.NotFound };
            response.StatusCode.ShouldBeOneOf(possibleStatusCodes);
        }

        [Fact]
        public async void Getting_recommended_appointments_successful()
        {
            HttpClient client = _factory.CreateClient();
            StringContent bodyContent = new StringContent(JsonConvert.SerializeObject(new PriorityDTO(1501, new DateTime(), new DateTime(), true)), System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("/api/appointmentscheduling/recommendation", bodyContent);

            HttpStatusCode[] possibleStatusCodes = { HttpStatusCode.OK, HttpStatusCode.NotFound };
            response.StatusCode.ShouldBeOneOf(possibleStatusCodes);
        }

        [Fact]
        public async void Getting_recommended_appointments_unsuccessful()
        {
            HttpClient client = _factory.CreateClient();
            StringContent bodyContent = new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("/api/appointmentscheduling/recommendation", bodyContent);

            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }
    }
}
