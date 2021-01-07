using Documents.Model;
using Documents.DTOs;
using System.Collections.Generic;
using Documents.Service.Abstract;

namespace Documents.Mappers
{
    public static class DocumentsMapper
    {
        private static DocumentDTO DocumentToDocumentDTO(Document document, IHttpRequestSender httpRequestSender)
            => new DocumentDTO(document.DateCreated, httpRequestSender.GetDoctorFullName(document.DoctorId), document.Diagnosis.DiagnosisName, document.Type == DocumentType.REPORT ? "REPORT" : "PRESCRIPTION");

        public static List<DocumentDTO> DocumentToDocumentDTO(List<Document> documents, IHttpRequestSender httpRequestSender)
        {
            List<DocumentDTO> result = new List<DocumentDTO>();
            foreach (Document document in documents)
                result.Add(DocumentToDocumentDTO(document, httpRequestSender));
            return result;
        }
    }
}
