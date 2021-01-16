using System.Net.Http;
using System.Threading.Tasks;

namespace Documents.Service.Abstract
{
    public interface IHttpRequestSender
    {
        public Task<string> SendRequest(string url, HttpMethod method);
        public string GetDoctorFullName(long doctorId);
        public string GetDoctorSpecialisation(long doctorId);
    }
}
