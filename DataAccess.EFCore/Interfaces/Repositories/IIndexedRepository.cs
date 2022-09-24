using Domain.Interfaces.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Interfaces.Repositories
{
    public interface IIndexedRepository<T> where T : IIndexed
    {
        T Get(int dex);
        IEnumerable<T> GetRange(IEnumerable<int> dexes);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
