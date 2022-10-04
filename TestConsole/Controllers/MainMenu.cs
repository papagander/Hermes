using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestConsole.Controllers.FieldSets;
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
            Acts.Add(new("dc", DataCoreMenu));
            Acts.Add(new("fs", FieldSetsMenu));
        }

        public override void HelpPrompt()
        {
            Console.WriteLine("Hermes main menu: select a module to access.");
        }

        protected override void MenuPrompt()
        {
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
    }
}
