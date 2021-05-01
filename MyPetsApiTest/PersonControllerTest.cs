using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using MyPetsAPI.Controllers;
using MyPetsCore.DTOs;
using Xunit;
using Xunit.Abstractions;

namespace MyPetsApiTest
{
    public class PersonControllerTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private PersonController _controller;
        private PersonDto _person;

        public PersonControllerTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            ILoggerFactory loggerFactory = new NullLoggerFactory();
            _controller = new PersonController(loggerFactory.CreateLogger<PersonController>());
            _person = new PersonDto(99999, "MyTest", "MyTest", "test@test.fr", "test", "test",
                "test", "03 87 87 87 87", 2, "Test", "Test");
        }

        [Fact]
        public void CreatePerson_PersonIsNull_ReturnsBadRequest()
        {
            var badRequestResult = _controller.Post(null);
            Assert.IsType<BadRequestObjectResult>(badRequestResult.Result);
        }

        /*
        [Fact]
        public void CreatePerson_PersonObject_ReturnsCreate()
        {
            var createResult = _controller.Post(_person);
            Assert.IsType<CreatedAtActionResult>(createResult.Result);
        }
        
        [Fact]
        public void GetPerson_IdIsPersonId_ReturnsOk()
        {
            // Act
            _testOutputHelper.WriteLine(_person.PersonId.ToString());
            var okResult = _controller.Get(_person.PersonId);
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        */
        [Fact]
        public void GetPerson_IdIsNull_ReturnsBadRequest()
        {
            // Act
            var badRequestResult = _controller.Get(null);
            // Assert
            Assert.IsType<BadRequestObjectResult>(badRequestResult.Result);
        }
        /*
        [Fact]
        public void GetPerson_IdIsPersonIdMinusOne_ReturnsNotFound()
        {
            // Act
            var notFoundResult = _controller.Get(_person.PersonId -1);
            // Assert
            Assert.IsType<NotFoundObjectResult>(notFoundResult.Result);
        }*/

        [Fact]
        public void Remove_IdIsNull_ReturnsBadRequest()
        {
            // Act
            var okResponse = _controller.Delete(null);
            // Assert
            Assert.IsType<BadRequestObjectResult>(okResponse);
        }
        /*
        [Fact]
        public void Remove_IdIsPersonId_ReturnsNoContent()
        {
            var okResponse = _controller.Delete(_person.PersonId);
            // Assert
            Assert.IsType<NoContentResult>(okResponse);
        }*/
    }
}