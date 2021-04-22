using System;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly UnitOfWork _unitOfWork;
        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
            _unitOfWork = new UnitOfWork(new MyPetsContext());
        }

        #region GetRequest

        [HttpGet]
        [Route("Username/{email}/Password/{password}")]
        public ActionResult<PersonDto> Connection([FromRoute] string email, [FromRoute] string password)
        {
            try
            {
                var person = _unitOfWork.Persons.Find(p => p.Email == email && p.Password == password).FirstOrDefault();
                if (person is null) return BadRequest("Connection Error");
                return Ok(new PersonMapper().ToDto(person));
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message, e, HttpStatusCode.InternalServerError);
            }
        }

        #endregion

    }
}
