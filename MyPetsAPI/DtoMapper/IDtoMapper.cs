using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPetsAPI.DtoMapper
{
    interface IDtoMapper<TDto, TModel> where TDto : class where TModel : class
    {
        TDto ToDto(TModel model);
        TModel ToModel(TDto dto);
    }
}
