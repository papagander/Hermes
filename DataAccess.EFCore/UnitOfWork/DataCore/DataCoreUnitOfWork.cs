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

namespace DataAccess.EFCore.UnitOfWork.DataCore
{
    public class DataCoreUnitOfWork : GenericUnitOfWork, IDataCoreUnitOfWork
    {
        public ICrdRepository<FieldType> FieldTypes { get; private set; }
        public ICrdRepository<Operator> Operators { get; private set; }
        public IFieldTypeOperatorRepository FieldTypeOperators { get; private set; }
        public ICrdRepository<Conjoiner> Conjoiners { get; private set; }
        public DataCoreUnitOfWork(ReportContext reportContext) : base(reportContext)
        {

            FieldTypes = new CrdRepository<FieldType>(reportContext);
            Operators = new CrdRepository<Operator>(reportContext);
            FieldTypeOperators = new FieldTypeOperatorRepository(reportContext);
            Conjoiners = new CrdRepository<Conjoiner>(reportContext);
        }
    }
}
