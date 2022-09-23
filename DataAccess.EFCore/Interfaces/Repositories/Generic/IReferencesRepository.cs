using Domain.Interfaces.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Interfaces.Repositories.Generic
{
    public interface IReferencesRepository<T, TRef> : IIndexedRepository<T> where T : IReferences<TRef> where TRef : IIndexed
    {
        IEnumerable<T> GetRangeByParent(TRef MyTRef);
        //IEnumerable<T> GetRangeByParent(int MyTRefId);
    }
}
