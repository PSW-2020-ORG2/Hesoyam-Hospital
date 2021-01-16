using Documents.DTOs;
using Documents.Model;
using Documents.Service.Abstract;

namespace Documents.Mappers
{
    public static class ReportMapper
    {
        public static ReportDTO ReportToReportDTO(Report report, IHttpRequestSender httpRequestSender)
            => new ReportDTO(report.DateCreated, httpRequestSender.GetDoctorFullName(report.DoctorId), httpRequestSender.GetDoctorSpecialisation(report.DoctorId), report.Diagnosis != null ? report.Diagnosis.DiagnosisName : "UNDEFINED", report.Comment);
    }
}
