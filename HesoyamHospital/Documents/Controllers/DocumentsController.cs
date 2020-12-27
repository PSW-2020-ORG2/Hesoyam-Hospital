using System.Linq;
using Authentication.Model.Util;
using Documents.Mappers;
using Documents.Service.Abstract;
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

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
            _validation = new DocumentsValidation();
        }

        [HttpPost("simple-search/{id}")]
        public IActionResult SimpleSearchDocs([FromBody] DocumentSearchCriteria criteria, long id)
        {
            if (!_validation.IsSearchCriteriaValid(criteria)) return BadRequest();

            return Ok(DocumentsMapper.DocumentToDocumentDTO(_documentService.SimpleSearchDocs(criteria, id).ToList()));
        }

        [HttpPost("advanced-search/{id}")]
        public IActionResult AdvanceSearchDocs([FromBody] AdvancedDocumentSearchCriteria criteria, long id)
        {
            if (!_validation.IsAdvancedSearchCriteriaValid(criteria)) return BadRequest();

            return Ok(_documentService.AdvanceSearchDocs(criteria, id).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            return Ok(DocumentsMapper.DocumentToDocumentDTO(_documentService.GetAllByPatient(id).ToList()));
        }
    }
}
