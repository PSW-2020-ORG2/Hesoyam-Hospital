﻿using Microsoft.AspNetCore.Mvc.Testing;
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
using static System.Net.Mime.MediaTypeNames;
using System.Text;

namespace WebApplicationTests.Integration.Documents
{
    public class SearchDocumentsTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
   
        public SearchDocumentsTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async void Simple_search_status_code_tests(DocumentSearchCriteria criteria, HttpStatusCode expectedStatusCode)
        {
            HttpClient client = _factory.CreateClient();
            StringContent bodyContent = new StringContent(JsonConvert.SerializeObject(criteria), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("/api/document/simple-search", bodyContent);

            response.StatusCode.ShouldBeEquivalentTo(expectedStatusCode);
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { null, HttpStatusCode.BadRequest },
            new object[] { new DocumentSearchCriteria(true, true, new TimeInterval(DateTime.Now.AddDays(-5), DateTime.Now), "pera", "ABCD", "", ""), HttpStatusCode.OK }
        };
    }
}
