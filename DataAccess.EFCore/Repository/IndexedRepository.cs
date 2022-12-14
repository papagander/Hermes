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
            context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            context.Set<T>().AddRange(entities);
        }
        public virtual IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }
        
        public virtual T? Get(int id)
        {
            return context.Set<T>().Find(id);
        }
        public IEnumerable<T> GetRange(IEnumerable< int> ids)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
        }

    }
}
