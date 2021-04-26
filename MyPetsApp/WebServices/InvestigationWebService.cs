using System.Collections.Generic;
using System.Threading.Tasks;
using MyPetsCore.DTOs;

namespace MyPetsApp.WebServices
{
    public sealed class InvestigationWebService : WebService
    {
        private readonly string _roundUrl;
        private readonly string _documentUrl;

        public InvestigationWebService() : base("Investigation")
        {
            _roundUrl = BaseUrl + "Round" + "/";
            _documentUrl = BaseUrl + "Document" + "/";
        }

        #region Get Request
        public async Task<InvestigationDto> GetInvestigationByIdAsync(int id)
        {
            return await new HttpRequestService<InvestigationDto>().GetByIdAsync(id, BaseUrl, Api);
        }

        public async Task<IEnumerable<InvestigationDto>> GetAllInvestigationsAsync()
        {
            return await new HttpRequestService<InvestigationDto>().GetAllAsync(BaseUrl, Api);
        }

        public async Task<InvestigationToRoundDto> GetInvestigationToRoundByIdAsync(int id)
        {
            return await new HttpRequestService<InvestigationToRoundDto>().GetByIdAsync(id, _roundUrl, Api);
        }

        public async Task<IEnumerable<InvestigationToRoundDto>> GetAllInvestigationToRoundAsync(int id)
        {
            return await new HttpRequestService<InvestigationToRoundDto>().GetAttach(id, _roundUrl, Api);
        }

        public async Task<InvestigationToInvestigationDocumentDto> GetInvestigationToInvestigationDocumentByIdAsync(int id)
        {
            return await new HttpRequestService<InvestigationToInvestigationDocumentDto>().GetByIdAsync(id, _documentUrl, Api);
        }

        public async Task<IEnumerable<InvestigationToInvestigationDocumentDto>> GetAllInvestigationToInvestigationDocumentAsync(int id)
        {
            return await new HttpRequestService<InvestigationToInvestigationDocumentDto>().GetAttach(id, _documentUrl, Api);
        }

        #endregion

        #region Post Request

        public async Task<InvestigationDto> CreateInvestigationAsync(InvestigationDto investigation)
        {
            return await new HttpRequestService<InvestigationDto>().CreateAsync(investigation, BaseUrl, Api);
        }

        public async Task<InvestigationToRoundDto> AttachRoundAsync(InvestigationToRoundDto round)
        {
            return await new HttpRequestService<InvestigationToRoundDto>().CreateAsync(round, _roundUrl, Api);
        }

        public async Task<InvestigationToInvestigationDocumentDto> AttachDocumentAsync(InvestigationToInvestigationDocumentDto document)
        {
            return await new HttpRequestService<InvestigationToInvestigationDocumentDto>().CreateAsync(document, _documentUrl, Api);
        }

        #endregion

        #region Put Request

        public async Task<InvestigationDto> UpdateInvestigationAsync(int id, InvestigationDto investigation)
        {
            return await new HttpRequestService<InvestigationDto>().UpdateAsync(id, investigation, BaseUrl, Api);
        }

        #endregion

        #region Delete Request

        public async Task DeleteInvestigationAsync(int id)
        {
            await new HttpRequestService<InvestigationDto>().DeleteAsync(id , BaseUrl, Api);
        }

        public async Task DeleteAttachRoundAsync(int id)
        {
            await new HttpRequestService<InvestigationToRoundDto>().DeleteAsync(id, _roundUrl, Api);
        }

        public async Task DeleteAttachDocumentAsync(int id)
        {
            await new HttpRequestService<InvestigationToInvestigationDocumentDto>().DeleteAsync(id, _documentUrl, Api);
        }

        #endregion

    }
}