global using Domain.Interfaces.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Interfaces.Repositories.Generic
{
    public interface IReferencedByRepository<TRef, T> : IIndexedRepository<TRef> where TRef : IReferencedBy<T> where T : IIndexed
    {
        IEnumerable<T> GetChildren(TRef MyT);
        IEnumerable<T> GetChildren(int TDex);
    }
}
