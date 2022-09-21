using System;
using System.Xml.Serialization;
using DataAccess.EFCore.Interfaces.Repositories;
using DataAccess.EFCore.Interfaces.Repositories.Reports;
using DataAccess.EFCore.Repository;
using DataAccess.EFCore.Repository.Reports;

namespace DataAccess.EFCore.UnitOfWork
{
    public class ReportUnitOfWork : IReportUnitOfWork
    {
        private readonly ReportContext _context;
        public ICrdRepository<Query> Reports { get; private set; }

        public ICrdRepository<DataSet> DataSets { get; private set; }
        public ICrdRepository<FieldType> FieldTypes { get; private set; }
        public ICrdRepository<Operator> Operators { get; private set; }

        public ICrdRepository<Conjoiner> Conjoiners { get; private set; }
        public ICrdRepository<CriterionValue> CriterionValues { get; private set; }

        public IConjunctionRepository Conjunctions { get; private set; }
        public ICriterionRepository Criteria { get; private set; }
        public IStatementRepository Statements { get; private set; }

        public IFieldRepository Fields { get; private set; }
        public IReportFieldRepository ReportFields { get; private set; }
        public IFieldTypeOperatorRepository FieldTypeOperators { get; private set; }

        public ReportUnitOfWork(ReportContext reportContext, ICrdRepository<Query> reports, ICrdRepository<DataSet> templates, ICrdRepository<FieldType> fieldTypes, ICrdRepository<Operator> operators, ICrdRepository<Conjoiner> conjoiners, ICrdRepository<CriterionValue> criterionValues, IConjunctionRepository conjunctions, ICriterionRepository criteria, IStatementRepository statements, IFieldRepository fields, IReportFieldRepository reportFields, IFieldTypeOperatorRepository fieldTypeOperators) : this(context)
        {
            _context = reportContext;
            Reports = new CrdRepository<Query>(reportContext);
            Templates = new CrdRepository<DataSet>(reportContext);
            FieldTypes = new CrdRepository<FieldType>(reportContext);
            Operators = new CrdRepository<Operator>(reportContext);
            Conjoiners = new CrdRepository<Conjoiner>(reportContext);
            CriterionValues = new CrdRepository<CriterionValue>(reportContext);
            Conjunctions = new ConjunctionRepository(reportContext);
            Criteria = new CriterionRepository(reportContext);
            Statements = new StatementRepository(reportContext);
            Fields = new FieldRepository(reportContext);
            ReportFields = new ReportFieldRepository(reportContext);
            FieldTypeOperators = new FieldTypeOperatorRepository(reportContext);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
