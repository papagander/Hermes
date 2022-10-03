using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Interfaces.Repositories.ReadOnly
{
    public interface IReadRepository<T>
    {
        IEnumerable<T> GetAll();
    }
}
