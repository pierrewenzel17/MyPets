using MyPetsAPI.Models;
using MyPetsCore.DTOs;

namespace MyPetsAPI.DtoMapper
{
    public class InvestigationToRoundMapper : IDtoMapper<InvestigationToRoundDto, InvestigationToRound>
    {
        public InvestigationToRoundDto ToDto(InvestigationToRound model)
        {
            return new(model.InvestigationToRoundId, model.RoundId, model.InvestigationId);
        }

        public InvestigationToRound ToModel(InvestigationToRoundDto dto)
        {
            return new()
            {
                InvestigationToRoundId = dto.InvestigationToRoundId,
                RoundId = dto.RoundId,
                InvestigationId = dto.InvestigationId
            };
        }
    }
}