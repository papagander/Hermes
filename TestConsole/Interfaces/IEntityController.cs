using Domain.Interfaces.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Interfaces
{
    internal interface IEntityController<T> where T : class, IIndexed
    {
        internal void Run();
        internal void Add();
        internal void ShowAll();
        internal void Help();
    }
}
