using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyPetsAPI.DtoMapper;
using MyPetsAPI.Models;
using MyPetsAPI.Persistence;
using MyPetsCore.DTOs;

namespace MyPetsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoundController : ControllerBase
    {
        private readonly ILogger<RoundController> _logger;
        private readonly UnitOfWork _unitOfWork;

        public RoundController(ILogger<RoundController> logger)
        {
            _logger = logger;
            _unitOfWork = new UnitOfWork(new MyPetsContext());
        }

        #region GetRequest

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<RoundDto> GetRoundById([FromRoute] int id)
        {
            try
            {
                if (id == 0) return BadRequest("Id can't be null");
                var round = _unitOfWork.Rounds.Get(id);
                if (round is null) return NotFound("Not found round with id = " + id);
                return Ok(new RoundMapper().ToDto(round));
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message, e, HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Route("Document/{id:int}")]
        public ActionResult<RoundToInvestigationDocument> GetDocumentForRoundById([FromRoute] int id)
        {
            try
            {
                if (id == 0) return BadRequest("Id can't be null");
                var roundDocument = _unitOfWork.RoundToInvestigationDocuments.Get(id);
                if (roundDocument is null) return NotFound("Not found document with id = " + id);
                return Ok(new RoundToInvestigationDocumentMapper().ToDto(roundDocument));
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message, e, HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Route("Documents/{roundId:int}")]
        public ActionResult<IEnumerable<RoundToInvestigationDocumentDto>> GetAllDocumentForRound([FromRoute] int roundId)
        {
            try
            {
                var documentsForRound = _unitOfWork.RoundToInvestigationDocuments.Find(d => d.RoundId == roundId);
                return Ok(documentsForRound.Select(d => new RoundToInvestigationDocumentMapper().ToDto(d)).ToList());
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
        public ActionResult<RoundDto> CreateRound([FromBody] RoundDto roundDto)
        {
            try
            {
                if (roundDto is null) return BadRequest("Round can't be null");
                var round = new RoundMapper().ToModel(roundDto);
                var send = _unitOfWork.Rounds.Add(round);
                _unitOfWork.Save();
                var dto = new RoundMapper().ToDto(send);
                return CreatedAtAction(nameof(GetRoundById), new { id = dto.RoundId }, dto);
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message, e, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("Document")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<RoundToInvestigationDocument> AttachDocument([FromBody] RoundToInvestigationDocumentDto dto)
        {
            try
            {
                if (dto is null) return BadRequest("Round can't be null");
                var roundToInvestigationDocument = new RoundToInvestigationDocumentMapper().ToModel(dto);
                var result = _unitOfWork.RoundToInvestigationDocuments.Add(roundToInvestigationDocument);
                _unitOfWork.Save();
                var send = new RoundToInvestigationDocumentMapper().ToDto(result);
                return CreatedAtAction(nameof(GetDocumentForRoundById), new { id = send.RoundToInvestigationDocumentId }, send);
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
        public ActionResult<RoundDto> UpdateRound([FromRoute] int id, [FromBody] RoundDto roundDto)
        {
            try
            {
                var round = new RoundMapper().ToModel(roundDto);
                round.RoundId ??= id;
                var result = _unitOfWork.Rounds.Update(id, round);
                _unitOfWork.Save();
                return Ok(new RoundMapper().ToDto(result));
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
        public ActionResult DeleteRound([FromRoute] int id)
        {
            try
            {
                _unitOfWork.Rounds.Remove(id);
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
        public ActionResult DeleteDocumentForRound([FromRoute] int id)
        {
            try
            {
                _unitOfWork.RoundToInvestigationDocuments.Remove(id);
                _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #endregion
    }
}
