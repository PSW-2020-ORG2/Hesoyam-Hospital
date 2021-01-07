﻿using Documents.Model;
using Documents.DTOs;
using System.Collections.Generic;
using Documents.Util;

namespace Documents.Service.Abstract
{
    public interface IDocumentService: IService<Document, long>
    {
        public IEnumerable<Document> SimpleSearchDocs(DocumentSearchCriteria criteria, long patientId, IHttpRequestSender httpRequestSender);
        public IEnumerable<DocumentDTO> AdvanceSearchDocs(AdvancedDocumentSearchCriteria criteria, long patientId, IHttpRequestSender httpRequestSender);
        public IEnumerable<Document> GetAllByPatient(long patientId);
    }
}
