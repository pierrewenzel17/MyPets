using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPetsApp.Models;
using MyPetsApp.WebServices;
using MyPetsCore.DTOs;

namespace MyPetsApp.Services
{
    class LoginService
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
                Hierarchy = (Level)person.Hierarchy,
                Password = person.Password,
                Zone = person.Zone
            };
        }

        public async Task<Person> Connection(string email, string password)
        {
            LoginWebService ws = new();
            return Map(await ws.ConnectionAsync(email, password));
        }
    }
}
