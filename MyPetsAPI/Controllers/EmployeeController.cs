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
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<EmployeeController>> Get()
        {
            try
            {
                IServiceGet<EmployeeController, EmployeeDao> getService = new IServiceGet<EmployeeController, EmployeeDao>;
                return getService.Get();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500);
            }
        }

        [HttpGet("{key}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<EmployeeController> Get([FromRoute] uint key)
        {
            try
            {
                if (key == 0) return StatusCode(400);
                IServiceGet<EmployeeController, EmployeeDao> getService = new IServiceGet<EmployeeController, EmployeeDao>;
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
        public ActionResult<bool> Post([FromBody] EmployeeController employeeDto)
        {
            try
            { 
                IServiceCreate<EmployeeController, EmployeeDao> createService = new IServiceCreate<EmployeeController, EmployeeDao>;
                return createService.Create(employeeDto);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        
        // PUT api/values/5
        [HttpPut]
        public ActionResult<bool> Put([FromBody] EmployeeController employeeDto)
        {
            try
            {
                IServiceUpdate<EmployeeController, EmployeeDao> updateService = new IServiceUpdate<EmployeeController, EmployeeDao>;
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
                IServiceDelete<EmployeeController, EmployeeDao> deleteService = new IServiceDelete<EmployeeController, EmployeeDao>;
                return deleteService.Delete(key);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}