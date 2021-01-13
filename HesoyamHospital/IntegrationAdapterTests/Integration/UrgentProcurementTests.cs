using System.Collections.Generic;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using IntegrationAdapter;
using Backend.Model.PharmacyModel;
using System.Net;
using System.Net.Http;
using Shouldly;
using Xunit.Abstractions;
using System.Text.Json;
using System.Text;
using System;
using Newtonsoft.Json;

namespace IntegrationAdapterTests.Integration
{
    public class UrgentProcurementTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public UrgentProcurementTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        [Theory]
        [MemberData(nameof(CreateUrgentRequest))]
        public async void Checks_creation_request_status(UrgentMedicineProcurement urgentMedicine,HttpStatusCode statusCode)
        {
            var client = _factory.CreateClient();
            StringContent body = new StringContent(System.Text.Json.JsonSerializer.Serialize(urgentMedicine), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/urgentmedicineprocurement/createrequest", body);
            response.StatusCode.ShouldBeEquivalentTo(statusCode);
            // uraditi rollback iz baze kad delete proradi
        }
        [Fact]
        public async void Check_medicine_bought_status()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/urgentmedicineprocurement/getmedicinebyid/2");
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }
        [Fact]
        public async void Check_medicine_concluded_status()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/urgentmedicineprocurement/getmedicinebyid/2");
            var urgentMedicine =await response.Content.ReadAsStringAsync();
            UrgentMedicineProcurement ur = JsonConvert.DeserializeObject<UrgentMedicineProcurement>(urgentMedicine);
            ur.Concluded.ShouldBeEquivalentTo(false);
        }
        public static IEnumerable<object[]> CreateUrgentRequest()
        {
            List<object[]> retVal = new List<object[]>();
            retVal.Add(new object[] { new UrgentMedicineProcurement(medicine: "Paracetamol", quantity: 20), HttpStatusCode.OK });
            retVal.Add(new object[] { new UrgentMedicineProcurement(medicine: "", quantity: 20), HttpStatusCode.BadRequest });
            return retVal;
        }
    }
}
