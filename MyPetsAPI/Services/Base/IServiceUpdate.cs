using System;

namespace MyPetsAPI.Services.Base
{
    public interface IServiceUpdate<DTO,DAO> where DTO : new() where DAO : new()
    {
        public sealed void Update(DTO dto)
        {
            try
            {

            }
            catch (Exception exception)
            {
                Console.WriteLine("It's a exception");
            }
        }
        
    }
}