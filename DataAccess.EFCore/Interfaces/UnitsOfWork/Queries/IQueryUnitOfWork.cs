using System;
using DataAccess.EFCore.Interfaces.Repositories.Queries;
using DataAccess.EFCore.Interfaces.UnitsOfWork;

using Domain.Models.DataCore;
using Domain.Models.FieldSets;

namespace DataAccess.EFCore.Interfaces
{
    public interface IQueryUnitOfWork : IUnitOfWork
    {
        IQueryRepository Queries { get; }
        IStatementRepository Statements { get; }
        IConjunctionRepository Conjunctions { get; }
        IOperationRepository Operations { get; }
        IOperationParameterRepository OperationParameters { get; }
        IReadRepository<Operator> Operators { get; }
        IReadRepository<FieldSet> FieldSets { get; }
        IReadRepository<Conjoiner> Conjoiners { get; }
    }
}

