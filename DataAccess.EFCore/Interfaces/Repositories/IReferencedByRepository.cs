global using Domain.Interfaces.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Interfaces.Repositories
{
    public interface IReferencedByRepository<TRef, T> : IIndexedRepository<TRef> where TRef : IReferencedBy<T> where T : IIndexed
    {
        IEnumerable<T> GetChildren(TRef tRef);
        void SetChildren(TRef tRef, IEnumerable<T> Children);
        void AddChildren(TRef tRef, IEnumerable<T> Children);
        void RemoveChildren(TRef tRef, IEnumerable<T> Children);
    }
}
