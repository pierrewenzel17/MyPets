using System.Collections.Generic;
using System.Threading.Tasks;
using MyPetsCore.DTOs;

namespace MyPetsApp.WebServices
{
    public sealed class PersonWebService : WebService
    {
        private readonly string _investigation;
        public PersonWebService() : base("Person")
        {
            _investigation = BaseUrl + "Investigation" + "/";
        }

        #region Get Request

        public async Task<PersonDto> GetPersonByIdAsync(int id)
        {
            return await new HttpRequestService<PersonDto>().GetByIdAsync(id, BaseUrl, Api);
        }

        public async Task<InvestigationPersonDto> GetInvestigationPersonByIdAsync(int id)
        {
            return await new HttpRequestService<InvestigationPersonDto>().GetByIdAsync(id, _investigation, Api);
        }

        public async Task<IEnumerable<PersonDto>> GetAllPersonsAsync()
        {
            return await new HttpRequestService<PersonDto>().GetAllAsync(BaseUrl, Api);
        }

        public async Task<IEnumerable<InvestigationPersonDto>> GetAllInvestigationPersonsAsync()
        {
            return await new HttpRequestService<InvestigationPersonDto>().GetAllAsync(_investigation, Api);
        }

        #endregion

        #region Post Request

        public async Task<PersonDto> CreatePersonAsync(PersonDto person)
        {
            return await new HttpRequestService<PersonDto>().CreateAsync(person, BaseUrl, Api);
        }

        public async Task<InvestigationPersonDto> CreateInvestigationPersonAsync(InvestigationPersonDto investigationPerson)
        {
            return await new HttpRequestService<InvestigationPersonDto>().CreateAsync(investigationPerson, _investigation, Api);
        }

        #endregion

        #region Put Request

        public async Task<PersonDto> UpdatePersonAsync(int id, PersonDto person)
        {
            return await new HttpRequestService<PersonDto>().UpdateAsync(id, person, BaseUrl, Api);
        }

        public async Task<InvestigationPersonDto> UpdateInvestigationPersonAsync(int id, InvestigationPersonDto investigationPerson)
        {
            return await new HttpRequestService<InvestigationPersonDto>().UpdateAsync(id, investigationPerson, _investigation, Api);
        }

        #endregion

        #region Delete Request

        public async Task DeletePersonAsync(int id)
        {
            await new HttpRequestService<PersonDto>().DeleteAsync(id, BaseUrl, Api);
        }

        public async Task DeleteInvestigationPersonAsync(int id)
        {
            await new HttpRequestService<InvestigationPersonDto>().DeleteAsync(id, _investigation, Api);
        }

        #endregion

    }
}
