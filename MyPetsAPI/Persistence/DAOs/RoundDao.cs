using MyPetsAPI.Models;
using MyPetsAPI.Persistence.Repositories;

namespace MyPetsAPI.Persistence.DAOs
{
    public class RoundDao : Repository<Round>
    {
        public RoundDao(MyPetsContext context) : base(context)
        {
        }
        public MyPetsContext MyPetsContext => Context as MyPetsContext;
    }
}