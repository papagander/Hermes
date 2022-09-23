using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.EFCore.Interfaces.Repositories.Generic;

namespace DataAccess.EFCore.Repository
{
    internal class NamedRepository<T> : IndexedRepository<T>, INamedRepository<T> where T : class, INamed
    {
        public NamedRepository(ReportContext _context) : base(_context) { }
        public T Get(string Name)
        {
            return (from myT in _context.Set<T>() where myT.Name == Name select myT).ElementAt(0);

        }

        public IEnumerable<T> GetRange(IEnumerable<string> names)
        {
            List<T> Ts = new List<T>();
            foreach (var name in names)
            {
                Ts.Add(Get(name));
            }
            return Ts;
        }

        public void Remove(string Name)
        {
            T MyT = Get(Name);
            _context.Set<T>().Remove(MyT);
        }

        public void RemoveRange(IEnumerable<string> Names)
        {
            IEnumerable<T> Ts = GetRange(Names);
            _context.Set<T>().RemoveRange(Ts);
        }

        public void Rename(string OldName, string NewName)
        {
            throw new NotImplementedException();
        }
    }
}
