using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repository
{
    public class ReferencedByRepository<TRef, T> : IndexedRepository<TRef>, IReferencedByRepository<TRef, T>
        where T : class, IIndexed where TRef : class, IReferencedBy<T>
    {
        public ReferencedByRepository(ReportContext _context) : base(_context) { }
        public IEnumerable<T> GetChildren(TRef MyTRef)
        {
            return MyTRef.MyTs;
        }

        /*public IEnumerable<T> GetChildren(int MyTRefId)
         => (from MyT in _context.Set<T>() where MyT.MyTRefId == MyTRefId select MyT);*/
    }
}
