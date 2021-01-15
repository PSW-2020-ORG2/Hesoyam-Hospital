using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Appointments.Service.Abstract
{
    public interface IHttpRequestSender
    {
        public long GetTimeTableIdForDoctorId(long doctorId);
        public long GetTimeTableIdForSelectedDoctor(long patientId);
        public string GetDoctorFullName(long doctorId);
        public List<long> GetSameSpecializationDoctorIds(long doctorId);
        public Task<string> SendRequest(string url, HttpMethod method);
        public long GetRoomIdForDoctor(long doctorId);
        public string GetDoctorSpecialization(long doctorId);
        public string GetRoomNumberById(long doctorId);
        public string GetPatientUsername(long patientId);
        public string GetPatientFullName(long patientId);
        public bool IsBlocked(long patientId);
        public long GetSelectedDoctorId(long patientId);
        public bool HasPrescription(long appointmentId);
        public bool HasReport(long appointmentId);
    }
}
