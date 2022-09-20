namespace DataAccess.EFCore.Interfaces
{
    public interface ICriterionRepository : IGenericRepository<Criterion>
    {
        Criterion? GetCriterionByStatementId(int statementId);
    }
}

