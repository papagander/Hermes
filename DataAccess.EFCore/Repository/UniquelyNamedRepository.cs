using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repository
{
    public class UniquelyNamedRepository<T> 
        : IndexedRepository<T>
        , IUniquelyNamedRepository<T> 
        where T 
            : class
            , INamed
            , new()
    {
        // need to not allow insert if name exists
        public UniquelyNamedRepository(ReportContext _context) : base(_context) { }
        public T? Get(string name)
        {
            var output = (from myT in hContext.Set<T>() where myT.Name == name select myT);
            if (output == null | output.Count() == 0) return null;
            else if (output.Count() > 1) throw new InvalidDataException($"{output.Count()} entities w name {name}");
            else return output.First();
        }
        public override void Add(T entity)
        {
            if (NameIsAvailable(entity.Name)) base.Add(entity);
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
            hContext.Set<T>().Remove(MyT);
        }

        public void RemoveRange(IEnumerable<string> Names)
        {
            IEnumerable<T> Ts = GetRange(Names);
            hContext.Set<T>().RemoveRange(Ts);
        }
        public bool NameIsAvailable(string name)
        {
            return Get(name) == null;
        }
        protected void AddNameOnly(string name)
        {
            if (NameIsAvailable(name))
                hContext.Set<T>().Add(new T { Name = name });
        }
    }
}
