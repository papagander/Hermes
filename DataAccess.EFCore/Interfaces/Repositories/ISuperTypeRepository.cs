using Domain.Interfaces.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Interfaces.Repositories
{
    public interface ISuperTypeRepository<T, TSub> : IIndexedRepository<T> where T : class, IIndexed where TSub : class, ISubTypeOf<T>
    {
        public ISubTypeOf<T> GetChild(T MyT);
    }
}
