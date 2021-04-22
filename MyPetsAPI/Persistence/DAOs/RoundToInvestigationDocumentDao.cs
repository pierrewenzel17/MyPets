using MyPetsAPI.Models;
using MyPetsAPI.Persistence.Repositories;

namespace MyPetsAPI.Persistence.DAOs
{
    public class RoundToInvestigationDocumentDao : Repository<RoundToInvestigationDocument>
    {
        public RoundToInvestigationDocumentDao(MyPetsContext context) : base(context)
        {
        }
        public MyPetsContext MyPetsContext => Context as MyPetsContext;
    }
}