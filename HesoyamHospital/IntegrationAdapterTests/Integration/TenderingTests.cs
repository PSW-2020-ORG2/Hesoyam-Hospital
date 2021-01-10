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

namespace IntegrationAdapterTests.Integration
{
    public class TenderingTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public TenderingTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        [Theory]
        [MemberData(nameof(CreateTender))]
        public async void Checks_tender_creation_status_codes(Tender tender,HttpStatusCode expectedCode)
        {
            var client = _factory.CreateClient();
            StringContent body = new StringContent(JsonSerializer.Serialize(tender), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/tender/createtender", body);
            response.StatusCode.ShouldBeEquivalentTo(expectedCode);
        }

        public static IEnumerable<object[]> CreateTender()
        {
            List<object[]> retVal = new List<object[]>();
            retVal.Add(new object[] { new Tender(listing:new List<TenderListing>(),endDate:DateTime.Now.AddDays(19)), HttpStatusCode.BadRequest });
            retVal.Add(new object[] { new Tender(listing:CreateTenderListing(), endDate: DateTime.Now.AddDays(-2)), HttpStatusCode.BadRequest });
            return retVal;
        }

        public static List<TenderListing> CreateTenderListing()
        {
            List<TenderListing> tenderListingList = new List<TenderListing>();
            TenderListing tenderListing = new TenderListing();
            tenderListing.Medicine = "Paracetamol";
            tenderListing.Quantity = 10;
            TenderListing tenderListing2 = new TenderListing();
            tenderListing2.Medicine = "Andol";
            tenderListing2.Quantity = 6;
            tenderListingList.Add(tenderListing);
            tenderListingList.Add(tenderListing2);
            return tenderListingList;
        }
    }
}
