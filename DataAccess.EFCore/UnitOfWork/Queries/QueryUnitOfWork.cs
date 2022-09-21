using System;
using System.Xml.Serialization;
using DataAccess.EFCore.Interfaces.Repositories;
using DataAccess.EFCore.Interfaces.Repositories.Reports;
using DataAccess.EFCore.Repository;
using DataAccess.EFCore.Repository.Reports;
using Domain.Models.DataCore;

namespace DataAccess.EFCore.UnitOfWork
{
    public class QueryUnitOfWork : GenericUnitOfWork, IQueryUnitOfWork
    {

        public ICrdRepository<DataSet> DataSets { get; private set; }
        public IFieldRepository Fields { get; private set; }

        public ICrdRepository<FieldType> FieldTypes { get; private set; }
        public ICrdRepository<Operator> Operators { get; private set; }
        public IFieldTypeOperatorRepository FieldTypeOperators { get; private set; }
        public ICrdRepository<Conjoiner> Conjoiners { get; private set; }


        public ICrdRepository<Query> Queries { get; private set; }
        public IStatementRepository Statements { get; private set; }
        public IConjunctionRepository Conjunctions { get; private set; }
        public ICriterionRepository Criteria { get; private set; }
        public ICrdRepository<CriterionValue> CriterionValues { get; private set; }
        public IQueryFieldRepository QueryFields { get; private set; }


        public QueryUnitOfWork(ReportContext reportContext) : base(reportContext)
        {
            DataSets = new CrdRepository<DataSet>(reportContext);
            Fields = new FieldRepository(reportContext);

            FieldTypes = new CrdRepository<FieldType>(reportContext);
            Operators = new CrdRepository<Operator>(reportContext);
            FieldTypeOperators = new FieldTypeOperatorRepository(reportContext);
            Conjoiners = new CrdRepository<Conjoiner>(reportContext);

            Queries = new CrdRepository<Query>(reportContext);
            Statements = new StatementRepository(reportContext);
            Conjunctions = new ConjunctionRepository(reportContext);
            Criteria = new CriterionRepository(reportContext);
            CriterionValues = new CrdRepository<CriterionValue>(reportContext);
            QueryFields = new QueryFieldRepository(reportContext);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
