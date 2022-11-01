using Domain.Models.Queries;
using Domain.Models.FieldSets;

using System;
using DataAccess.EFCore.Interfaces.Repositories.Queries;

namespace DataAccess.EFCore.Repository.Queries;
public class CriterionRepository 
    : ReferencedByRepository<Criterion, CriterionParameter>
    , ICriterionRepository
{
    ReferencesRepository<Criterion, Operator> RefOp;
    ReferencesRepository<Criterion, Field> RefF;
    public CriterionRepository(ReportContext reportContext) : base(reportContext)
    {
        RefOp = new ReferencesRepository<Criterion, Operator>(hContext);
        RefF = new ReferencesRepository<Criterion, Field>(hContext);
    }
    public IEnumerable<Criterion> GetRange(Field MyTRef) => RefF.GetRange(MyTRef);
    public IEnumerable<Criterion> GetRange(Operator MyTRef) => RefOp.GetRange(MyTRef);
}

