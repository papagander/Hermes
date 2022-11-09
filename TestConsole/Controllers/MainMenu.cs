using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestConsole.Controllers.FieldSets;
using TestConsole.Controllers.Queries;
using TestConsole.DataCore;
using TestConsole.Interfaces;

namespace TestConsole.Controllers
{
    public  class MainMenu :
        GenericController
        , IController
    {
        public MainMenu(ReportContext context) : base(context)
        {
            Actions.Add(new("dc", DataCoreMenu));
            Actions.Add(new("fs", FieldSetsMenu));
            Actions.Add(new("q", QueriesMenu));
        }

        public override void HelpPrompt()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Hermes main menu: select a module to access.");
        }

        protected override void MenuPrompt()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Select a module to access.");
        }
        protected void DataCoreMenu()
        {
            DataCoreController myController = new DataCoreController(context);
            myController.Run();
        }
        protected void FieldSetsMenu()
        {
            FieldSetController controller = new FieldSetController(context);
            controller.Run();
        }
        protected void QueriesMenu()
        {
            var controller = new QueryController(context);
            controller.Run();
        }
    }
}
