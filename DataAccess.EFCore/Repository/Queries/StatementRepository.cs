
using System;
namespace DataAccess.EFCore.Repository.Reports
{
    public class StatementRepository : GenericRepository<Statement>, IStatementRepository
    {
        public StatementRepository(ReportContext reportContext) : base(reportContext)
        {
        }
        public IEnumerable<Statement> GetRangeByConjunctionId(int conjunctionId)
        {
            return (from statement in _context.Statements where statement.ConjunctionId == conjunctionId select statement);
        }
    }
}

