using System.Net.Http;
using System.Threading.Tasks;

namespace Medicines.Service.Abstract
{
    public interface IHttpRequestSender
    {
        public Task<string> SendRequest(string url, HttpMethod method);
        public string GetPatientFullName(long patientId);
        public string GetPatientUidn(long patientId);
    }
}
