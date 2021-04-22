using MyPetsAPI.Models;
using MyPetsCore.DTOs;

namespace MyPetsAPI.DtoMapper
{
    public class InvestigationToInvestigationDocumentMapper : IDtoMapper<InvestigationToInvestigationDocumentDto, InvestigationToInvestigationDocument>
    {
        public InvestigationToInvestigationDocumentDto ToDto(InvestigationToInvestigationDocument model)
        {
            return new(
                model.InvestigationToInvestigationDocumentId, 
                model.InvestigationId, 
                model.InvestigationDocumentId
            );
        }

        public InvestigationToInvestigationDocument ToModel(InvestigationToInvestigationDocumentDto dto)
        {
            return new()
            {
                InvestigationToInvestigationDocumentId = dto.InvestigationToInvestigationDocumentId,
                InvestigationId = dto.InvestigationId,
                InvestigationDocumentId = dto.InvestigationDocumentId
            };
        }
    }
}