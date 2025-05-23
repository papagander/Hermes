﻿
using Domain.Models.Queries;

using System;

namespace DataAccess.EFCore.Repository.Queries
{
    public class StatementRepository : IndexedRepository<Statement>, IStatementRepository
    {
        SuperTypeRepository<Statement, Operation> SupCr;
        SuperTypeRepository<Statement, Conjunction> SupCj;
        ReferencesRepository<Statement, Conjunction> RefCj;
        public StatementRepository(ReportContext reportContext) : base(reportContext)
        {
            SupCr = new SuperTypeRepository<Statement, Operation>(context);
            SupCj = new SuperTypeRepository<Statement, Conjunction>(context);
            RefCj = new ReferencesRepository<Statement, Conjunction>(context);
        }

        public ISubTypeOf<Statement> GetChild(Statement MyT)
        {
            ISubTypeOf<Statement>? subTypeOfStatement = SupCr.GetChild(MyT);
            if (subTypeOfStatement is not null) return subTypeOfStatement;

            subTypeOfStatement = SupCj.GetChild(MyT);
            if (subTypeOfStatement is not null) return subTypeOfStatement;

            throw new NullReferenceException("Statement does not have a sub - entity.");
        }

        public IEnumerable<Statement> GetRange(Conjunction MyTRef) => RefCj.GetRange(MyTRef);
        /*
public IEnumerable<Statement> GetRangeByConjunctionId(int conjunctionId)
{
   return (from statement in context.Statement where statement.Id == conjunctionId select statement);
}
*/
    }
}

