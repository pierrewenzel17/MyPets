using Microsoft.EntityFrameworkCore;
using MyPetsAPI.Models;
using MyPetsAPI.Persistence.Repositories;

namespace MyPetsAPI.Persistence.DAOs
{
    public class InvestigationDao : Repository<Investigation>
    {
        public InvestigationDao(MyPetsContext context) : base(context)
        {
        }
        public MyPetsContext MyPetsContext => Context as MyPetsContext;
    }
}