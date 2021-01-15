using Documents.Model;
using Documents.DTOs;
using Documents.Mappers;
using Documents.Repository.Abstract;
using Documents.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using Documents.Util;

namespace Documents.Service
{
    public class DocumentService : IDocumentService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IReportRepository _reportRepository;

        public DocumentService(IPrescriptionRepository prescriptionRepository, IReportRepository reportRepository)
        {
            _prescriptionRepository = prescriptionRepository;
            _reportRepository = reportRepository;
        }

        public IEnumerable<DocumentDTO> AdvanceSearchDocs(AdvancedDocumentSearchCriteria criteria, long patientId, IHttpRequestSender httpRequestSender)
        {
            List<DocumentDTO> result = new List<DocumentDTO>();

            if (criteria.ShouldSearchPrescriptions) result.AddRange(DocumentsMapper.DocumentToDocumentDTO(GetPrescriptionsThatMeetAdvancedCriteria(criteria, patientId, httpRequestSender), httpRequestSender));
            if (criteria.ShouldSearchReports) result.AddRange(DocumentsMapper.DocumentToDocumentDTO(GetReportsThatMeetAdvancedCriteria(criteria, patientId, httpRequestSender), httpRequestSender));

            return result;
        }

        public Document Create(Document entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Document entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Document> GetAll()
        {
            List<Document> result = ((List<Report>)_reportRepository.GetAll()).ConvertAll(r => (Document)r);
            result.AddRange(((List<Prescription>)_prescriptionRepository.GetAll()).ConvertAll(p => (Document)p));
            return result;
        }

        public IEnumerable<Document> GetAllByPatient(long patientId)
        {
            List<Document> result = ((List<Report>)_reportRepository.GetAllByPatient(patientId)).ConvertAll(r => (Document)r);
            result.AddRange(((List<Prescription>)_prescriptionRepository.GetAllByPatient(patientId)).ConvertAll(p => (Document)p));
            return result;
        }

        public Document GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Document> SimpleSearchDocs(DocumentSearchCriteria criteria, long patientId, IHttpRequestSender httpRequestSender)
        {
            List<Document> result = new List<Document>();

            if (criteria.ShouldSearchPrescriptions) result.AddRange(GetPrescriptionsThatMeetCriteria(criteria, patientId, httpRequestSender));
            if (criteria.ShouldSearchReports) result.AddRange(GetReportsThatMeetCriteria(criteria, patientId, httpRequestSender));

            return result;
        }

        public void Update(Document entity)
        {
            throw new NotImplementedException();
        }

        private List<Document> GetPrescriptionsThatMeetCriteria(DocumentSearchCriteria criteria, long patientId, IHttpRequestSender httpRequestSender)
        {
            List<Document> result = new List<Document>();

            foreach (Prescription prescription in _prescriptionRepository.GetAllByPatient(patientId))
                if (prescription.MeetsCriteria(criteria, httpRequestSender.GetDoctorFullName(prescription.DoctorId)))
                    result.Add(prescription);
            return result;
        }

        private List<Document> GetReportsThatMeetCriteria(DocumentSearchCriteria criteria, long patientId, IHttpRequestSender httpRequestSender)
        {
            List<Document> result = new List<Document>();

            foreach (Report report in _reportRepository.GetAllByPatient(patientId))
                if (report.MeetsCriteria(criteria, httpRequestSender.GetDoctorFullName(report.DoctorId)))
                    result.Add(report);

            return result;
        }

        private List<Document> GetPrescriptionsThatMeetAdvancedCriteria(AdvancedDocumentSearchCriteria criteria, long patientId, IHttpRequestSender httpRequestSender)
        {
            List<Prescription> allPrescriptions = ((List<Prescription>)_prescriptionRepository.GetAllByPatient(patientId));
            List<Document> currentResult = allPrescriptions.ToList().ConvertAll(r => (Document)r);
            if (criteria.HasElements())
            {
                criteria.SetInitialState();
                for (int i = 0; i < criteria.FilterTypes.Count; i++)
                {
                    List<Document> newResult;
                    if (criteria.FilterTypes[i] == FilterType.TIME_INTERVAL)
                    {
                        TimeIntervalFilter timeIntervalFilter = criteria.TimeIntervalFilters[0];
                        criteria.TimeIntervalFilters.RemoveAt(0);
                        criteria.TimeIntervalFilters.Add(timeIntervalFilter);
                        newResult = GetPrescriptionsThatMeetTimeIntervalCriteria(allPrescriptions, timeIntervalFilter).ConvertAll(r => (Document)r);
                    }
                    else
                    {
                        TextFilter textFilter = criteria.TextFilters[0];
                        criteria.TextFilters.RemoveAt(0);
                        criteria.TextFilters.Add(textFilter);
                        if (criteria.FilterTypes[i] == FilterType.COMMENT) continue;
                        newResult = GetPrescriptionsThatMeetTextCriteria(allPrescriptions, textFilter, criteria.FilterTypes[i], httpRequestSender).ConvertAll(r => (Document)r);
                    }
                    currentResult = PerformLogicalOperation(currentResult, newResult, criteria.LogicalOperators[i]);
                }
            }
            return currentResult;
        }

        private List<Document> GetReportsThatMeetAdvancedCriteria(AdvancedDocumentSearchCriteria criteria, long patientId, IHttpRequestSender httpRequestSender)
        {
            List<Report> allReports = (List<Report>)_reportRepository.GetAllByPatient(patientId);
            List<Document> currentResult = allReports.ToList().ConvertAll(r => (Document)r);
            if (criteria.HasElements())
            {
                criteria.SetInitialState();
                for (int i = 0; i < criteria.FilterTypes.Count; i++)
                {
                    List<Document> newResult;
                    if (criteria.FilterTypes[i] == FilterType.TIME_INTERVAL)
                    {
                        TimeIntervalFilter timeIntervalFilter = criteria.TimeIntervalFilters[0];
                        criteria.TimeIntervalFilters.RemoveAt(0);
                        criteria.TimeIntervalFilters.Add(timeIntervalFilter);
                        newResult = GetReportsThatMeetTimeIntervalCriteria(allReports, timeIntervalFilter).ConvertAll(r => (Document)r);
                    }
                    else
                    {
                        TextFilter textFilter = criteria.TextFilters[0];
                        criteria.TextFilters.RemoveAt(0);
                        criteria.TextFilters.Add(textFilter);
                        if (criteria.FilterTypes[i] == FilterType.MEDICINE_NAME) continue;
                        newResult = GetReportsThatMeetTextCriteria(allReports, textFilter, criteria.FilterTypes[i], httpRequestSender).ConvertAll(r => (Document)r);
                    }
                    currentResult = PerformLogicalOperation(currentResult, newResult, criteria.LogicalOperators[i]);
                }
            }
            return currentResult;
        }

        private List<Report> GetReportsThatMeetTimeIntervalCriteria(List<Report> reports, TimeIntervalFilter timeIntervalFilter)
        {
            List<Report> result = new List<Report>();
            foreach (Report report in reports)
                if (report.MeetsTimeIntervalCriteria(timeIntervalFilter))
                    result.Add(report);
            return result;
        }

        private List<Prescription> GetPrescriptionsThatMeetTimeIntervalCriteria(List<Prescription> prescriptions, TimeIntervalFilter timeIntervalFilter)
        {
            List<Prescription> result = new List<Prescription>();
            foreach (Prescription prescription in prescriptions)
                if (prescription.MeetsTimeIntervalCriteria(timeIntervalFilter))
                    result.Add(prescription);
            return result;
        }

        private List<Report> GetReportsThatMeetTextCriteria(List<Report> reports, TextFilter filter, FilterType filterType, IHttpRequestSender httpRequestSender)
        {
            List<Report> result = new List<Report>();
            foreach (Report report in reports)
                if (report.MeetsAdvancedTextCriteria(filterType, filter, httpRequestSender.GetDoctorFullName(report.DoctorId)))
                    result.Add(report);
            return result;
        }

        private List<Prescription> GetPrescriptionsThatMeetTextCriteria(List<Prescription> prescriptions, TextFilter filter, FilterType filterType, IHttpRequestSender httpRequestSender)
        {
            List<Prescription> result = new List<Prescription>();
            foreach (Prescription prescription in prescriptions)
                if (prescription.MeetsAdvancedTextCriteria(filterType, filter, httpRequestSender.GetDoctorFullName(prescription.DoctorId)))
                    result.Add(prescription);
            return result;
        }

        private List<Document> PerformLogicalOperation(List<Document> operandOne, List<Document> operandTwo, LogicalOperator logicalOperator)
        {
            if (logicalOperator == LogicalOperator.AND) return PerformLogicalOperationAnd(operandOne, operandTwo);
            else return PerformLogicalOperationOr(operandOne, operandTwo);
        }

        private List<Document> PerformLogicalOperationAnd(List<Document> operandOne, List<Document> operandTwo)
        {
            List<Document> result = new List<Document>();
            foreach (Document d in operandOne)
                if (operandTwo.Count(doc => doc.Id == d.Id) > 0)
                    result.Add(d);
            return result;
        }

        private List<Document> PerformLogicalOperationOr(List<Document> operandOne, List<Document> operandTwo)
        {
            List<Document> result = operandTwo;
            foreach (Document d in operandOne)
                if (result.Count(doc => doc.Id == d.Id) == 0)
                    result.Add(d);
            return result;
        }

        public bool AppointmentHasReport(long appointmentId)
            => _reportRepository.GetAll().Count(r => r.AppointmentId == appointmentId) > 0;

        public bool AppointmentHasPrescription(long appointmentId)
            => _prescriptionRepository.GetAll().Count(p => p.AppointmentId == appointmentId) > 0;

        public Report GetReportByAppointment(long appointmentId)
            => _reportRepository.GetAll().FirstOrDefault(r => r.AppointmentId == appointmentId);

        public Prescription GetPrescriptionByAppointment(long appointmentId)
            => _prescriptionRepository.GetAll().FirstOrDefault(p => p.AppointmentId == appointmentId);
    }
}
