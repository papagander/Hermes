using DataAccess.EFCore.Interfaces.Repositories.DataCore;
using DataAccess.EFCore.Interfaces.UnitsOfWork.DataCore;
using DataAccess.EFCore.Repository.DataCore;
using DataAccess.EFCore.Repository;

using Domain.Models.DataCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.EFCore.Interfaces.UnitsOfWork;

namespace DataAccess.EFCore.UnitOfWork.DataCore
{
    public class DataCoreUnitOfWork : GenericUnitOfWork, IDataCoreUnitOfWork
    {
        public IFieldTypeRepository  FieldTypes { get; private set; }
        public IOperatorRepository Operators { get; private set; }
        public IConjoinerRepository Conjoiners { get; private set; }
        public DataCoreUnitOfWork(ReportContext reportContext) : base(reportContext)
        {

            FieldTypes = new FieldTypeRepository(reportContext);
            Operators = new OperatorRepository(reportContext);
            Conjoiners = new ConjoinerRepository(reportContext);
        }

    }
}
