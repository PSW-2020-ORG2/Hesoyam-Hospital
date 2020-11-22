using Backend;
using Backend.Model.PatientModel;
using Backend.Repository.Abstract.MedicalAbstractRepository;
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

        public IEnumerable<Document> SimpleSearchDocs(SearchCriteria criteria)
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

        private IEnumerable<Document> getPrescriptionsThatMeetCriteria(SearchCriteria criteria)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Document> getReportsThatMeetCriteria(SearchCriteria criteria)
        {
            throw new NotImplementedException();
        }
    }
}
