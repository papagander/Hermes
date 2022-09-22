
using Domain.Interfaces.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Interfaces.Repositories
{
    public interface INamedRepository<T> : IIndexedRepository<T> where T : INamed
    {
        T Get(string Name);
        IEnumerable<T> GetRange(IEnumerable<string> Names);
    }
}
