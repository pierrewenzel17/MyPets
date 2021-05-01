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
    public class InvestigationService
    {
        public async Task<Investigation> Map(InvestigationDto investigationDto)
        {
            Investigation investigation = new()
            {
                InvestigationId = investigationDto.InvestigationId,
                Reason = investigationDto.Reason,
                NumberOfPets = investigationDto.NumberOfPets,
                Breed = investigationDto.Breed
            };
            investigation.Set(investigationDto.IsFinish);
            PersonService ps = new();
            InvestigationPersonService ips = new();
            investigation.HolderInvestigatorId = await ps.GetPerson(investigationDto.HolderInvestigatorId);
            investigation.InvestigationOffenderId = await ips.GetInvestigationPerson(investigationDto.InvestigationOffenderId);
            investigation.InvestigationPlaintiffId = await ips.GetInvestigationPerson(investigationDto.InvestigationPlaintiffId);

            return investigation;
        }

        public async Task<IEnumerable<Investigation>> Get()
        {
            InvestigationWebService iws = new();
            var dtos = await iws.GetAllInvestigationsAsync();
            List<Investigation> investigations = new();
            foreach (var investigationDto in dtos)
                investigations.Add(await Map(investigationDto));
            return investigations;
        }
    }
}
