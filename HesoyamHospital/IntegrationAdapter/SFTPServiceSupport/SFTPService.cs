using Renci.SshNet;
using System.IO;

namespace IntegrationAdapter.SFTPServiceSupport
{
    public class SFTPService
    {
        public static void ConnectAndSendPrescribedMedicineReport(string fileToSend)
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.1.92", "tester", "password")))
            {
                client.Connect();

                using (Stream stream = File.OpenRead(fileToSend))
                {
                    client.UploadFile(stream, @"\pharmacy_reports\" + Path.GetFileName(fileToSend), null);
                }
                client.Disconnect();
            }
        }
    }
}
