using System;
namespace DataAccess.EFCore.Interfaces.Repositories.Queries
{
    public interface IConjunctionRepository : ICrdRepository<Conjunction>
    {
        Conjunction? GetByStatementId(int statementId);
    }
}

