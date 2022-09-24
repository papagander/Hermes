using DataAccess.EFCore.Interfaces.Repositories.DataSets;
using DataAccess.EFCore.Interfaces.UnitsOfWork.DataSets;
using DataAccess.EFCore.Repository.DataSets;
using DataAccess.EFCore.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.UnitOfWork.DataSets
{
    public class DataSetUnitOfWork : GenericUnitOfWork, IDataSetUnitOfWork
    {
        public IDatasetRepository DataSets { get; private set; }
        public IFieldRepository Fields { get; private set; }
        public DataSetUnitOfWork(ReportContext reportContext) : base(reportContext)
        {
            DataSets = new DataSetRepository(reportContext);
            Fields = new FieldRepository(reportContext);
        }
    }
}
