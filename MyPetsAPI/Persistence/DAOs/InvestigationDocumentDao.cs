using Microsoft.EntityFrameworkCore;
using MyPetsAPI.Models;
using MyPetsAPI.Persistence.Repositories;

namespace MyPetsAPI.Persistence.DAOs
{
    public class InvestigationDocumentDao : Repository<InvestigationDocument>
    {
        public InvestigationDocumentDao(MyPetsContext context) : base(context)
        {
        }
        public MyPetsContext MyPetsContext => Context as MyPetsContext;
    }
}