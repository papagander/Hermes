using DataAccess.EFCore;

using Services;
using Services.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole.Controllers;
using TestConsole.DataCore.Entities;
using TestConsole.Interfaces;

namespace TestConsole.DataCore
{
    internal class DataCoreController : GenericController, IController
    {
        public DataCoreController(ReportContext context) : base(context)
        {
            Actions.Add(new("cjr", ConjoinerMenu));
            Actions.Add(new("op", OperatorMenu));
            Actions.Add(new("about", About));
            Console.Clear();
            Console.WriteLine("Welcome to Hermes DataCore interface!");
            Pause(1);
            Console.Clear();
        }


        protected override void MenuPrompt()
        {
            Console.WriteLine("DbType 'about' to learn more about the DataCore module or 'help'");
            Console.WriteLine("for a guide on using this interface.");
            Console.WriteLine();
            Console.WriteLine("Otherwise, enter an entity table to access.");
        }
        public void About()
        {

        }
        public void ConjoinerMenu()
        {
            ConjoinerController conjoinerController = new(context);
            conjoinerController.Run();
        }
        public void OperatorMenu()
        {
            OperatorController controller = new(context);
            controller.Run();
        }
        public override void HelpPrompt()
        {

        }
    }
}
