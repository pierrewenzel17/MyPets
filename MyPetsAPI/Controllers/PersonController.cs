using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyPetsAPI.DtoMapper;
using MyPetsAPI.Models;
using MyPetsAPI.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using MyPetsCore.DTOs;

namespace MyPetsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly UnitOfWork _unitOfWork;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
            _unitOfWork = new UnitOfWork(new MyPetsContext());
        }


        #region GetRequest

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<PersonDto> Get([FromRoute] int id)
        {
            try
            {
                if (id == 0) return BadRequest("Id can't be null");
                var person = _unitOfWork.Persons.Get(id);
                if (person is null) return NotFound("Not found person with id = " + id);
                return Ok(new PersonMapper().ToDto(person));
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message, e, HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Route("investigation/{id:int}")]
        public ActionResult<InvestigationPersonDto> GetInvestigationPerson([FromRoute] int id)
        {
            try
            {
                if (id == 0) return BadRequest("Id can't be null");
                var person = _unitOfWork.InvestigationPersons.Get(id);
                if (person is null) return NotFound("Not found person with id = " + id);
                return Ok(new InvestigationPersonMapper().ToDto(person));
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message, e, HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<PersonDto>> Get()
        {
            try
            {
                var personList = _unitOfWork.Persons.GetAll();
                return Ok(personList.Select(p => new PersonMapper().ToDto(p)).ToList());
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message, e, HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Route("investigation")]
        public ActionResult<InvestigationPersonDto> GetInvestigationPersons()
        {
            try
            {
                var personList = _unitOfWork.InvestigationPersons.GetAll();
                return Ok(personList.Select(p => new InvestigationPersonMapper().ToDto(p)).ToList());
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
        public ActionResult<PersonDto> Post([FromBody] PersonDto personDto)
        {
            try
            {
                if (personDto is null) return BadRequest("Person can't be null");
                var person = new PersonMapper().ToModel(personDto);
                var send = _unitOfWork.Persons.Add(person);
                _unitOfWork.Save();
                var dto =  new PersonMapper().ToDto(send);
                return CreatedAtAction(nameof(GetInvestigationPerson),new { id = dto.PersonId}, dto);
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message, e, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("investigation")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<PersonDto> Create([FromBody] InvestigationPersonDto personDto)
        {
            try
            {
                if (personDto is null) return BadRequest("Person can't be null");
                var person = new InvestigationPersonMapper().ToModel(personDto);
                var send = _unitOfWork.InvestigationPersons.Add(person);
                _unitOfWork.Save();
                var dto = new InvestigationPersonMapper().ToDto(send);
                return CreatedAtAction(nameof(Get), new { id = dto.InvestigationPersonId }, dto);
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
        public ActionResult<PersonDto> Put([FromRoute] int id, [FromBody] PersonDto personDto)
        {
            try
            {
                var person = new PersonMapper().ToModel(personDto);
                person.PersonId ??= id;
                var result = _unitOfWork.Persons.Update(id, person);
                _unitOfWork.Save();
                return Ok(new PersonMapper().ToDto(result));
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message, e, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        [Route("investigation/{id:int}")]
        public ActionResult<InvestigationPersonDto> Update([FromRoute] int id, [FromBody] InvestigationPersonDto personDto)
        {
            try
            {
                var person = new InvestigationPersonMapper().ToModel(personDto);
                person.InvestigationPersonId ??= id;
                var result = _unitOfWork.InvestigationPersons.Update(id, person);
                _unitOfWork.Save();
                return Ok(new InvestigationPersonMapper().ToDto(result));
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
                _unitOfWork.Persons.Remove(id);
                _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message, e, HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        [Route("investigation/{id:int}")]
        public ActionResult DeleteInvestigationPerson([FromRoute] int id)
        {
            try
            {
                _unitOfWork.InvestigationPersons.Remove(id);
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
