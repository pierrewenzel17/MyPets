using System;
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
            Person p = new()
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                PhoneNumber = person.PhoneNumber,
                Address = person.Address,
                ZipCode = person.ZipCode,
                City = person.City,
                Password = person.Password,
                Zone = person.Zone
            };

            p.Set(person.Hierarchy);

            return p;
        }

        public PersonDto Map(Person model)
        {
            int hierarchy = 0;

            switch (model.Hierarchy)
            {
                case "Bénévole":
                    hierarchy = 1;
                    break;
                case "Salarié":
                    hierarchy = 2;
                    break;
                case "Administrateur":
                    hierarchy = 3;
                    break;
            }

            return new(
                model.PersonId,
                model.FirstName,
                model.LastName,
                model.Email,
                model.Address,
                model.ZipCode,
                model.City,
                model.PhoneNumber,
                hierarchy,
                model.Zone,
                model.Password
            );
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

        public async Task<Person> UpdatePerson(int id, Person person)
        {
            PersonWebService ws = new();
            return Map(await ws.UpdatePersonAsync(id, Map(person)));
        }
    }
}