using DataAccess.EFCore.Interfaces.Repositories.FieldSets;
using DataAccess.EFCore.Interfaces.UnitsOfWork.FieldSets;
using DataAccess.EFCore.Repository.FieldSets;
using DataAccess.EFCore.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.UnitOfWork.FieldSets;

public class FieldSetUnitOfWork : GenericUnitOfWork, IFieldSetUnitOfWork
{
    public IFieldSetRepository FieldSets { get; private set; }
    public IFieldRepository Fields { get; private set; }
    public IReadRepository<FieldType> FieldTypes { get; private set; }

    public FieldSetUnitOfWork(ReportContext reportContext) : base(reportContext)
    {
        FieldSets = new FieldSetRepository(reportContext);
        Fields = new FieldRepository(reportContext);
        FieldTypes = new ReadRepository<FieldType>(reportContext);
    }
}
