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

        public void AddChildren(TRef tRef, IEnumerable<T> Children)
        {
            if (tRef.MyTs is null)  SetChildren(tRef, Children);
            else tRef.MyTs.AddRange(Children);
        }

        public IEnumerable<T> GetChildren(TRef tRef) => tRef.MyTs;


        public void RemoveChildren(TRef tRef, IEnumerable<T> Children)
        {
            foreach (var child in Children)
                if (tRef.MyTs.Contains(child))
                    tRef.MyTs.Remove(child);
        }

        public void SetChildren(TRef tRef, IEnumerable<T> Children) => tRef.MyTs = Children.ToList();
    }
}