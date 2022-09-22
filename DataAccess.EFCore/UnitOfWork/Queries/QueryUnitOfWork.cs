using System;
using System.Xml.Serialization;
using DataAccess.EFCore.Interfaces.Repositories;
using DataAccess.EFCore.Interfaces.Repositories.DataCore;
using DataAccess.EFCore.Interfaces.Repositories.DataSets;
using DataAccess.EFCore.Interfaces.Repositories.Queries;
using DataAccess.EFCore.Repository;
using DataAccess.EFCore.Repository.DataCore;
using DataAccess.EFCore.Repository.DataSets;
using DataAccess.EFCore.Repository.Queries;
using Domain.Models.DataCore;

namespace DataAccess.EFCore.UnitOfWork
{
    public class QueryUnitOfWork : GenericUnitOfWork, IQueryUnitOfWork
    {



        public ICrdRepository<Query> Queries { get; private set; }
        public IStatementRepository Statements { get; private set; }
        public IConjunctionRepository Conjunctions { get; private set; }
        public ICriterionRepository Criteria { get; private set; }
        public ICrdRepository<CriterionValue> CriterionValues { get; private set; }
        public IQueryFieldRepository QueryFields { get; private set; }


        public QueryUnitOfWork(ReportContext reportContext) : base(reportContext)
        {

            Queries = new CrdRepository<Query>(reportContext);
            Statements = new StatementRepository(reportContext);
            Conjunctions = new ConjunctionRepository(reportContext);
            Criteria = new CriterionRepository(reportContext);
            CriterionValues = new CrdRepository<CriterionValue>(reportContext);
            QueryFields = new QueryFieldRepository(reportContext);
        }
    }
}
