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
        public SFTPService()
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.1.92", "tester", "password")))
            {
                client.Connect();

                string fileToSend = @"C:\Users\Gox\Desktop\pswProject\Hesoyam-Hospital\HesoyamHospital\IntegrationAdapter\SFTPServiceSupport\TextFileReport.txt";
                using(Stream stream = File.OpenRead(fileToSend))
                {
                    client.UploadFile(stream, @"\pharmacy_reports\" + Path.GetFileName(fileToSend), null);
                }
                client.Disconnect();
            }
        }
    }
}
