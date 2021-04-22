using MyPetsAPI.Models;
using MyPetsCore.DTOs;

namespace MyPetsAPI.DtoMapper
{
    public class InvestigationDocumentMapper : IDtoMapper<InvestigationDocumentDto, InvestigationDocument>
    {
        public InvestigationDocumentDto ToDto(InvestigationDocument model)
        {
            return new(model.InvestigationDocumentId, model.File);
        }

        public InvestigationDocument ToModel(InvestigationDocumentDto dto)
        {
            return new()
            {
                InvestigationDocumentId = dto.InvestigationDocumentId,
                File = dto.File
            };
        }
    }
}