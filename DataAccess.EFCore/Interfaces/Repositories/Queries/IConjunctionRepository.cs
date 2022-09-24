using System;

namespace DataAccess.EFCore.Interfaces.Repositories.Queries
{
    public interface IConjunctionRepository : 
        IIndexedRepository<Conjunction>
        , IReferencedByRepository<Conjunction, Statement>
    {}
}

