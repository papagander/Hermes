using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repository
{
    public class IndexedRepository<T> : GenericRepository<T>, IIndexedRepository<T> where T : class, IIndexed
    {
        public IndexedRepository(ReportContext reportContext) : base(reportContext){        }

        public virtual void Add(T entity)
        {
            hContext.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            hContext.Set<T>().AddRange(entities);
        }
        public IEnumerable<T> GetAll()
        {
            return hContext.Set<T>().ToList();
        }
        
        public T? Get(int id)
        {
            return hContext.Set<T>().Find(id);
        }
        public IEnumerable<T> GetRange(IEnumerable< int> ids)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            hContext.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            hContext.Set<T>().RemoveRange(entities);
        }

    }
}
