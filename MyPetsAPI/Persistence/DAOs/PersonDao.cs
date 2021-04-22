using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MyPetsAPI.Models;
using MyPetsAPI.Persistence.Repositories;

namespace MyPetsAPI.Persistence.DAOs
{
    public class PersonDao : Repository<Person>, IPersonRepository
    {
        public PersonDao(MyPetsContext context) : base(context)
        {
        }

        public IEnumerable<Person> GetSalary()
        {
            throw new NotImplementedException();
        }

        public MyPetsContext MyPetsContext => Context as MyPetsContext;
    }
}
