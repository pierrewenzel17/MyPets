using MyPetsAPI.Models;
using MyPetsCore.DTOs;

namespace MyPetsAPI.DtoMapper
{
    public class InvestigationMapper : IDtoMapper<InvestigationDto, Investigation>
    {
        public InvestigationDto ToDto(Investigation model)
        {
            return new(
                model.InvestigationId, 
                model.HolderInvestigatorId,
                model.InvestigationOffenderId, 
                model.InvestigationPlaintiffId, 
                model.Reason,
                model.Breed,
                model.NumberOfPets,
                model.IsFinish
            );
        }

        public Investigation ToModel(InvestigationDto dto)
        {
            return new()
            {
                InvestigationId = dto.InvestigationId,
                HolderInvestigatorId = dto.HolderInvestigatorId,
                InvestigationOffenderId = dto.InvestigationOffenderId,
                InvestigationPlaintiffId = dto.InvestigationPlaintiffId,
                Reason = dto.Reason,
                Breed = dto.Breed,
                NumberOfPets = dto.NumberOfPets,
                IsFinish = dto.IsFinish
            };
        }
    }
}