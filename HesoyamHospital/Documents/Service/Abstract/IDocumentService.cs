using Backend.Model.PatientModel;
using Backend.Util;
using System.Collections.Generic;

namespace Documents.Service.Abstract
{
    public interface IDocumentService: IService<Document, long>
    {
        public IEnumerable<Document> SimpleSearchDocs(DocumentSearchCriteria criteria, long patientId);
        public IEnumerable<Document> AdvanceSearchDocs(AdvancedDocumentSearchCriteria criteria, long patientId);
        public IEnumerable<Document> GetAllByPatient(long patientId);
    }
}
