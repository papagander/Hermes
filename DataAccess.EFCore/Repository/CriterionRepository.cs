using System;
namespace DataAccess.EFCore.Repository
{
    public class CriterionRepository : GenericRepository<Criterion> , ICriterionRepository
    {
        public CriterionRepository(ReportContext reportContext) : base(reportContext)
        {
        }
        public Criterion? GetCriterionByStatementId(int statementId)
        {
            return (from cr in _context.Criteria where cr.StatementId == statementId select cr).FirstOrDefault();
        }
    }
}

