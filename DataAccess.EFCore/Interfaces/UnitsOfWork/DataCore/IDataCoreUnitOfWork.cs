using DataAccess.EFCore.Interfaces.Repositories.DataCore;
using Domain.Models.DataCore;

using System;
namespace DataAccess.EFCore.Interfaces.UnitsOfWork.DataCore
{
    public interface IDataCoreUnitOfWork
    {

        ICrdRepository<FieldType> FieldTypes { get; }
        ICrdRepository<Operator> Operators { get; }
        IFieldTypeOperatorRepository FieldTypeOperators { get; }
        ICrdRepository<Conjoiner> Conjoiners { get; }
        int Complete();
    }
}

