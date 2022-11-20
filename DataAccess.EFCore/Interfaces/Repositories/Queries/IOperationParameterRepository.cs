using Domain.Models.Queries;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Interfaces.Repositories.Queries;
public interface IOperationParameterRepository
    : IIndexedRepository<OperationParameter>
    , IReferencesRepository<OperationParameter, Operation>
    , IReferencesRepository<OperationParameter, Parameter>
{ }
