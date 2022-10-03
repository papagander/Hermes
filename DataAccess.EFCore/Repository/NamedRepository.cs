using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repository
{
    public class NamedRepository<T> : IndexedRepository<T>, INamedRepository<T> where T : class, INamed
    {
        // need to not allow insert if name exists
        public NamedRepository(ReportContext _context) : base(_context) { }
        public T? Get(string name)
        {
            var ns  = (from myT in context.Set<T>() where myT.Name == name select myT);
            if (ns == null | ns.Count() == 0) return null;
            else if (ns.Count() > 1) throw new InvalidDataException($"{ns.Count()} entities w name {name}");
        }
        public override void Add(T entity)
        {
            var t = Get(entity.Name);
            if (t is null) base.Add(entity);
            else throw new InvalidDataException($"Cannot insert {entity.Name}: name must be unique.");
        }
        public IEnumerable<T> GetRange(IEnumerable<string> names)
        {
            List<T> Ts = new List<T>();
            foreach (var name in names)
            {
                var n = Get(name);
                if (n != null) Ts.Add(n);
            }
            return Ts;
        }

        public void Remove(string Name)
        {
            T MyT = Get(Name);
            context.Set<T>().Remove(MyT);
        }

        public void RemoveRange(IEnumerable<string> Names)
        {
            IEnumerable<T> Ts = GetRange(Names);
            context.Set<T>().RemoveRange(Ts);
        }

        public void Rename(string OldName, string NewName)
        {
            throw new NotImplementedException();
        }
    }
}
