using Domain.Models.DataCore;
using Domain.Models.FieldSets;
using Domain.Models.Queries;

namespace DataAccess.EFCore.Interfaces.Repositories.Queries;
public interface ICriterionRepository
    : IIndexedRepository<Criterion>
    , IReferencedByRepository<Criterion, CriterionValue>
    , IReferencesRepository<Criterion, Field>
    , IReferencesRepository<Criterion, Operator>
{ }

