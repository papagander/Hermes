global using DataAccess.EFCore.Interfaces.Repositories;

using Domain.Models.Queries;

using System;

namespace DataAccess.EFCore.Interfaces;

public interface IStatementRepository :
    IReferencesRepository<Statement, Conjunction>
    , ISuperTypeRepository<Statement, Conjunction>
    , ISuperTypeRepository<Statement, Criterion>
{ }


