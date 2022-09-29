using Domain.Interfaces.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Interfaces
{
    internal interface INamedEntityController<T> : 
        IEntityController<T>
        where T : class, INamed

    {
        public void ShowNames(List<T> nameds);
    }
}
