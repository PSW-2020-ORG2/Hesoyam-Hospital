using Documents.Service.Abstract;
using System.Net.Http;
using System.Threading.Tasks;

namespace Documents.Service
{
    public class HttpRequestSender : IHttpRequestSender
    {
        public readonly IHttpClientFactory _clientFactory;

        public HttpRequestSender(IHttpClientFactory httpClientFactory)
        {
            _clientFactory = httpClientFactory;
        }

        public string GetDoctorFullName(long doctorId)
        {
            var responseStream = SendRequest("http://localhost:57746/api/doctor/getFullName/" + doctorId, HttpMethod.Get);
            return responseStream.Result;
        }

        public Task<string> SendRequest(string url, HttpMethod method)
        {
            var client = _clientFactory.CreateClient();
            var response = client.SendAsync(new HttpRequestMessage(method, url));
            return response.Result.Content.ReadAsStringAsync();
        }
    }
}
