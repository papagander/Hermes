using System;
namespace DataAccess.EFCore.Interfaces.Repositories.Reports
{
    public interface IConjunctionRepository : ICrdRepository<Conjunction>
    {
        Conjunction? GetByStatementId(int statementId);
    }
}

