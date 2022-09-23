using DataAccess.EFCore.Interfaces.Repositories.DataSets;
using DataAccess.EFCore.Interfaces.UnitsOfWork.DataSets;
using DataAccess.EFCore.Repository.DataSets;
using DataAccess.EFCore.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.EFCore.Interfaces.Repositories.Generic;

namespace DataAccess.EFCore.UnitOfWork.DataSets
{
    public class DataSetUnitOfWork : GenericUnitOfWork, IDataSetUnitOfWork
    {
        public ICrdRepository<DataSet> DataSets { get; private set; }
        public IFieldRepository Fields { get; private set; }
        public DataSetUnitOfWork(ReportContext reportContext) : base(reportContext)
        {
            DataSets = new CrdRepository<DataSet>(reportContext);
            Fields = new FieldRepository(reportContext);
        }
    }
}
