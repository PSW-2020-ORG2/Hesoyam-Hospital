using Backend;
using Backend.Model.PatientModel;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Repository.MySQLRepository.MedicalRepository;
using Backend.Util;
using System;
using System.Collections.Generic;

namespace WebApplication.Documents.Service
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

        public IEnumerable<Document> AdvanceSearchDocs(AdvancedDocumentSearchCriteria criteria, long patientId)
        {
            List<Document> result = new List<Document>();

            if (criteria.ShouldSearchPrescriptions) result.AddRange(getPrescriptionsThatMeetAdvancedCriteria(criteria, patientId));
            if (criteria.ShouldSearchReports) result.AddRange(getReportsThatMeetAdvancedCriteria(criteria, patientId));

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

        public IEnumerable<Document> SimpleSearchDocs(DocumentSearchCriteria criteria, long patientId)
        {
            List<Document> result = new List<Document>();

            if (criteria.ShouldSearchPrescriptions) result.AddRange(getPrescriptionsThatMeetCriteria(criteria, patientId));
            if (criteria.ShouldSearchReports) result.AddRange(getReportsThatMeetCriteria(criteria, patientId));

            return result;
        }

        public void Update(Document entity)
        {
            throw new NotImplementedException();
        }

        public void Validate(Document entity)
        {
            throw new NotImplementedException();
        }

        private List<Document> getPrescriptionsThatMeetCriteria(DocumentSearchCriteria criteria, long patientId)
        {
            List<Document> result = new List<Document>();

            foreach (Prescription prescription in _prescriptionRepository.GetAllByPatient(patientId))
                if (prescription.meetsCriteria(criteria))
                    result.Add(prescription);

            return result;
        }

        private List<Document> getReportsThatMeetCriteria(DocumentSearchCriteria criteria, long patientId)
        {
            List<Document> result = new List<Document>();

            foreach (Report report in _reportRepository.GetAllByPatient(patientId))
                if (report.meetsCriteria(criteria))
                    result.Add(report);

            return result;
        }

        private List<Document> getPrescriptionsThatMeetAdvancedCriteria(AdvancedDocumentSearchCriteria criteria, long patientId)
        {
            throw new NotImplementedException();
        }

        private List<Document> getReportsThatMeetAdvancedCriteria(AdvancedDocumentSearchCriteria criteria, long patientId)
        {
            throw new NotImplementedException();
        }
    }
}
