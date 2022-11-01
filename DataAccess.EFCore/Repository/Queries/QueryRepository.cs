using DataAccess.EFCore.Interfaces.Repositories.Queries;

using Domain.Models.FieldSets;
using Domain.Models.Queries;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repository.Queries
{
    public class QueryRepository : UniquelyNamedRepository<Query>, IQueryRepository
    {
        ReferencedByRepository<Query, Field> f;
        ReferencesRepository<Query, FieldSet> ds;
        public QueryRepository(ReportContext _context) : base(_context)
        {
            f = new ReferencedByRepository<Query, Field>(_context);
            ds = new ReferencesRepository<Query, FieldSet>(_context);
        }

        public void AddChildren(Query tRef, IEnumerable<Field> Children) => f.AddChildren(tRef, Children);

        public IEnumerable<Field> GetChildren(Query MyT) => f.GetChildren(MyT);

        public IEnumerable<Query> GetRange(FieldSet MyTRef) => ds.GetRange(MyTRef);

        public void RemoveChildren(Query tRef, IEnumerable<Field> Children) => f.RemoveChildren(tRef, Children);

        public void SetStatement(Query query, Statement statement)
        {
            throw new NotImplementedException();
        }

        void IReferencedByRepository<Query, Field>.SetChildren(Query tRef, IEnumerable<Field> Children) => f.RemoveChildren(tRef, Children);
    }
}
