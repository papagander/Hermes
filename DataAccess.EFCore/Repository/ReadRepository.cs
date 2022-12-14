
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repository
{
    public class ReadRepository<T> :
        GenericRepository<T>
        , IReadRepository<T>
        where T : class
    {
        public ReadRepository(ReportContext context) : base(context)
        {
        }

        public IEnumerable<T> GetAll() => context.Set<T>();
    }
}
