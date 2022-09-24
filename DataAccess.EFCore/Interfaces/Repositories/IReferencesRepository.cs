using Domain.Interfaces.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Interfaces.Repositories
{
    public interface IReferencesRepository<T, TRef> : IIndexedRepository<T> where T : IReferences<TRef> where TRef : IIndexed
    {
        IEnumerable<T> GetRange(TRef MyTRef);
        //IEnumerable<T> GetRange(int MyTRefId);
    }
}
