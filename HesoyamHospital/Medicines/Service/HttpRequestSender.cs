using Medicines.Service.Abstract;
using System.Net.Http;
using System.Threading.Tasks;

namespace Medicines.Service
{
    public class HttpRequestSender : IHttpRequestSender
    {
        public readonly IHttpClientFactory _clientFactory;

        public HttpRequestSender(IHttpClientFactory httpClientFactory)
        {
            _clientFactory = httpClientFactory;
        }

        public string GetPatientFullName(long patientId)
        {
            var responseStream = SendRequest("http://localhost:57746/api/patient/getFullName/" + patientId, HttpMethod.Get);
            return responseStream.Result;
        }

        public string GetPatientUidn(long patientId)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> SendRequest(string url, HttpMethod method)
        {
            var client = _clientFactory.CreateClient();
            var response = client.SendAsync(new HttpRequestMessage(method, url));
            return response.Result.Content.ReadAsStringAsync();
        }
    }
}
