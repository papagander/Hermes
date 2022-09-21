using System;
using DataAccess.EFCore.Interfaces.Repositories.Reports;
using DataAccess.EFCore.Interfaces.Repositories;
namespace DataAccess.EFCore.Interfaces
{
    public interface IReportUnitOfWork
    {
        ICrdRepository<Report> Reports { get; }

        ICrdRepository<Template> Templates { get; }
        ICrdRepository<FieldType> FieldTypes { get; }
        ICrdRepository<Operator> Operators { get; }

        ICrdRepository<Conjoiner> Conjoiners { get; }
        ICrdRepository<CriterionValue> CriterionsValues { get; }

        IReportFieldRepository ReportFields {get; }

        IConjunctionRepository Conjunctions { get; }
        ICriterionRepository Criteria { get; }
        IStatementRepository Statements { get; }

        IFieldRepository Fields { get; }
        IFieldTypeOperatorRepository FieldTypeOperators { get; }


    }
}

