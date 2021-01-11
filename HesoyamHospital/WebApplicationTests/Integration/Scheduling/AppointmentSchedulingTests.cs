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
using Moq;

namespace WebApplicationTests.Integration.Scheduling
{
    public class AppointmentSchedulingTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public AppointmentSchedulingTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        //[Theory]
        //[MemberData(nameof(DoctorTypeData))]
        //public async void Getting_all_doctors_for_selected_type(string type, HttpStatusCode expectedStatusCode)
        //{
        //    HttpClient client = _factory.CreateClient();

        //    HttpResponseMessage response = await client.GetAsync("/api/appointmentscheduling/getDoctorsByType/" + type);

        //    response.StatusCode.ShouldBeEquivalentTo(expectedStatusCode);
        //}

        //[Theory]
        //[MemberData(nameof(DoctorTimeData))]
        //public async void Getting_all_times_for_selected_date_and_doctor(DoctorDateDTO dto, HttpStatusCode expectedStatusCode)
        //{
        //    HttpClient client = _factory.CreateClient();
        //    StringContent bodyContent = new StringContent(JsonConvert.SerializeObject(dto), System.Text.Encoding.UTF8, "application/json");

        //    HttpResponseMessage response = await client.PutAsync("/api/appointmentscheduling/getTimesForDoctor", bodyContent);

        //    response.StatusCode.ShouldBeEquivalentTo(expectedStatusCode);
        //}

        //[Theory]
        //[MemberData(nameof(SelectedDoctorData))]
        //public async void Getting_appointments_for_selected_doctor(long id, HttpStatusCode expectedStatusCode)
        //{
        //    HttpClient client = _factory.CreateClient();

        //    HttpResponseMessage response = await client.GetAsync("/api/appointmentscheduling/getTimesForSelectedDoctor/" + id.ToString());

        //    response.StatusCode.ShouldBeEquivalentTo(expectedStatusCode);
        //}

        //[Theory]
        //[MemberData(nameof(PriorityData))]
        //public async void Getting_recommended_appointments(PriorityDTO dto, HttpStatusCode expectedStatusCode)
        //{
        //    HttpClient client = _factory.CreateClient();
        //    StringContent bodyContent = new StringContent(JsonConvert.SerializeObject(dto), System.Text.Encoding.UTF8, "application/json");

        //    HttpResponseMessage response = await client.PostAsync("/api/appointmentscheduling/recommendation", bodyContent);

        //    response.StatusCode.ShouldBeEquivalentTo(expectedStatusCode);
        //}

        //[Theory]
        //[MemberData(nameof(AppointmentData))]
        //public void Saving_appointment_to_database(AppointmentDTO dto, Times times)
        //{
        //    var appointmentService = new Mock<IAppointmentSchedulingService>();
        //    var controller = new AppointmentSchedulingController(appointmentService.Object);

        //    controller.SaveAppointment(dto);

        //    appointmentService.Verify(n => n.SaveAppointment(It.IsAny<Appointment>()), times);
        //}

        //[Theory]
        //[MemberData(nameof(AppointmentData))]
        //public void Saving_selected_doctor_appointment_to_database(AppointmentDTO dto, Times times)
        //{
        //    var appointmentService = new Mock<IAppointmentSchedulingService>();
        //    var controller = new AppointmentSchedulingController(appointmentService.Object);

        //    controller.SaveSelecetdDoctorAppointment(dto);

        //    appointmentService.Verify(n => n.SaveAppointment(It.IsAny<Appointment>()), times);
        //}

        public static IEnumerable<object[]> AppointmentData =>
           new List<object[]>
           {
                new object[] { new AppointmentDTO(500, new DateTime(2020, 12, 3, 8, 0, 0), 501), Times.Once()},
                new object[] { new AppointmentDTO(), Times.Never()},
                new object[] { null, Times.Never() },
           };


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

        public static IEnumerable<object[]> PriorityData =>
            new List<object[]>
            {
                new object[] { new PriorityDTO(501, new DateTime(), new DateTime(), true), HttpStatusCode.OK },
                new object[] { null, HttpStatusCode.BadRequest },
            };
    }
}
