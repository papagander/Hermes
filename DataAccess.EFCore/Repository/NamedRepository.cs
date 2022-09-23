using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.EFCore.Interfaces.Repositories.Generic;

namespace DataAccess.EFCore.Repository
{
    internal class NamedRepository<T> : IndexedRepository<T>, INamedRepository<T> where T : INamed
    {
        public T Get(string Name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetRange(IEnumerable<string> Names)
        {
            throw new NotImplementedException();
        }

        public T Remove(string Name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> RemoveRange(IEnumerable<string> Names)
        {
            throw new NotImplementedException();
        }

        public void Rename(string OldName, string NewName)
        {
            throw new NotImplementedException();
        }
    }
}
