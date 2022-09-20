using System;
namespace DataAccess.EFCore.Repository
{
    public class ConjunctionRepository : GenericRepository<Conjuction> , IConjunctionRepository
    {
        public ConjunctionRepository(ReportContext reportContext) : base(reportContext)
        {
        }
        public Conjunction? GetCriterionByStatementId(int statementId)
        {
            return (from cj in _context.Conjunctions where cj.StatementId == statementId select cj).FirstOrDefault();
        }
    }
}

