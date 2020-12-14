using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapter.SFTPServiceSupport
{
    public class SFTPService
    {
        private static readonly string serverIP = "192.168.1.103";
        private static readonly string user = "tester";
        private static readonly string password = "password"; 
        public static void ConnectAndSendPrescribedMedicineReport(string fileToSend,string prescriptionToSend)
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo(serverIP, user, password)))
            {
                client.Connect();
                if (fileToSend != "")
                {
                    using (Stream stream = File.OpenRead(fileToSend))
                    {
                        client.UploadFile(stream, @"\pharmacy_reports\" + Path.GetFileName(fileToSend), null);
                    }
                }else if(prescriptionToSend != "")
                {
                    using (Stream stream = File.OpenRead(prescriptionToSend))
                    {
                        client.UploadFile(stream, @"\prescriptions\" + Path.GetFileName(prescriptionToSend), null);
                    }
                }
                client.Disconnect();
            }
        }
        public static string ConnectAndReceiveSpecifications(string specificationToRead)
        {
            string text = "";
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo(serverIP, user, password)))
            {
                client.Connect();
                if (specificationToRead != "")
                    try
                    {
                        text = client.ReadAllText(@"\specifications\" + Path.GetFileName(specificationToRead));
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
