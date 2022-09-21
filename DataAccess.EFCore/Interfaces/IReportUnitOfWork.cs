using System;
using DataAccess.EFCore.Interfaces.Repositories.Reports;
using DataAccess.EFCore.Interfaces.Repositories;
namespace DataAccess.EFCore.Interfaces
{
    public interface IReportUnitOfWork
    {
        ICrdRepository<Query> Reports { get; }

        ICrdRepository<DataSet> Templates { get; }
        ICrdRepository<FieldType> FieldTypes { get; }
        ICrdRepository<Operator> Operators { get; }

        ICrdRepository<Conjoiner> Conjoiners { get; }
        ICrdRepository<CriterionValue> CriterionValues { get; }


        IConjunctionRepository Conjunctions { get; }
        ICriterionRepository Criteria { get; }
        IStatementRepository Statements { get; }

        IFieldRepository Fields { get; }
        IReportFieldRepository ReportFields {get; }
        IFieldTypeOperatorRepository FieldTypeOperators { get; }

        int Complete();


    }
}

