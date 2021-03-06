﻿using Backend;
using Backend.Util;
using IntegrationAdapter.MedicineReport;
using Microsoft.Extensions.Hosting;
using RestSharp;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.Hosting;

namespace IntegrationAdapter.SFTPServiceSupport
{
    public class ReportTimerService : BackgroundService
    {
        System.Timers.Timer generatorTimer = new System.Timers.Timer();
        private readonly IWebHostEnvironment _env;
        public ReportTimerService(IWebHostEnvironment env)
        {
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
            generatorTimer.Interval = 7000; //number in miliseconds  
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
            string filePath = @"\PrescribedMedicineReport\pharmacy_reports\prescribed_medicine_report.txt";
            PrescribedMedicineReportGenerator generator = new PrescribedMedicineReportGenerator(AppResources.getInstance().therapyService, startupPath + filePath);
            generator.GenerateReport(new TimeInterval(DateTime.Now.AddDays(-7), DateTime.Now));
            if(_env.IsDevelopment())
                SFTPService.ConnectAndSendPrescribedMedicineReport(startupPath + filePath);
            else
                SendHttpRequest(startupPath + filePath);
        }
        private static void SendHttpRequest(string filePath)
        {
            var client = new RestSharp.RestClient("http://localhost:8080");
            var request = new RestRequest("/prescribedmedicinereport");

            request.AddParameter("file", ReadFromFile(filePath));
            IRestResponse response = client.Post(request);
            Console.WriteLine("Status: " + response.StatusCode.ToString());
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
                // Create a file to write to.   
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
