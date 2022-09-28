using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Interfaces
{
    internal interface IController
    {
        //string ControllerName { get; }
        void Help();
        void Pause(int seconds);
        void Run();
    }
}
