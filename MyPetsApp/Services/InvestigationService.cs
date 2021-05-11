using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accessibility;
using Microsoft.VisualBasic;
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

        public InvestigationDto Map(Investigation investigation)
        {
            if(investigation.HolderInvestigatorId.PersonId is not null && 
               investigation.InvestigationOffenderId.InvestigationPersonId != null &&
               investigation.InvestigationPlaintiffId.InvestigationPersonId != null)
                return new(investigation.InvestigationId, 
                    (int)investigation.HolderInvestigatorId.PersonId,
                    (int)investigation.InvestigationOffenderId.InvestigationPersonId,
                    (int)investigation.InvestigationPlaintiffId.InvestigationPersonId,
                    investigation.Reason, investigation.Breed, investigation.NumberOfPets, false);
            return null;
        }

        public async Task Create(Investigation investigation)
        {
            InvestigationPersonService ipService = new();
            InvestigationWebService ws = new();
            var p = await ipService.Create(investigation.InvestigationOffenderId);
            var p2 = await ipService.Create(investigation.InvestigationPlaintiffId);
            investigation.InvestigationOffenderId.InvestigationPersonId = p.InvestigationPersonId;
            investigation.InvestigationPlaintiffId.InvestigationPersonId = p2.InvestigationPersonId;
            await ws.CreateInvestigationAsync(Map(investigation));

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
