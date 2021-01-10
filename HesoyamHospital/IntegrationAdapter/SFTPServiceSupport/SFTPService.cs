using IntegrationAdapter.SMTPServiceSupport;
using Renci.SshNet;
using System;
using System.IO;

namespace IntegrationAdapter.SFTPServiceSupport
{
    public class SFTPService
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
                    SMTPNotificationSender.SendMessageToAllPharmacies("heshospital@gmail.com",
                                                                      "Weekly report about medicine consumption in Hesoyam hospital",
                                                                      "Report has been successfully sent to all pharmacies.");
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
                    client.UploadFile(stream, filePath, uploaded =>
                    {
                        Console.WriteLine($"Uploaded {Math.Round((double)uploaded / stream.Length * 100)}% of the file.");
                    });
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
