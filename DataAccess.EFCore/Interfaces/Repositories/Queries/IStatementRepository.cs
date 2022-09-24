using System;

namespace DataAccess.EFCore.Interfaces;

public interface IStatementRepository :
    IReferencesRepository<Statement, Conjunction>
    , ISuperTypeRepository<Statement, Conjunction>
    , ISuperTypeRepository<Statement, Criterion>
{ }


