using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyPetsApp.WebServices
{
    internal class HttpRequestService<TDto> where TDto : class
    {
        public async Task<TDto> GetByIdAsync(int id, string url, HttpClient client)
        {
            try
            {
                var response = await client.GetAsync(url + id);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<TDto>();
            }
            catch (Exception e)
            {
                throw new HttpRequestException($"We can't return the object with id = {id} because : " + e.Message, e);
            }
        }

        public async Task<IEnumerable<TDto>> GetAttach(int id, string url, HttpClient client)
        {
            try
            {
                var response = await client.GetAsync(url + id);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<IEnumerable<TDto>>();
            }
            catch (Exception e)
            {
                throw new HttpRequestException($"We can't return the list of object attach in id = {id} because : " + e.Message, e);
            }
        }

        public async Task<IEnumerable<TDto>> GetAllAsync(string url, HttpClient client)
        {
            try
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<IEnumerable<TDto>>();
            }
            catch (Exception e)
            {
                throw new HttpRequestException("We can't return the list of all object because : " + e.Message, e);
            }
        }

        public async Task<TDto> CreateAsync(TDto dto, string url, HttpClient client)
        {
            try
            {
                var response = await client.PostAsJsonAsync(url, dto);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<TDto>();
            }
            catch (Exception e)
            {
                throw new HttpRequestException("We can't create the new object because : " + e.Message, e);
            }
        }

        public async Task<TDto> UpdateAsync(int id, TDto dto, string url, HttpClient client)
        {
            try
            {
                var response = await client.PutAsJsonAsync(url + id, dto);
                response.EnsureSuccessStatusCode();
                dto = await response.Content.ReadFromJsonAsync<TDto>();
                return dto;
            }
            catch (Exception e)
            {
                throw new HttpRequestException($"We can't update object with id={id} because : " + e.Message, e);
            }
        }

        public async Task DeleteAsync(int id, string url, HttpClient client)
        {
            try
            {
                var response = await client.DeleteAsync(url + id);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw new HttpRequestException("We can't deleted because : " + e.Message, e);
            }
        }
    }
}