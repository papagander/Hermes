using DataAccess.EFCore.Interfaces.Repositories.DataSets;

using Domain.Models.DataSets;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repository.DataSets
{
    public class DataSetRepository : NamedRepository<DataSet>, IDatasetRepository
    {
        private ReferencedByRepository<DataSet, Field> f;
        public DataSetRepository(ReportContext _context) : base(_context)
        {
            f = new ReferencedByRepository<DataSet, Field>(_context);
        }

        public void AddChildren(DataSet tRef, IEnumerable<Field> Children) => f.AddChildren(tRef, Children);

        public IEnumerable<Field> GetChildren(DataSet MyT) => f.GetChildren(MyT);

        public IEnumerable<Field> GetFields(DataSet dt) => f.GetChildren(dt);

        public void RemoveChildren(DataSet tRef, IEnumerable<Field> Children) => f.RemoveChildren(tRef, Children);

        public void SetChildren(DataSet tRef, IEnumerable<Field> Children) => f.SetChildren(tRef, Children);
    }
}
