using System;
namespace DataAccess.EFCore.Interfaces
{
    public interface IConjunctionRepository : IGenericRepository<Conjunction>
    {
        Conjunction? GetByStatementId(int statementId);
    }
}

