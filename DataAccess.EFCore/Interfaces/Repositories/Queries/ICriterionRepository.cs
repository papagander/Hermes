using DataAccess.EFCore.Interfaces.Repositories.Generic;

namespace DataAccess.EFCore.Interfaces.Repositories.Queries
{
    public interface ICriterionRepository : IIndexedRepository<Criterion> 
        , IReferencedByRepository<Criterion, CriterionValue>
        , IReferencesRepository<Criterion, Field>
        , IReferencesRepository<Criterion, Operator>
    { 
    }
}

