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

        public InvestigationPersonDto Map(InvestigationPerson person)
        {
            return new(person.InvestigationPersonId, person.FirstName, person.LastName, person.Email, person.Address,
                person.ZipCode, person.City, person.PhoneNumber, person.Type);
        }

        public async Task<InvestigationPerson> GetInvestigationPerson(int id)
        {
            PersonWebService ws = new();
            return Map(await ws.GetInvestigationPersonByIdAsync(id));
        }

        public async Task<InvestigationPersonDto> Create(InvestigationPerson investigationPerson)
        {
            PersonWebService ws = new();
            return await ws.CreateInvestigationPersonAsync(Map(investigationPerson));
        }

        public async Task<InvestigationPersonDto> Update(int id, InvestigationPerson investigation)
        {
            PersonWebService ws = new();
            return await ws.UpdateInvestigationPersonAsync(id, Map(investigation));
        }
    }
}