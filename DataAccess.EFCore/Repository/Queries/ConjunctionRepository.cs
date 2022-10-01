using DataAccess.EFCore.Interfaces.Repositories.Queries;

using Domain.Models.Queries;

using System;

namespace DataAccess.EFCore.Repository.Queries
{
    public class ConjunctionRepository : IndexedRepository<Conjunction> , IConjunctionRepository
    {
        public ReferencedByRepository<Conjunction, Statement> s;
        public ConjunctionRepository(ReportContext reportContext) : base(reportContext)
        {
            s = new ReferencedByRepository<Conjunction, Statement>(reportContext);
        }

        public void AddChildren(Conjunction tRef, IEnumerable<Statement> Children) => s.AddChildren(tRef, Children);

        public IEnumerable<Statement> GetChildren(Conjunction MyT) => s.GetChildren(MyT);

        public void RemoveChildren(Conjunction tRef, IEnumerable<Statement> Children) => s.RemoveChildren(tRef, Children);

        public void SetChildren(Conjunction tRef, IEnumerable<Statement> Children) => s.SetChildren(tRef, Children);
    }
}

