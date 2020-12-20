using Backend;
using IntegrationAdapter.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Xunit;

namespace IntegrationAdapterTests.Integration
{
    public class PrescriptionSFTPTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        [Fact]
        public async void Generate_file_for_patient()
        {
            TherapyDTO dto = LoadDTO();
            HttpClient client = new HttpClient();
            StringContent body = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
            var response = await client.PutAsync("http://localhost:54574/api/medicinespecificationacquisition/prescription/markoFARM", body);
            string responseText = await response.Content.ReadAsStringAsync();
            responseText.Contains(dto.Comment).ShouldBe(true);
        }

        private static TherapyDTO LoadDTO()
        {
            TherapyDTO dto = new TherapyDTO();
            List<long> medicineIDs = new List<long>();
            medicineIDs.Add(1);
            dto.PatientID = 1;
            dto.DoctorID = 2;
            dto.DateCreated = DateTime.Now;
            dto.Comment = "there is no comment.";
            dto.StartTime = DateTime.Now.AddDays(1);
            dto.EndTime = DateTime.Now.AddDays(5);
            dto.MedicineIDs = medicineIDs;
            return dto;
        }
    }
}
