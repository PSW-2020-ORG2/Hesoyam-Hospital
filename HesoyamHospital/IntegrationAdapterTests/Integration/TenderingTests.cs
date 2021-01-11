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
            StringContent body = new StringContent(System.Text.Json.JsonSerializer.Serialize(tender), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/tender/createtender", body);
            response.StatusCode.ShouldBeEquivalentTo(expectedCode);
        }
        /*[Fact]
        public async void Check_concluded_status()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/tender/active");
            var tenderOffer = await response.Content.ReadAsStringAsync();
            Tender tender = JsonConvert.DeserializeObject<Tender>(tenderOffer);
            tender.Concluded.ShouldBeEquivalentTo(false);
        }*/
        [Fact]
        public async void tender_concluding_before_time_runs_out()
        {
            var client = _factory.CreateClient();
            StringContent body = new StringContent(System.Text.Json.JsonSerializer.Serialize("mail@gmail.com"), Encoding.UTF8, "application/json");
            var response = await client.PutAsync("/api/tender/concludeTender/1/1", body);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.BadRequest);
        }
        [Fact]
        public async void check_if_tender_offer_created_successfully()
        {
            var client = _factory.CreateClient();
            StringContent body = new StringContent(System.Text.Json.JsonSerializer.Serialize(new TenderOffer(tenderId:1,email:"markov@gmail.com",list:CreateTenderOfferListing())), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/tenderoffer/createoffer", body);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }
        public static List<TenderOfferListing> CreateTenderOfferListing()
        {
            List<TenderOfferListing> list = new List<TenderOfferListing>();
            list.Add(new TenderOfferListing("Paracetamol", 3, 200));
            list.Add(new TenderOfferListing("Andol", 3, 400));
            return list;
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
