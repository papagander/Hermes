using Domain.Interfaces.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Interfaces.Repositories
{
    public interface IReferencesRepository<T, T1> : IIndexedRepository<T> where T : IReferences<T1> where T1 : IIndexed
    {
        IEnumerable<T> GetByParent(T MyT);
        IEnumerable<T> GetByParent(int TDex);
    }
}
