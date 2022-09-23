using System;
using DataAccess.EFCore.Interfaces.Repositories.Generic;

namespace DataAccess.EFCore.Interfaces
{
    public interface IStatementRepository :
        IReferencesRepository<Statement, Conjunction>
    {
    }
}

