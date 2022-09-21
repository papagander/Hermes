using System;
namespace DataAccess.EFCore.Interfaces
{
    public interface IStatementRepository : ICrdRepository<Statement>
    {
        IEnumerable<Statement> GetRangeByConjunctionId(int conjunctionId);
    }
}

