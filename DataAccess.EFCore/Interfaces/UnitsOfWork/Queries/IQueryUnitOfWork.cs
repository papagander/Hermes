using System;
using DataAccess.EFCore.Interfaces.Repositories.Reports;
using DataAccess.EFCore.Interfaces.Repositories;
using Domain.Models.DataCore;

namespace DataAccess.EFCore.Interfaces
{
    public interface IQueryUnitOfWork
    {
        ICrdRepository<DataSet> DataSets { get; }
        IFieldRepository Fields { get; }


        ICrdRepository<FieldType> FieldTypes { get; }
        ICrdRepository<Operator> Operators { get; }
        IFieldTypeOperatorRepository FieldTypeOperators { get; }
        ICrdRepository<Conjoiner> Conjoiners { get; }

        ICrdRepository<Query> Queries { get; }
        IStatementRepository Statements { get; }
        IConjunctionRepository Conjunctions { get; }
        ICriterionRepository Criteria { get; }
        ICrdRepository<CriterionValue> CriterionValues { get; }
        IQueryFieldRepository QueryFields {get; }

        int Complete();

    }
}

