using System;
using DataAccess.EFCore.Interfaces.Repositories.Generic;

namespace DataAccess.EFCore.Interfaces
{
    public interface IStatementRepository : ICrdRepository<Statement>
    {
        IEnumerable<Statement> GetRangeByConjunctionId(int conjunctionId);
    }
}

