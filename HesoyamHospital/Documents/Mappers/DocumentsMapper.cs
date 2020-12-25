using Backend.Model.PatientModel;
using Documents.DTOs;
using System.Collections.Generic;

namespace Documents.Mappers
{
    public static class DocumentsMapper
    {
        private static DocumentDTO DocumentToDocumentDTO(Document document)
            => new DocumentDTO(document.DateCreated, document.Doctor.FullName, document.Diagnosis.DiagnosisName, document.Type == DocumentType.REPORT ? "REPORT" : "PRESCRIPTION");

        public static List<DocumentDTO> DocumentToDocumentDTO(List<Document> documents)
        {
            List<DocumentDTO> result = new List<DocumentDTO>();
            foreach (Document document in documents)
                result.Add(DocumentToDocumentDTO(document));
            return result;
        }
    }
}
