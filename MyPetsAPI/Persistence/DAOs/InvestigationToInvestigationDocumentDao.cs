using Microsoft.EntityFrameworkCore;
using MyPetsAPI.Models;
using MyPetsAPI.Persistence.Repositories;

namespace MyPetsAPI.Persistence.DAOs
{
    public class InvestigationToInvestigationDocumentDao : Repository<InvestigationToInvestigationDocument>
    {
        public InvestigationToInvestigationDocumentDao(DbContext context) : base(context)
        {
        }
        public MyPetsContext MyPetsContext => Context as MyPetsContext;
    }
}