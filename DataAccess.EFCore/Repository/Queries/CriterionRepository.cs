using Domain.Models.Queries;
using Domain.Models.FieldSets;

using System;
using DataAccess.EFCore.Interfaces.Repositories.Queries;

namespace DataAccess.EFCore.Repository.Queries
{
    public class CriterionRepository : ReferencedByRepository<Criterion, CriterionValue>, ICriterionRepository
    {
        ReferencesRepository<Criterion, Operator> RefOp;
        ReferencesRepository<Criterion, Field> RefF;
        public CriterionRepository(ReportContext reportContext) : base(reportContext)
        {
            RefOp = new ReferencesRepository<Criterion, Operator>(context);
            RefF = new ReferencesRepository<Criterion, Field>(context);
        }
        public IEnumerable<Criterion> GetRange(Field MyTRef) => RefF.GetRange(MyTRef);

        public IEnumerable<Criterion> GetRange(Operator MyTRef) => RefOp.GetRange(MyTRef);


    }
}

