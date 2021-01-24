using Feedbacks.Service.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Feedbacks.Service
{
    public class HttpRequestSender : IHttpRequestSender
    {
        public readonly IHttpClientFactory _clientFactory;

        public HttpRequestSender(IHttpClientFactory httpClientFactory)
        {
            _clientFactory = httpClientFactory;
        }

        public bool GetAbleToFillOutSurvey(long appointmentId)
        {
            try
            {
                var responseStream = SendRequest("http://localhost:57733/api/appointment/surveyCanBeFilledOut/" + appointmentId, HttpMethod.Get);
                return JsonConvert.DeserializeObject<bool>(responseStream.Result);
            } catch (Exception)
            {
                return false;
            }
        }

        public long GetDoctorId(long appointmentId)
        {
            var responseStream = SendRequest("http://localhost:57733/api/appointment/getDoctorInAppointmentId/" + appointmentId, HttpMethod.Get);
            return JsonConvert.DeserializeObject<long>(responseStream.Result);
        }

        public void DeactivateFillingOutSurvey(long appointmentId)
        {
            SendRequest("http://localhost:57733/api/appointment/deactivateFillingOutSurvey/" + appointmentId, HttpMethod.Put);
        }

        public List<long> GetAllDoctorIds()
        {
            var responseStream = SendRequest("http://localhost:57746/api/doctor/getAllDoctorIds", HttpMethod.Get);
            return JsonConvert.DeserializeObject<List<long>>(responseStream.Result);
        }

        public string GetDoctorUsername(long doctorId)
        {
            var responseStream = SendRequest("http://localhost:57746/api/doctor/getUsername/" + doctorId, HttpMethod.Get);
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
