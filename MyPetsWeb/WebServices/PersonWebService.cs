using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MyPetsCore.DTOs;

namespace MyPetsWeb.WebServices
{
    public sealed class PersonWebService : MasterWebService<PersonDto>
    {
        public PersonWebService() : base("Person")
        {
            
        }
    }
}
