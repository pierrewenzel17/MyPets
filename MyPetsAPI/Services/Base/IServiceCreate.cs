using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyPetsAPI.Services.Base
{
    public interface IServiceCreate<DTO, DAO> where  DTO : new() where DAO : new()
    {
        public sealed void Create(DTO dto)
        {
            try
            {

            }
            catch (Exception exception)
            {
                Console.WriteLine("Ca a planté");
                
            }

        }
    }
}
