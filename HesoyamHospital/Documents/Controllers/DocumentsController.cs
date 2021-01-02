using System.Linq;
using System.Net.Http;
using Documents.Mappers;
using Documents.Service;
using Documents.Service.Abstract;
using Documents.Util;
using Documents.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Documents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        private readonly DocumentsValidation _validation;
        private readonly IHttpRequestSender _httpRequestSender;

        public DocumentController(IDocumentService documentService, IHttpClientFactory httpClientFactory)
        {
            _documentService = documentService;
            _validation = new DocumentsValidation();
            _httpRequestSender = new HttpRequestSender(httpClientFactory);
        }

        [HttpPost("simple-search/{id}")]
        public IActionResult SimpleSearchDocs([FromBody] DocumentSearchCriteria criteria, long id)
        {
            if (!_validation.IsSearchCriteriaValid(criteria)) return BadRequest();

            return Ok(DocumentsMapper.DocumentToDocumentDTO(_documentService.SimpleSearchDocs(criteria, id, _httpRequestSender).ToList(), _httpRequestSender));
        }

        [HttpPost("advanced-search/{id}")]
        public IActionResult AdvanceSearchDocs([FromBody] AdvancedDocumentSearchCriteria criteria, long id)
        {
            if (!_validation.IsAdvancedSearchCriteriaValid(criteria)) return BadRequest();

            return Ok(_documentService.AdvanceSearchDocs(criteria, id, _httpRequestSender).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            return Ok(DocumentsMapper.DocumentToDocumentDTO(_documentService.GetAllByPatient(id).ToList(), _httpRequestSender));
        }
    }
}
