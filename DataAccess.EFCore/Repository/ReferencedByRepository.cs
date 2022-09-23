using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repository
{
    internal class ReferencedByRepository<TRef, T> : IndexedRepository<TRef>, IReferencedByRepository<TRef, T>
        where T : class, IReferences<TRef> where TRef : class, IReferencedBy<T>
    {
        public ReferencedByRepository(ReportContext _context) : base(_context) { }
        public IEnumerable<T> GetChildren(TRef MyTRef)
         => (from MyT in _context.Set<T>() where MyT.MyTRefId == MyTRef.Id select MyT);

        /*public IEnumerable<T> GetChildren(int MyTRefId)
         => (from MyT in _context.Set<T>() where MyT.MyTRefId == MyTRefId select MyT);*/
    }
}
