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
            throw new NotImplementedException();
        }

        public Document GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Document> SimpleSearchDocs(DocumentSearchCriteria criteria)
        {
            List<Document> result = new List<Document>();

            if (criteria.ShouldSearchPrescriptions) result.AddRange(getPrescriptionsThatMeetCriteria(criteria));
            if (criteria.ShouldSearchReports) result.AddRange(getReportsThatMeetCriteria(criteria));

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

        private List<Document> getPrescriptionsThatMeetCriteria(DocumentSearchCriteria criteria)
        {
            List<Document> result = new List<Document>();

            foreach (Prescription prescription in _prescriptionRepository.GetAll())
                if (prescription.meetsCriteria(criteria))
                    result.Add(prescription);

            return result;
        }

        private List<Document> getReportsThatMeetCriteria(DocumentSearchCriteria criteria)
        {
            List<Document> result = new List<Document>();

            foreach (Report report in _reportRepository.GetAll())
                if (report.meetsCriteria(criteria))
                    result.Add(report);

            return result;
        }
    }
}
