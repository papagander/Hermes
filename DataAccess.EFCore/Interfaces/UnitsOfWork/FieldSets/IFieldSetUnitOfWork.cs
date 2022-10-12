using DataAccess.EFCore.Interfaces.Repositories.FieldSets;
using System;
namespace DataAccess.EFCore.Interfaces.UnitsOfWork.FieldSets;

public interface IFieldSetUnitOfWork : IUnitOfWork
{

    IFieldSetRepository FieldSets { get; }
    IFieldRepository Fields { get; }
}

