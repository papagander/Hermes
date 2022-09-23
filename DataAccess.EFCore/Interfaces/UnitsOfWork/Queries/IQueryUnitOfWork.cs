using System;
using DataAccess.EFCore.Interfaces.Repositories.Queries;
using Domain.Models.DataCore;
using DataAccess.EFCore.Interfaces.Repositories.Generic;

namespace DataAccess.EFCore.Interfaces
{
    public interface IQueryUnitOfWork
    {
        ICrdRepository<Query> Queries { get; }
        IStatementRepository Statements { get; }
        IConjunctionRepository Conjunctions { get; }
        ICriterionRepository Criteria { get; }
        ICrdRepository<CriterionValue> CriterionValues { get; }
        IQueryFieldRepository QueryFields {get; }

        int Complete();

    }
}

