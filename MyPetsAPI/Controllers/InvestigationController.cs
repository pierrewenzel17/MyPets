using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using MyPetsAPI.DtoMapper;
using MyPetsAPI.Models;
using MyPetsAPI.Persistence;
using MyPetsCore.DTOs;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace MyPetsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestigationController : ControllerBase
    {
        private readonly ILogger<InvestigationController> _logger;
        private readonly UnitOfWork _unitOfWork;


        public InvestigationController(ILogger<InvestigationController> logger)
        {
            _logger = logger;
            _unitOfWork = new UnitOfWork(new MyPetsContext());
        }

        #region GetRequest

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<InvestigationDto> GetInvestigationById([FromRoute] int id)
        {
            try
            {
                if (id == 0) return BadRequest("Id can't be null");
                var investigation = _unitOfWork.Investigations.Get(id);
                if (investigation is null) return NotFound("Not found round with id = " + id);
                return Ok(new InvestigationMapper().ToDto(investigation));
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message, e, HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<InvestigationDto>> GetAll()
        {
            try
            {
                var investigations = _unitOfWork.Investigations.GetAll();
                return Ok(investigations.Select(i => new InvestigationMapper().ToDto(i)).ToList());
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message, e, HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Route("Round/{id:int}")]
        public ActionResult<InvestigationToRoundDto> GetRound(int id)
        {
            try
            {
                if (id == 0) return BadRequest("Id can't be null");
                var round = _unitOfWork.InvestigationToRounds.Get(id);
                if (round is null) return NotFound("Not found round with id = " + id);
                return Ok(new InvestigationToRoundMapper().ToDto(round));
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message, e, HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Route("Rounds/{investigationId:int}")]
        public ActionResult<IEnumerable<InvestigationToRoundDto>> GetRounds(int investigationId)
        {
            try
            {
                var rounds = _unitOfWork.InvestigationToRounds.Find(r => r.InvestigationId == investigationId);
                return Ok(rounds.Select(r => new InvestigationToRoundMapper().ToDto(r)).ToList());
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message, e, HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Route("Document/{id:int}")]
        public ActionResult<InvestigationToInvestigationDocumentDto> GetDocument(int id)
        {
            try
            {
                if (id == 0) return BadRequest("Id can't be null");
                var document = _unitOfWork.InvestigationToInvestigationDocuments.Get(id);
                if (document is null) return NotFound("Not found round with id = " + id);
                return Ok(new InvestigationToInvestigationDocumentMapper().ToDto(document));
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message, e, HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Route("Documents/{investigationId:int}")]
        public ActionResult<IEnumerable<InvestigationToInvestigationDocumentDto>> GetDocuments(int investigationId)
        {
            try
            {
                var documents = _unitOfWork.InvestigationToInvestigationDocuments.Find(d => d.InvestigationId == investigationId);
                return Ok(documents.Select(d => new InvestigationToInvestigationDocumentMapper().ToDto(d)).ToList());
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message, e, HttpStatusCode.InternalServerError);
            }
        }
        #endregion

        #region PostRequest

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<InvestigationDto> CreateInvestigation([FromBody] InvestigationDto investigationDto)
        {
            try
            {
                if (investigationDto is null) return BadRequest("Investigation can't be null");
                var investigation = new InvestigationMapper().ToModel(investigationDto);
                var send = _unitOfWork.Investigations.Add(investigation);
                _unitOfWork.Save();
                var dto = new InvestigationMapper().ToDto(send);
                return CreatedAtAction(nameof(GetInvestigationById), new { id = dto.InvestigationId }, dto);
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message, e, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("Round")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<InvestigationToRoundDto> AttachRound([FromBody] InvestigationToRoundDto dto)
        {
            try
            {
                if (dto is null) return BadRequest("attach can't be null");
                var round = new InvestigationToRoundMapper().ToModel(dto);
                var send = _unitOfWork.InvestigationToRounds.Add(round);
                _unitOfWork.Save();
                var result = new InvestigationToRoundMapper().ToDto(send);
                return CreatedAtAction(nameof(GetRound), new { id = result.InvestigationToRoundId }, result);
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message, e, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("Document")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<InvestigationToInvestigationDocumentDto> AttachDocument([FromBody] InvestigationToInvestigationDocumentDto dto)
        {
            try
            {
                if (dto is null) return BadRequest("attach can't be null");
                var document = new InvestigationToInvestigationDocumentMapper().ToModel(dto);
                var send = _unitOfWork.InvestigationToInvestigationDocuments.Add(document);
                _unitOfWork.Save();
                var result = new InvestigationToInvestigationDocumentMapper().ToDto(send);
                return CreatedAtAction(nameof(GetDocument), new { id = result.InvestigationToInvestigationDocumentId }, result);
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message, e, HttpStatusCode.InternalServerError);
            }
        }


        #endregion

        #region PutRequest

        [HttpPut]
        [Route("{id:int}")]
        public ActionResult<InvestigationDto> UpdateInvestigation([FromRoute] int id, [FromBody] InvestigationDto investigationDto)
        {
            try
            {
                var investigation = new InvestigationMapper().ToModel(investigationDto);
                investigation.InvestigationId ??= id;
                var result = _unitOfWork.Investigations.Update(id, investigation);
                _unitOfWork.Save();
                return Ok(new InvestigationMapper().ToDto(result));
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
                _unitOfWork.Investigations.Remove(id);
                _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message, e, HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        [Route("Round/{id:int}")]
        public ActionResult DeleteRound([FromRoute] int id)
        {
            try
            {
                _unitOfWork.InvestigationToRounds.Remove(id);
                _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message, e, HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        [Route("Document/{id:int}")]
        public ActionResult DeleteDocument([FromRoute] int id)
        {
            try
            {
                _unitOfWork.InvestigationToInvestigationDocuments.Remove(id);
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
