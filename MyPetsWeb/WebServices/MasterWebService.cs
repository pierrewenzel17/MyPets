using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyPetsWeb.WebServices
{
    public abstract class MasterWebService<TDto> where TDto : class
    {
        protected readonly HttpClient Api;
        protected readonly string Url;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelClassName"></param>
        protected MasterWebService(string modelClassName)
        {
            Api = new HttpClient();
            Url = "http://localhost:5000/api/" + modelClassName + "/";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="HttpRequestException"></exception>
        /// <returns></returns>
        public async Task<TDto> GetByIdAsync(int id)
        {
            try
            {
                var response = await Api.GetAsync(Url + id);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<TDto>();
            }
            catch (Exception e)
            {
                throw new HttpRequestException($"We can't return the object with id = {id} because : " + e.Message, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="HttpRequestException"></exception>
        /// <returns></returns>
        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            try
            {
                var response = await Api.GetAsync(Url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<IEnumerable<TDto>>();
            }
            catch (Exception e)
            {
                throw new HttpRequestException("We can't return the list of all object because : " + e.Message, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <exception cref="HttpRequestException"></exception>
        /// <returns></returns>
        public async Task<TDto> CreateAsync(TDto dto)
        {
            try
            {
                var response = await Api.PostAsJsonAsync(Url, dto);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<TDto>();
            }
            catch (Exception e)
            {
                throw new HttpRequestException("We can't create the new object because : " + e.Message, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <exception cref="HttpRequestException"></exception>
        /// <returns></returns>
        public async Task<TDto> UpdateAsync(int id, TDto dto)
        {
            try
            {
                var response = await Api.PutAsJsonAsync(Url + id, dto);
                response.EnsureSuccessStatusCode();
                dto = await response.Content.ReadFromJsonAsync<TDto>();
                return dto;
            }
            catch (Exception e)
            {
                throw new HttpRequestException($"We can't update object with id={id} because : " + e.Message, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="HttpRequestException"></exception>
        public async Task DeleteAsync(int id)
        {
            try
            {
                var response = await Api.DeleteAsync(Url + id);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw new HttpRequestException("We can't deleted because : " + e.Message, e);
            }
        }
    }
}