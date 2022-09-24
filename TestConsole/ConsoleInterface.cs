using DataAccess.EFCore;

using Services;
using Services.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    internal class ConsoleDataCoreController
    {
        IDataCoreService S { get; set; }

        public ConsoleDataCoreController(ReportContext _context)
        {
            S = new DataCoreService(_context);
        }

        private bool ParseAndRun(string commandString) 
        {
            switch (commandString.Split(" ")[0])
            {
                case "createconjoiner":

                default:
                    break;
            }
            return false;
        }
        private bool CreateConjoiner(string Name) => S.CreateConjoiner(Name) > 0;
    }
}
