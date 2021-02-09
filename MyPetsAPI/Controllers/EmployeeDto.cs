using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using MyPetsAPI.Services.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPetsCore.DTO;

namespace MyPetsAPI.Controllers
{
    public class EmployeeDto : Controller
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<EmployeeDto>> Get()
        {
            try
            {
                IServiceGet<EmployeeDto, EmployeeDao> getService = new IServiceGet<EmployeeDto, EmployeeDao>;
                return getService.Get();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{key}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<EmployeeDto> Get([FromRoute] uint key)
        {
            try
            {
                if (key == 0) return StatusCode(400);
                IServiceGet<EmployeeDto, EmployeeDao> getService = new IServiceGet<EmployeeDto, EmployeeDao>;
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
        public ActionResult<bool> Post([FromBody] EmployeeDto employeeDto)
        {
            try
            { 
                IServiceCreate<EmployeeDto, EmployeeDao> createService = new IServiceCreate<EmployeeDto, EmployeeDao>;
                return createService.Create(employeeDto);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        
        // PUT api/values/5
        [HttpPut]
        public ActionResult<bool> Put([FromBody] EmployeeDto employeeDto)
        {
            try
            {
                IServiceUpdate<EmployeeDto, EmployeeDao> updateService = new IServiceUpdate<EmployeeDto, EmployeeDao>;
                return updateService.Update(employeeDto);
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
                IServiceDelete<EmployeeDto, EmployeeDao> deleteService = new IServiceDelete<EmployeeDto, EmployeeDao>;
                return deleteService.Delete(key);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}