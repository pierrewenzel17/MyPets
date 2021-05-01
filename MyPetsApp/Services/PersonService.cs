using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyPetsApp.Models;
using MyPetsApp.WebServices;
using MyPetsCore.DTOs;

namespace MyPetsApp.Services
{
    public class PersonService
    {
        public Person Map(PersonDto person)
        {
            return new()
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                PhoneNumber = person.PhoneNumber,
                Address = person.Address,
                ZipCode = person.ZipCode,
                City = person.City,
                Hierarchy = (Level) person.Hierarchy,
                Password = person.Password,
                Zone = person.Zone
            };
        }

        public async Task<Person> GetPerson(int id)
        {
            PersonWebService ws = new ();
            return Map(await ws.GetPersonByIdAsync(id));
        }

        public async Task<IEnumerable<Person>> Get()
        {
            PersonWebService iws = new();
            var dtos = await iws.GetAllPersonsAsync();
            return dtos.Select(personDto => Map(personDto)).ToList();
        }
    }
}