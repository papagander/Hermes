using Domain.Models.DataCore;
using Domain.Models.FieldSets;
using Domain.Models.Queries;

namespace DataAccess.EFCore.Interfaces.Repositories.Queries;
public interface IOperationRepository
    : IIndexedRepository<Operation>
    , IReferencedByRepository<Operation, OperationParameter>
    , IReferencesRepository<Operation, Field>
    , IReferencesRepository<Operation, Operator>
{ }

