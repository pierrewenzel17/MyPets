using System.Collections.Generic;
using System.Threading.Tasks;
using MyPetsCore.DTOs;

namespace MyPetsWeb.WebServices
{
    public sealed class RoundWebService : WebService
    {
        public readonly string _document;
        public RoundWebService() : base("Round")
        {
            _document = BaseUrl + "Document" + "/";
        }

        #region Get Request

        public async Task<RoundDto> GetRoundByIdAsync(int id)
        {
            return await new HttpRequestService<RoundDto>().GetByIdAsync(id, BaseUrl, Api);
        }

        public async Task<RoundToInvestigationDocumentDto> GetRoundToDocumentByIdAsync(int id)
        {
            return await new HttpRequestService<RoundToInvestigationDocumentDto>().GetByIdAsync(id, _document, Api);
        }

        public async Task<IEnumerable<InvestigationToRoundDto>> GetAllRoundToDocumentsAsync(int id)
        {
            return await new HttpRequestService<InvestigationToRoundDto>().GetAttach(id, _document, Api);
        }

        #endregion

        #region Post Request

        public async Task<RoundDto> CreateRoundAsync(RoundDto round)
        {
            return await new HttpRequestService<RoundDto>().CreateAsync(round, BaseUrl, Api);
        }

        public async Task<RoundToInvestigationDocumentDto> AttachDocumentAsync(RoundToInvestigationDocumentDto document)
        {
            return await new HttpRequestService<RoundToInvestigationDocumentDto>().CreateAsync(document, _document, Api);
        }

        #endregion

        #region Put Request

        public async Task<RoundDto> UpdateRoundAsync(int id, RoundDto round)
        {
            return await new HttpRequestService<RoundDto>().UpdateAsync(id, round, BaseUrl, Api);
        }

        #endregion

        #region Delete Request

        public async Task DeleteRoundAsync(int id)
        {
            await new HttpRequestService<RoundDto>().DeleteAsync(id, BaseUrl, Api);
        }

        public async Task DeleteAttachDocumentAsync(int id)
        {
            await new HttpRequestService<RoundToInvestigationDocumentDto>().DeleteAsync(id, _document, Api);
        }

        #endregion
    }
}
