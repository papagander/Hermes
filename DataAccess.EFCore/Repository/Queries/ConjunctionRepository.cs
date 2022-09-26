using Domain.Models.Queries;

using System;

namespace DataAccess.EFCore.Repository.Queries
{
    public class ConjunctionRepository : IndexedRepository<Conjunction> , IConjunctionRepository
    {
        public ReferencedByRepository<Conjunction, Statement> RefS;
        public ConjunctionRepository(ReportContext reportContext) : base(reportContext)
        {
            RefS = new ReferencedByRepository<Conjunction, Statement>(reportContext);
        }

        public IEnumerable<Statement> GetChildren(Conjunction MyT) => RefS.GetChildren(MyT);
        /*
public string ToString(int conjunctionId)
{
   Conjunction conjunction = GetById(conjunctionId);
   foreach (var statement in conjunction.Statements)
   {

   }
}
*/
    }
}

