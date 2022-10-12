using DataAccess.EFCore.Interfaces.Repositories.DataCore;
using DataAccess.EFCore.Repository.DataCore;

using Domain.Models.DataCore;

using System;
namespace DataAccess.EFCore.Interfaces.UnitsOfWork.DataCore
{
    public interface IDataCoreUnitOfWork : IUnitOfWork
    {

        IOperatorRepository Operators { get; }
        IConjoinerRepository Conjoiners { get; }
    }
}

