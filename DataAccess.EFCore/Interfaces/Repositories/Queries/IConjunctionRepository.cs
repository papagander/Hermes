using System;
using DataAccess.EFCore.Interfaces.Repositories.Generic;

namespace DataAccess.EFCore.Interfaces.Repositories.Queries
{
    public interface IConjunctionRepository : IIndexedRepository<Conjunction>, IReferencedByRepository<Conjunction, Statement>
    {
    }
}

