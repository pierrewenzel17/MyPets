using MyPetsAPI.Models;
using MyPetsAPI.Persistence.DAOs;

namespace MyPetsAPI.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyPetsContext _context;

        public UnitOfWork(MyPetsContext context)
        {
            _context = context;
            Investigations = new InvestigationDao(_context);
            InvestigationDocuments = new InvestigationDocumentDao(_context);
            InvestigationPersons = new InvestigationPersonDao(_context);
            InvestigationToInvestigationDocuments = new InvestigationToInvestigationDocumentDao(_context);
            InvestigationToRounds = new InvestigationToRoundDao(_context);
            Persons = new PersonDao(_context);
            Rounds = new RoundDao(_context);
            RoundToInvestigationDocuments = new RoundToInvestigationDocumentDao(_context);
        }

        #region Dao Attirbutes
        public InvestigationDao Investigations { get; init; }
        public InvestigationDocumentDao InvestigationDocuments { get; init; }
        public InvestigationPersonDao InvestigationPersons { get; init; }
        public InvestigationToInvestigationDocumentDao InvestigationToInvestigationDocuments { get; init; }
        public InvestigationToRoundDao InvestigationToRounds { get; init; }
        public PersonDao Persons { get; init; }
        public RoundDao Rounds { get; init; }
        public RoundToInvestigationDocumentDao RoundToInvestigationDocuments { get; init; }
        #endregion



        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}