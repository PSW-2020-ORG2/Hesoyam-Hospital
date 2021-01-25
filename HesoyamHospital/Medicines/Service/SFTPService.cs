using Renci.SshNet;
using System;
using System.IO;

namespace Medicines.Service
{
    public static class SFTPService
    {
        private static readonly string serverIP = Environment.GetEnvironmentVariable("SFTPServerIPAddress");
        private static readonly string user = Environment.GetEnvironmentVariable("SFTPUsername");
        private static readonly string password = Environment.GetEnvironmentVariable("SFTPPassword");
        public static void ConnectAndSendPrescribedMedicineReport(string fileToSend)
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo(serverIP, user, password)))
            {
                client.Connect();
                using (Stream stream = File.OpenRead(fileToSend))
                {
                    client.UploadFile(stream, @"\pharmacy_reports\" + Path.GetFileName(fileToSend));
                    SMTPNotificationSender.SendMessage(Environment.GetEnvironmentVariable("HospitalEmail"),
                                                       Environment.GetEnvironmentVariable("HospitalEmailPassword"),
                                                       Environment.GetEnvironmentVariable("HospitalEmail"),
                                                       "Weekly report about medicine consumption in Hesoyam hospital",
                                                       "Report has been successfully sent to the server.");
                }
                client.Disconnect();
            }
        }
        public static void ConnectAndSendPrescription(string prescriptionToSend)
        {
            string filePath = @"\prescriptions\" + Path.GetFileName(prescriptionToSend);

            using (SftpClient client = new SftpClient(new PasswordConnectionInfo(serverIP, user, password)))
            {
                client.Connect();
                using (Stream stream = File.OpenRead(prescriptionToSend))
                {
                    client.UploadFile(stream, filePath);
                }
                client.Disconnect();

                if (File.Exists(prescriptionToSend))
                {
                    File.Delete(prescriptionToSend);
                }
            }
        }
        public static string ConnectAndReceiveSpecifications(string specificationToRead)
        {
            string text = "";
            string filePath = @"\specifications\" + Path.GetFileName(specificationToRead);
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo(serverIP, user, password)))
            {
                client.Connect();
                if (specificationToRead != "")
                    try
                    {
                        text = client.ReadAllText(filePath);
                    }
                    catch
                    {
                        Console.WriteLine("File not found!");
                        text = "Specification not found. Please try again.";
                    }
                    finally
                    {
                        client.Disconnect();
                    }
            }

            return text;
        }
    }
}
