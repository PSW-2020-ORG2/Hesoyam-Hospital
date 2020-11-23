﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.PatientModel;
using Backend.Service;
using Backend.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Documents.Service;

namespace WebApplication.Documents
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        private readonly DocumentsValidation _validation;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
            _validation = new DocumentsValidation();
        }

        [HttpPost("simple-search")]
        public IActionResult SimpleSearchDocs([FromBody]DocumentSearchCriteria criteria)
        {
            if (!_validation.isSearchCriteriaValid(criteria)) return BadRequest();

            List<DocumentDTO> result = new List<DocumentDTO>();
            List<Document> documents = _documentService.SimpleSearchDocs(criteria).ToList();
            foreach (Document document in documents)
                result.Add(DocumentsMapper.DocumentToDocumentDTO(document));

            return Ok(result);
        }
    }
}
