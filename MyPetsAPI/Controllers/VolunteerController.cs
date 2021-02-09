using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using MyPetsAPI.Services.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPetsCore.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyPetsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<VolunteerDto>> Get()
        {
            try
            {
                IServiceGet<VolunteerDto, VolunteerDao> getService = new IServiceGet<VolunteerDto, VolunteerDao>;
                return getService.Get();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{key}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<VolunteerDto> Get([FromRoute] uint key)
        {
            try
            {
                if (key == 0) return StatusCode(400);
                IServiceGet<VolunteerDto, VolunteerDao> getService = new IServiceGet<VolunteerDto, VolunteerDao>;
                return getService.Get(key);

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> Post([FromBody] VolunteerDto volunteerDto)
        {
            try
            {
                if (volunteerDto == null) return StatusCode(400);
                IServiceCreate<VolunteerDto, VolunteerDao> createService = new IServiceCreate<VolunteerDto, VolunteerDao>;
                return createService.Create(volunteerDto);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult<bool> Put([FromBody] VolunteerDto volunteerDto)
        {
            try
            {
                if (volunteerDto == null) return StatusCode(400);
                IServiceUpdate<VolunteerDto, VolunteerDao> updateService = new IServiceUpdate<VolunteerDto, VolunteerDao>;
                return updateService.Update(volunteerDto);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{key}")]
        public ActionResult<bool> Delete([FromRoute] uint key)
        {
            try
            {
                if (key == 0) return StatusCode(400);
                IServiceDelete<VolunteerDto, VolunteerDao> deleteService = new IServiceDelete<VolunteerDto, VolunteerDao>;
                return deleteService.Delete(key);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
