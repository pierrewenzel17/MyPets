using MyPetsAPI.Services.Base;

namespace MyPetsAPI.Services
{
    public sealed class ServiceUser : IServiceCreate<DtoUser,DaoUser>, IServiceDelete<object, object>, 
                                      IServiceGet<object, object>, IServiceUpdate<object, object>
    {
        public ServiceUser()
        {
            
        }
    }
}