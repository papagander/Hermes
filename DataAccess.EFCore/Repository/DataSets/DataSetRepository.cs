using DataAccess.EFCore.Interfaces.Repositories.DataSets;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repository.DataSets
{
    public class DataSetRepository : NamedRepository<DataSet>, IDatasetRepository
    {
        private ReferencedByRepository<DataSet, Field> RefF;
        public DataSetRepository(ReportContext _context) : base(_context)
        {
            RefF = new ReferencedByRepository<DataSet, Field>(_context);
        }

        public IEnumerable<Field> GetChildren(DataSet MyT) => RefF.GetChildren(MyT);
    }
}
