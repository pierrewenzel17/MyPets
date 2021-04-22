using MyPetsAPI.Models;
using MyPetsCore.DTOs;

namespace MyPetsAPI.DtoMapper
{
    public class RoundToInvestigationDocumentMapper : IDtoMapper<RoundToInvestigationDocumentDto, RoundToInvestigationDocument>
    {
        public RoundToInvestigationDocumentDto ToDto(RoundToInvestigationDocument model)
        {
            return new(model.RoundToInvestigationDocumentId, model.RoundId, model.InvestigationDocumentId);
        }

        public RoundToInvestigationDocument ToModel(RoundToInvestigationDocumentDto dto)
        {
            return new()
            {
                RoundToInvestigationDocumentId = dto.RoundToInvestigationDocumentId,
                InvestigationDocumentId = dto.InvestigationDocumentId, 
                RoundId = dto.RoundId
            };
        }
    }
}