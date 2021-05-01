using System.Threading.Tasks;
using MyPetsApp.Models;
using MyPetsApp.WebServices;
using MyPetsCore.DTOs;

namespace MyPetsApp.Services
{
    public class InvestigationPersonService
    {
        public InvestigationPerson Map(InvestigationPersonDto person)
        {
            return new()
            {
                InvestigationPersonId = person.InvestigationPersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                PhoneNumber = person.PhoneNumber,
                Address = person.Address,
                ZipCode = person.ZipCode,
                City = person.City,
                Type = person.Type
            };
        }
        public async Task<InvestigationPerson> GetInvestigationPerson(int id)
        {
            PersonWebService ws = new();
            return Map(await ws.GetInvestigationPersonByIdAsync(id));
        }

    }
}