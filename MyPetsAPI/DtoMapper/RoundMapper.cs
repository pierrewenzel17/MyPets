using MyPetsAPI.Models;
using MyPetsCore.DTOs;

namespace MyPetsAPI.DtoMapper
{
    public class RoundMapper : IDtoMapper<RoundDto, Round>
    {
        public RoundDto ToDto(Round model)
        {
            return new (model.RoundId, model.DateRound, model.CommentRound, model.InvestigatorId);
        }

        public Round ToModel(RoundDto dto)
        {
            return new()
            {
                RoundId = dto.RoundId,
                DateRound = dto.DateRound,
                CommentRound = dto.CommentRound,
                InvestigatorId = dto.InvestigatorId
            };
        }
    }
}