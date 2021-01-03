using Appointments.Service.Abstract;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Appointments.Service
{
    public class HttpRequestSender : IHttpRequestSender
    {
        public readonly IHttpClientFactory _clientFactory;

        public HttpRequestSender(IHttpClientFactory httpClientFactory)
        {
            _clientFactory = httpClientFactory;
        }
        public Task<string> SendRequest(string url, HttpMethod method)
        {
            var client = _clientFactory.CreateClient();
            var response = client.SendAsync(new HttpRequestMessage(method, url));
            return response.Result.Content.ReadAsStringAsync();
        }

        public string GetDoctorFullName(long doctorId)
        {
            var responseStream = SendRequest("http://localhost:57746/api/doctor/getFullName/" + doctorId, HttpMethod.Get);
            return responseStream.Result;
        }

        public string GetPatientUsername(long patientId)
        {
            var responseStream = SendRequest("http://localhost:57746/api/patient/getUsername/" + patientId, HttpMethod.Get);
            return responseStream.Result;
        }

        public string GetPatientFullName(long patientId)
        {
            var responseStream = SendRequest("http://localhost:57746/api/patient/getFullName/" + patientId, HttpMethod.Get);
            return responseStream.Result;
        }

        public bool IsBlocked(long patientId)
        {
            var responseStream = SendRequest("http://localhost:57746/api/patient/isBlocked/" + patientId, HttpMethod.Get);
            return JsonConvert.DeserializeObject<bool>(responseStream.Result);
        }

        public string GetDoctorSpecialization(long doctorId)
        {
            var responseStream = SendRequest("http://localhost:57746/api/doctor/getSpecialization/" + doctorId, HttpMethod.Get);
            return responseStream.Result;
        }

        public long GetTimeTableIdForDoctorId(long doctorId)
        {
            var responseStream = SendRequest("http://localhost:57746/api/doctor/getTimeTableId/" + doctorId, HttpMethod.Get);
            return JsonConvert.DeserializeObject<long>(responseStream.Result);
        }

        public List<long> GetSameSpecializationDoctorIds(long doctorId)
        {
            var responseStream = SendRequest("http://localhost:57746/api/doctor/getSameSpecialization/" + doctorId, HttpMethod.Get);
            return JsonConvert.DeserializeObject<List<long>>(responseStream.Result);
        }

        public long GetTimeTableIdForSelectedDoctor(long patientId)
        {
            var responseStream = SendRequest("http://localhost:57746/api/patient/getTimeTableForSelectedDoctor/" + patientId, HttpMethod.Get);
            return JsonConvert.DeserializeObject<long>(responseStream.Result);
        }

        public long GetRoomIdForDoctor(long doctorId)
        {
            var responseStream = SendRequest("http://localhost:57746/api/doctor/getRoomIdForDoctor/" + doctorId, HttpMethod.Get);
            return JsonConvert.DeserializeObject<long>(responseStream.Result);
        }

        public string GetRoomNumberById(long doctorId)
        {
            var responseStream = SendRequest("http://localhost:57746/api/doctor/getRoomNumberForDoctor/" + doctorId, HttpMethod.Get);
            return responseStream.Result;
        }

        public long GetSelectedDoctorId(long patientId)
        {
            var responseStream = SendRequest("http://localhost:57746/api/patient/getSelectedDoctorId/" + patientId, HttpMethod.Get);
            return JsonConvert.DeserializeObject<long>(responseStream.Result);
        }
    }
}
