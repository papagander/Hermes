using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Interfaces.UnitsOfWork
{
    public interface IUnitOfWork
    {
        int Complete();
    }
}
