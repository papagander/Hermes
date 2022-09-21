using System;
namespace DataAccess.EFCore.Repository
{
    public class CriterionRepository : CrdRepository<Criterion> , ICriterionRepository
    {
        public CriterionRepository(ReportContext reportContext) : base(reportContext)
        {
        }
        public Criterion? GetByStatementId(int statementId)
        {
            return (from cr in _context.Criteria where cr.StatementId == statementId select cr).FirstOrDefault();
        }
    }
}

