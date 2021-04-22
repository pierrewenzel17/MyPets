using Microsoft.EntityFrameworkCore;
using MyPetsAPI.Models;
using MyPetsAPI.Persistence.Repositories;

namespace MyPetsAPI.Persistence.DAOs
{
    public class InvestigationPersonDao : Repository<InvestigationPerson>
    {
        public InvestigationPersonDao(MyPetsContext context) : base(context)
        {
        }
        public MyPetsContext MyPetsContext => Context as MyPetsContext;
    }
}