
using Domain.Interfaces.Models;

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
        T Remove(string Name);
        void Rename(string OldName, string NewName);
        IEnumerable<T> GetRange(IEnumerable<string> Names);
        IEnumerable<T> RemoveRange(IEnumerable<string> Names);
    }
}
