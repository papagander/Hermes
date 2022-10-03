
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Interfaces.Repositories
{
    public interface IReadRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
    }
}
