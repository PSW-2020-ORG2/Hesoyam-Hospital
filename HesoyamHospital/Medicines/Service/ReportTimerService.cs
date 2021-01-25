using Microsoft.Extensions.Hosting;
using RestSharp;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.Hosting;
using Medicines.Service.Abstract;
using Medicines.Util;
using System.Collections.Generic;
using Medicines.DTOs;

namespace Medicines.Service
{
    public class ReportTimerService : BackgroundService
    {
        System.Timers.Timer generatorTimer = new System.Timers.Timer();
        private readonly ITherapyService _therapyService;
        private readonly IWebHostEnvironment _env;
        public ReportTimerService(ITherapyService therapyService, IWebHostEnvironment env)
        {
            _therapyService = therapyService;
            _env = env;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            WriteToFile("Service is started at " + DateTime.Now);
            return base.StartAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            generatorTimer.Elapsed += new ElapsedEventHandler(GenerateMessage);
            generatorTimer.Interval = 60000; //number in miliseconds  
            generatorTimer.Enabled = true;

            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            WriteToFile("Service is stopped at " + DateTime.Now);
            return base.StopAsync(cancellationToken);
        }

        private void GenerateMessage(object source, ElapsedEventArgs e)
        {
            WriteToFile("Generate message at " + DateTime.Now);
            string startupPath = System.IO.Directory.GetCurrentDirectory();
            string filePath = @"\PrescribedMedicineReport\prescribed_medicine_report.txt";
            PrescribedMedicineReportGenerator generator = new PrescribedMedicineReportGenerator(_therapyService);
            string report = generator.GenerateReport(new TimeInterval(DateTime.Now.AddDays(-7), DateTime.Now));
            using (StreamWriter sw = File.CreateText(startupPath + filePath))
            {
                sw.Write(report);
            }
            if (_env.IsDevelopment())
                SFTPService.ConnectAndSendPrescribedMedicineReport(startupPath + filePath);
            else
                SendHttpRequest(startupPath + filePath);
        }
        private static void SendHttpRequest(string filePath)
        {
            var pharmacyClient = new RestClient("http://localhost:60007");
            var pharmacyRequest = new RestRequest("/api/registerpharmacy/all");
            var pharmacyResponse = pharmacyClient.Get<List<RegisteredPharmacyDTO>>(pharmacyRequest);
            List<RegisteredPharmacyDTO> pharmacies = pharmacyResponse.Data;

            foreach(RegisteredPharmacyDTO pharmacy in pharmacies)
            {
                var prescriptionClient = new RestClient(pharmacy.Endpoint);
                var prescriptionRequest = new RestRequest("/prescription");
                prescriptionRequest.AddParameter("prescription", ReadFromFile(filePath));
                IRestResponse prescriptionResponse = prescriptionClient.Post(prescriptionRequest);
                Console.WriteLine("Status: " + prescriptionResponse.StatusCode.ToString());
            }
        }
        private static string ReadFromFile(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                return sr.ReadToEnd();
            }
        }
        public void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\SFTPLogs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\SFTPLogs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                try
                {
                    using (StreamWriter sw = File.AppendText(filepath))
                    {
                        sw.WriteLine(Message);
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
