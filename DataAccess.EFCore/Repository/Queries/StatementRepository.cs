
using System;

namespace DataAccess.EFCore.Repository.Queries
{
    public class StatementRepository : IndexedRepository<Statement>, IStatementRepository
    {
        SuperTypeRepository<Statement, Criterion> SupCr;
        SuperTypeRepository<Statement, Conjunction> SupCj;
        ReferencesRepository<Statement, Conjunction> RefCj;
        public StatementRepository(ReportContext reportContext) : base(reportContext)
        {
            SupCr = new SuperTypeRepository<Statement, Criterion>(_context);
            SupCj = new SuperTypeRepository<Statement, Conjunction>(_context);
            RefCj = new ReferencesRepository<Statement, Conjunction>(_context);
        }

        public ISubTypeOf<Statement> GetChild(Statement MyT)
        {
            ISubTypeOf<Statement>? subTypeOfStatement = SupCr.GetChild(MyT);
            if (subTypeOfStatement is not null) return subTypeOfStatement;

            subTypeOfStatement = SupCj.GetChild(MyT);
            if (subTypeOfStatement is not null) return subTypeOfStatement;

            throw new NullReferenceException("Statement does not have a sub - entity.");
        }

        public IEnumerable<Statement> GetRange(Conjunction MyTRef) => RefCj.GetRange(MyTRef);
        /*
public IEnumerable<Statement> GetRangeByConjunctionId(int conjunctionId)
{
   return (from statement in _context.Statements where statement.ConjunctionId == conjunctionId select statement);
}
*/
    }
}

