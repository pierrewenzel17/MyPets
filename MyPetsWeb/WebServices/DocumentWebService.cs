using System.Threading.Tasks;
using MyPetsCore.DTOs;

namespace MyPetsWeb.WebServices
{
    public sealed class DocumentWebService : WebService
    {
        public DocumentWebService() : base("Document")
        {
            
        }

        public async Task<InvestigationDocumentDto> GetDocumentByIdAsync(int id)
        {
            return await new HttpRequestService<InvestigationDocumentDto>().GetByIdAsync(id, BaseUrl, Api);
        }

        public async Task<InvestigationDocumentDto> CreateDocumentAsync(InvestigationDocumentDto document)
        {
            return await new HttpRequestService<InvestigationDocumentDto>().CreateAsync(document, BaseUrl, Api);
        }

        public async Task DeleteDocumentAsync(int id)
        {
            await new HttpRequestService<InvestigationDocumentDto>().DeleteAsync(id, BaseUrl, Api);
        }
    }
}