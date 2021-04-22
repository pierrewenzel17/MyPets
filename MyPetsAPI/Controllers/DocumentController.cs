using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using MyPetsAPI.DtoMapper;
using MyPetsAPI.Models;
using MyPetsAPI.Persistence;
using MyPetsCore.DTOs;

namespace MyPetsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly ILogger<DocumentController> _logger;
        private readonly UnitOfWork _unitOfWork;

        public DocumentController(ILogger<DocumentController> logger)
        {
            _logger = logger;
            _unitOfWork = new UnitOfWork(new MyPetsContext());
        }

        #region GetRequest

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<InvestigationDocumentDto> GetDocumentById([FromRoute] int id)
        {
            try
            {
                if (id == 0) return BadRequest("Id can't be null");
                var doc = _unitOfWork.InvestigationDocuments.Get(id);
                if (doc is null) return NotFound("Not found round with id = " + id);
                return Ok(new InvestigationDocumentMapper().ToDto(doc));
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message, e, HttpStatusCode.InternalServerError);
            }
        }

        #endregion

        #region PostRequest

        [HttpPost]
        public ActionResult<InvestigationDocumentDto> CreateDocument([FromBody] InvestigationDocumentDto dto)
        {
            try
            {
                if (dto is null) return BadRequest("Round can't be null");
                var document = new InvestigationDocumentMapper().ToModel(dto);
                var result = _unitOfWork.InvestigationDocuments.Add(document);
                _unitOfWork.Save();
                var send = new InvestigationDocumentMapper().ToDto(result);
                return CreatedAtAction(nameof(GetDocumentById), new { id = send.InvestigationDocumentId }, send);
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message, e, HttpStatusCode.InternalServerError);
            }
        }

        #endregion

        #region DeleteRequest

        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete([FromRoute] int id)
        {
            try
            {
                _unitOfWork.InvestigationDocuments.Remove(id);
                _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message, e, HttpStatusCode.InternalServerError);
            }
        }

        #endregion


    }
}
