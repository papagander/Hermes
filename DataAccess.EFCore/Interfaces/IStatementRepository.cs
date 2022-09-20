using System;
namespace DataAccess.EFCore.Interfaces
{
    public interface IStatementRepository : IGenericRepository<Statement>
    {
        IEnumerable<Statement> GetStatementsByConjunctionId(int conjunctionId);
    }
}

