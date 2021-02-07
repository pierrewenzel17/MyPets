using System;
using System.Collections.Generic;

namespace MyPetsAPI.Services.Base
{
    public interface IServiceGet<DTO, DAO> where DTO : new() where DAO : new()
    {
        public DTO Get(uint key)
        {
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return new DTO();
        }

        public List<DTO> Get()
        {
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return new List<DTO>();
        }
    }
}