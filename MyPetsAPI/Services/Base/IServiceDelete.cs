using System;

namespace MyPetsAPI.Services.Base
{

    public interface IServiceDelete<DTO, DAO> where DTO : new() where DAO : new()
    {
        public virtual bool Delete(uint key)
        {
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }

       
    }
}