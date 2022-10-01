using DataAccess.EFCore;

using Services;
using Services.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole.DataCore.Entities;
using TestConsole.Interfaces;

namespace TestConsole.DataCore
{
    internal class DataCoreController : GenericController, IController
    {
        public DataCoreController(ReportContext context) : base(context)
        {
            Functions.Add(new("cjr", ConjoinerMenu));
            Functions.Add(new("ft", FieldTypeMenu));
            Functions.Add(new("op", OperatorMenu));
            Functions.Add(new("about", About));
            Console.Clear();
            Console.WriteLine("Welcome to Hermes DataCore interface!");
            Pause(1);
            Console.Clear();
        }


        protected override void MenuPrompt()
        {
            Console.WriteLine("Type 'about' to learn more about the DataCore module or 'help'");
            Console.WriteLine("for a guide on using this interface.");
            Console.WriteLine();
            Console.WriteLine("Otherwise, enter an entity table to access.");
        }
        public void About()
        {
            Console.WriteLine("The DataCore module is used to the base entities used for report logic:");
            Pause(1);
            Console.WriteLine("Field Types, Operator, FieldTypeOperators (which link FieldType to the Operator which can be used by them),");
            Console.WriteLine("and Conjoiner, which are conjunctions like 'and' or 'or' which are used to build multi-condition filters.");
            Pause(3);
            Console.WriteLine("These are core to the funcitonality of all reports and should never be deleted in production.");
            Console.WriteLine("Most of these, or at least the most important of these, will be in place at launch.");
            Console.WriteLine("More can be added by a developer as needed.");
            Pause(1);
            Console.WriteLine("Press enter to return to main menu.");
            Console.ReadLine();
            Console.Clear();
        }
        public void ConjoinerMenu()
        {
            ConjoinerController conjoinerController = new(reportContext);
            conjoinerController.Run();
        }
        public void OperatorMenu()
        {
            OperatorController controller = new(reportContext);
            controller.Run();
        }
        public void FieldTypeMenu()
        {
            FieldTypeController controller = new(reportContext);
            controller.Run();
        }
        public override void HelpPrompt()
        {
            Console.WriteLine("Use this menu to access the entities in the DataCore module.");
            Console.WriteLine("These types are atomic to global query logic and should");
            Console.WriteLine("for the most part be preconfigured when Hermes is deployed,");
            Console.WriteLine("although new operators may be desirable in the future.");
        }
    }
}
