using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Feedbacks.Service.Abstract
{
    public interface IHttpRequestSender
    {
        public Task<string> SendRequest(string url, HttpMethod method);
        public bool GetAbleToFillOutSurvey(long appointmentId);
        public long GetDoctorId(long appointmentId);
        public void DeactivateFillingOutSurvey(long appointmentId);
        public List<long> GetAllDoctorIds();
        public string GetDoctorUsername(long doctorId);
    }
}
