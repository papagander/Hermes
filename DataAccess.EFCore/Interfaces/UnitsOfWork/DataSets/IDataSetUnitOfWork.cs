using DataAccess.EFCore.Interfaces.Repositories.DataSets;

using System;
namespace DataAccess.EFCore.Interfaces.UnitsOfWork.DataSets
{
    public interface IDataSetUnitOfWork
    {

        ICrdRepository<DataSet> DataSets { get; }
        IFieldRepository Fields { get; }
        int Complete();
    }
}

