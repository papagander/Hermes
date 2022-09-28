using DataAccess.EFCore;

using Services;
using Services.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestConsole.Interfaces;

namespace TestConsole.DataCore
{
    internal class DataCoreController : GenericController, IController
    {
        public DataCoreController(ReportContext context) : base(context)
        {
            Functions.Add(new("conjoiner", ConjoinerMenu));
            Console.Clear();
            Console.WriteLine("Welcome to Hermes DataCore interface!");
            Pause(3);
        }


        protected override void PromptForFunction()
        {
            Console.Clear();
            Console.WriteLine("Type 'about' to learn more about the DataCore module or 'help'");
            Console.WriteLine("for a guide on using this interface.");
            Console.WriteLine();
            Console.WriteLine("Otherwise, enter an entity table to access.");
        }
        public override void About()
        {
            Console.WriteLine("The DataCore module is used to the base entities used for report logic:");
            Pause(1);
            Console.WriteLine("Field Types, Operators, FieldTypeOperators (which link FieldTypes to the Operators which can be used by them),");
            Console.WriteLine("and Conjoiners, which are conjunctions like 'and' or 'or' which are used to build multi-condition filters.");
            Pause(3);
            Console.WriteLine("These are core to the funcitonality of all reports and should never be deleted in production.");
            Console.WriteLine("Most of these, or at least the most important of these, will be in place at launch.");
            Console.WriteLine("More can be added by a developer as needed.");
            Pause(1);
            Console.WriteLine("Press enter to return to main menu.");
            Console.ReadLine();
            Console.Clear();
        }
        private void MainHelp()
        {
            Console.WriteLine("Type the name of a table to access its functions.");
            Console.WriteLine("After you select a table, you can type 'help' to view its commands.");
            Console.WriteLine();
            Console.WriteLine("Press enter to return to main menu.");
            Console.Clear();
        }
        public void ConjoinerMenu()
        {
            ConjoinerController conjoinerController = new(reportContext);
            conjoinerController.Run();
        }

        public override void Help()
        {
            throw new NotImplementedException();
        }

    }
}
