using DataAccess.EFCore.Interfaces.Repositories.Queries;

using Domain.Models.FieldSets;
using Domain.Models.Queries;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public override Query? Get(int id)
        {
            Query? output;
            output = context.Query.First(x => x.Id == id);
            return LoadQueryWithStatement(output);
        }

        private Query LoadQueryWithStatement(Query query)
        {
            context.Entry(query)
                            .Reference(x => x.Statement)
                            .Load();
            LoadConjunctions(query.Statement);
            return query;
        }
        private Statement LoadConjunctions(Statement stat)
        {
            context.Entry(stat)
                .Collection(x => x.conjunctions)
                .Load();
            if (stat.Conjunction is null) return stat;
            foreach (var st in stat.Conjunction.Statements)
            {
                LoadConjunctions(st);
            }
            return stat;
        }
        public override Query? Get(string name) => LoadQueryWithStatement(base.Get(name));
        public override IEnumerable<Query> GetAll()
        {
            var qs = base.GetAll();
            List<Query> output = new();
            foreach (var q in qs)
            {
                var _q = LoadQueryWithStatement(q);
                output.Add(_q);
            }
            return output;
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
