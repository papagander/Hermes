using DataAccess.EFCore.Interfaces.Repositories.Generic;

namespace DataAccess.EFCore.Interfaces.Repositories.Queries
{
    public interface ICriterionRepository : ICrdRepository<Criterion>
    {
        Criterion? GetByStatementId(int statementId);

    }
}

