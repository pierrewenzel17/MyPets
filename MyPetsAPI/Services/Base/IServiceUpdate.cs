using System;
using System.Reflection.Metadata.Ecma335;

namespace MyPetsAPI.Services.Base
{
    public interface IServiceUpdate<DTO,DAO> where DTO : new() where DAO : new()
    {
        public sealed bool Update(DTO dto)
        {
            try
            {

            }
            catch (Exception exception)
            {
                Console.WriteLine("It's a exception");
            }

            return false;
        }
    }
}