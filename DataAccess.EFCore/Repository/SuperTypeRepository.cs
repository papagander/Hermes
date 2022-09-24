using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repository
{
    internal class SuperTypeRepository<T, TSub> : 
        IndexedRepository<T>
        , ISuperTypeRepository<T, TSub>
        where TSub : class, ISubTypeOf<T>
        where T : class, ISuperTypeOf<TSub>
    {
        public SuperTypeRepository(ReportContext _context) : base(_context) { }

        public ISubTypeOf<T>? GetChild(T MyT)
        {
            return MyT.MySub;
        }
    }
}
