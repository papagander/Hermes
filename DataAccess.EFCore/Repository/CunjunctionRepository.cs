using System;
namespace DataAccess.EFCore.Repository
{
    public class ConjunctionRepository : GenericRepository<Conjunction> , IConjunctionRepository
    {
        public ConjunctionRepository(ReportContext reportContext) : base(reportContext)
        {
        }
        public Conjunction? GetByStatementId(int statementId)
        {
            return (from cj in _context.Conjuctions where cj.StatementId == statementId select cj).FirstOrDefault();
        }
    }
}

