using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MyPetsCore.DTOs;

namespace MyPetsWeb.WebServices
{
    public sealed class LoginWebService : WebService
    {
        public LoginWebService() : base("Login")
        {
        }

        public async Task<PersonDto> ConnectionAsync(string email, string password)
        {
            try
            {
                var response = await Api.GetAsync(BaseUrl + $"Username/{email}/Password/{password}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<PersonDto>();
            }
            catch (Exception e)
            {
                throw new HttpRequestException($"We can't connect the user = {email} " + e.Message, e);
            }
        }
    }
}