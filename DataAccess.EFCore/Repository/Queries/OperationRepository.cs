using Domain.Models.Queries;
using Domain.Models.FieldSets;

using System;
using DataAccess.EFCore.Interfaces.Repositories.Queries;

namespace DataAccess.EFCore.Repository.Queries;
public class OperationRepository 
    : ReferencedByRepository<Operation, OperationParameter>
    , IOperationRepository
{
    ReferencesRepository<Operation, Operator> RefOp;
    ReferencesRepository<Operation, Field> RefF;
    public OperationRepository(ReportContext reportContext) : base(reportContext)
    {
        RefOp = new ReferencesRepository<Operation, Operator>(hContext);
        RefF = new ReferencesRepository<Operation, Field>(hContext);
    }
    public IEnumerable<Operation> GetRange(Field MyTRef) => RefF.GetRange(MyTRef);
    public IEnumerable<Operation> GetRange(Operator MyTRef) => RefOp.GetRange(MyTRef);
}

