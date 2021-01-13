using Backend;
using IntegrationAdapter.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using Renci.SshNet;
using Shouldly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationAdapterTests.Integration
{
    public class PrescriptionSFTPTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private const string serverIP = "192.168.1.6";
        private const string user = "tester";
        private const string password = "password";
        [Fact]
        public async void Check_if_doctor_comment_is_correct()
        {
            string responseText = await Generate_file_for_patient();
            responseText.Contains("there is no comment.");
        }


        [Fact]
        public async void Check_if_patientID_is_correct()
        {
            string responseText = await Generate_file_for_patient();
            string jmbgResponse = responseText.Split(',')[1];
            jmbgResponse.Substring(8, 12).ShouldBe("111111111111");
        }

        [Fact]
        public async void Read_specification_successfully()
        {
            string path = "test.txt";
            SftpClient client = new SftpClient(new PasswordConnectionInfo(serverIP, user, password));
            client.Connect();
            string text = client.ReadAllText(@"\specifications\" + Path.GetFileName(path));
            client.Disconnect();
            text.ShouldBe("test to pass");
        }
        [Fact]
        public async void Fail_to_read_specification()
        {

            string text = "";
            SftpClient client = new SftpClient(new PasswordConnectionInfo(serverIP, user, password));
            client.Connect();
            try
            {
                text = client.ReadAllText(@"\specifications\" + Path.GetFileName("random_file"));
            }
            catch
            {
                text = "File not found";
            }
            finally
            {
                client.Disconnect();
            }
            text.ShouldBe("File not found");
        }
        private static async Task<string> Generate_file_for_patient()
        {
            TherapyDTO dto = LoadDTO();
            HttpClient client = new HttpClient();
            StringContent body = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
            var response = await client.PutAsync("http://localhost:54574/api/medicinespecificationacquisition/prescription/markoFARM", body);
            string responseText = await response.Content.ReadAsStringAsync();
            return responseText;
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
