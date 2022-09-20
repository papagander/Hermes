namespace DataAccess.EFCore.Interfaces
{
    public interface ICriterionRepository : IGenericRepository<Criterion>
    {
        Criterion? GetByStatementId(int statementId);
    }
}

