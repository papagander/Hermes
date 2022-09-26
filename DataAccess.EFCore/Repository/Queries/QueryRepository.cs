using Domain.Models.DataSets;
using Domain.Models.Queries;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repository.Queries
{
    public class QueryRepository : NamedRepository<Query>, IQueryRepository
    {
        ReferencedByRepository<Query, Field> RefF;
        ReferencesRepository<Query, DataSet> RefDS;
        public QueryRepository(ReportContext _context) : base(_context)
        {
            RefF = new ReferencedByRepository<Query, Field>(_context);
            RefDS = new ReferencesRepository<Query, DataSet>(_context);
        }

        public IEnumerable<Field> GetChildren(Query MyT) => RefF.GetChildren(MyT);

        public IEnumerable<Query> GetRange(DataSet MyTRef) => RefDS.GetRange(MyTRef);
    }
}
