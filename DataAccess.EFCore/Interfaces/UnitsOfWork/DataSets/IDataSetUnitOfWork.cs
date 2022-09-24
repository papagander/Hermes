using DataAccess.EFCore.Interfaces.Repositories.DataSets;
using System;
namespace DataAccess.EFCore.Interfaces.UnitsOfWork.DataSets
{
    public interface IDataSetUnitOfWork : IUnitOfWork
    {

        IDatasetRepository DataSets { get; }
        IFieldRepository Fields { get; }
    }
}

