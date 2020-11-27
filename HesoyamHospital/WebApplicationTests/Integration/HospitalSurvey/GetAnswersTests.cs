using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System.Net;
using Xunit;
using WebApplication;
using System.Net.Http;
using WebApplication.Documents;
using System;
using Backend.Util;
using System.Collections.Generic;
using Newtonsoft.Json;
using Backend.Model.UserModel;
using WebApplication.HospitalSurvey;

namespace WebApplicationTests.Integration.HospitalSurvey
{
    public class GetAnswersTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public GetAnswersTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        [Theory]
        [MemberData(nameof(Data))]
        public async void Getting_Answers_Status_Code_Tests(HttpStatusCode expectedStatusCode)
        {
            HttpClient client = _factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/survey/get-answers");

            response.StatusCode.ShouldBeEquivalentTo(expectedStatusCode);
        }
        [Theory]
        [MemberData(nameof(Data2))]
        public async void Getting_Answers_Per_Each_Doctor_Status_Code_Tests(int id , HttpStatusCode expectedStatusCode)
        {
            HttpClient client = _factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/survey/answers-per-doctors/" + id);

            response.StatusCode.ShouldBeEquivalentTo(expectedStatusCode);
        }

        [Theory]
        [MemberData(nameof(Data2))]
        public async void Getting_Average_Grade_Per_Each_Doctor_Status_Code_Tests(int id, HttpStatusCode expectedStatusCode)
        {
            HttpClient client = _factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/survey/average-grade-per-doctor/" + id);

            response.StatusCode.ShouldBeEquivalentTo(expectedStatusCode);
        }
        [Theory]
        [MemberData(nameof(Data))]
        public async void Mean_Values_Per_Section_Status_Code_Tests( HttpStatusCode expectedStatusCode)
        {
            HttpClient client = _factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/survey/mean-value-per-section" );

            response.StatusCode.ShouldBeEquivalentTo(expectedStatusCode);
        }

        [Theory]
        [MemberData(nameof(Data1))]
        public async void Mean_Values_Per_Questions_Status_Code_Tests(string section, HttpStatusCode expectedStatusCode)
        {
            HttpClient client = _factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/survey/mean-value-per-question/" + section);

            response.StatusCode.ShouldBeEquivalentTo(expectedStatusCode);
        }

        [Theory]
        [MemberData(nameof(Data1))]
        public async void Frequencies_Per_Answers_To_Questions_Status_Code_Tests(string section, HttpStatusCode expectedStatusCode)
        {
            HttpClient client = _factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/survey/frequencies-per-question/" + section);

            response.StatusCode.ShouldBeEquivalentTo(expectedStatusCode);
        }


        public static IEnumerable<object[]> Data =>
       new List<object[]>
       {
            new object[] {  HttpStatusCode.OK }
       };
        public static IEnumerable<object[]> Data1 =>
       new List<object[]>
       {
            new object[] {"Staff" , HttpStatusCode.OK},
            new object[] {"Scs", HttpStatusCode.BadRequest},
            new object[] { "Doctor" ,HttpStatusCode.OK }
       };
        public static IEnumerable<object[]> Data2 =>
       new List<object[]>
       {   
           new object[] { 356 , HttpStatusCode.BadRequest},
            new object[] { 600 , HttpStatusCode.OK}
            
       };

    }
}
