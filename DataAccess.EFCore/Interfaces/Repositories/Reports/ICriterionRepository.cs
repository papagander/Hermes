namespace DataAccess.EFCore.Interfaces.Repositories.Reports
{
    public interface ICriterionRepository : ICrdRepository<Criterion>
    {
        Criterion? GetByStatementId(int statementId);

    }
}

