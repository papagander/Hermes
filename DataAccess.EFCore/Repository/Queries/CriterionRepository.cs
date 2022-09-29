using Domain.Models.Queries;
using Domain.Models.DataSets;

using System;

namespace DataAccess.EFCore.Repository.Queries
{
    public class CriterionRepository : IndexedRepository<Criterion>, ICriterionRepository
    {
        ReferencesRepository<Criterion, Operator> RefOp;
        ReferencesRepository<Criterion, Field> RefF;
        ReferencedByRepository<Criterion, CriterionValue> RefCV;
        public CriterionRepository(ReportContext reportContext) : base(reportContext)
        {
            RefOp = new ReferencesRepository<Criterion, Operator>(_context);
            RefF = new ReferencesRepository<Criterion, Field>(_context);
            RefCV = new ReferencedByRepository<Criterion, CriterionValue>(_context);
        }

        public IEnumerable<CriterionValue> GetChildren(Criterion MyT) => RefCV.GetChildren(MyT);

        public IEnumerable<Criterion> GetRange(Field MyTRef) => RefF.GetRange(MyTRef);

        public IEnumerable<Criterion> GetRange(Operator MyTRef) => RefOp.GetRange(MyTRef);
        /*
public Criterion? GetByStatementId(int statementId)
{
   return (from cr in _context.Criteria where cr.Id == statementId select cr).FirstOrDefault();
}
*/
    }
}

