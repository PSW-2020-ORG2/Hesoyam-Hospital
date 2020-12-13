using Backend;
using Backend.Util;
using IntegrationAdapter.MedicineReport;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace IntegrationAdapter.SFTPServiceSupport
{
    public class SFTPTimerService : BackgroundService
    {
        System.Timers.Timer generatorTimer = new System.Timers.Timer();

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
            SFTPService.ConnectAndSendPrescribedMedicineReport(startupPath + filePath,"");
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
