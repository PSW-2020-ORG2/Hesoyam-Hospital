using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using WebApplication;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Shouldly;
using WebApplication.Scheduling;
using System;
using Newtonsoft.Json;

namespace WebApplicationTests.Integration.Scheduling
{
    public class AppointmentSchedulingTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public AppointmentSchedulingTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [MemberData(nameof(DoctorTypeData))]
        public async void Getting_all_doctors_for_selected_type(string type, HttpStatusCode expectedStatusCode)
        {
            HttpClient client = _factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/appointmentscheduling/getDoctorsByType/" + type);

            response.StatusCode.ShouldBeEquivalentTo(expectedStatusCode);
        }

        [Theory]
        [MemberData(nameof(DoctorTimeData))]
        public async void Getting_all_times_for_selected_date_and_doctor(DoctorDateDTO dto, HttpStatusCode expectedStatusCode)
        {
            HttpClient client = _factory.CreateClient();
            StringContent bodyContent = new StringContent(JsonConvert.SerializeObject(dto), System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("/api/appointmentscheduling/getTimesForDoctor", bodyContent);

            response.StatusCode.ShouldBeEquivalentTo(expectedStatusCode);
        }

        [Theory]
        [MemberData(nameof(SelectedDoctorData))]
        public async void Getting_appointments_for_selected_doctor(long id, HttpStatusCode expectedStatusCode)
        {
            HttpClient client = _factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/appointmentscheduling/getTimesForSelectedDoctor/" + id.ToString());

            response.StatusCode.ShouldBeEquivalentTo(expectedStatusCode);
        }


        public static IEnumerable<object[]> DoctorTypeData =>
            new List<object[]>
            {
                new object[] { "GENERAL_PRACTITIONER", HttpStatusCode.OK },
                new object[] { "GENERAL_DOCTOR", HttpStatusCode.NotFound },
            };


        public static IEnumerable<object[]> DoctorTimeData =>
            new List<object[]>
            {
                new object[] { new DoctorDateDTO(501, new DateTime(2020, 12, 3)), HttpStatusCode.OK },
                new object[] { null, HttpStatusCode.BadRequest },
            };

        public static IEnumerable<object[]> SelectedDoctorData =>
            new List<object[]>
            {
                new object[] { 500, HttpStatusCode.OK },
                new object[] { 0, HttpStatusCode.BadRequest },
            };
    }
}
