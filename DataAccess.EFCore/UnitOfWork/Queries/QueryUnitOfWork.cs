using System;
using System.Xml.Serialization;
using DataAccess.EFCore.Interfaces.Repositories.DataCore;
using DataAccess.EFCore.Interfaces.Repositories.FieldSets;
using DataAccess.EFCore.Interfaces.Repositories.Queries;
using DataAccess.EFCore.Repository;
using DataAccess.EFCore.Repository.DataCore;
using DataAccess.EFCore.Repository.FieldSets;
using DataAccess.EFCore.Repository.Queries;
using Domain.Models.DataCore;
using Domain.Models.FieldSets;

namespace DataAccess.EFCore.UnitOfWork
{
    public class QueryUnitOfWork : GenericUnitOfWork, IQueryUnitOfWork
    {
        public IQueryRepository Queries { get; private set; }
        public IStatementRepository Statements { get; private set; }
        public IConjunctionRepository Conjunctions { get; private set; }
        public ICriterionRepository Criteria { get; private set; }
        public ICriterionValueRepository CriterionValues { get; private set; }
        public IReadRepository<FieldSet> FieldSets { get; private set; }

        public QueryUnitOfWork(ReportContext reportContext) : base(reportContext)
        {

            Queries = new QueryRepository(_context);
            Statements = new StatementRepository(_context);
            Conjunctions = new ConjunctionRepository(_context);
            Criteria = new CriterionRepository(_context);
            CriterionValues = new CriterionValueRepository(_context);
            FieldSets = new ReadRepository<FieldSet>(_context);
        }
    }
}
