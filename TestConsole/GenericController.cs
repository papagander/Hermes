using DataAccess.EFCore;

using Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestConsole.Interfaces;


namespace TestConsole
{
    public abstract class GenericController : IController
    {
        protected List<Function> Functions = new List<Function>();
        protected readonly ReportContext reportContext;
        public GenericController(ReportContext context)
        {
            reportContext = context;
            Functions.Add(new Function("help", Help));
            Functions.Add(new Function("about", About));
        }
        public void Pause(int seconds)
        {
            Console.Write(".  ");
            Thread.Sleep(333 * seconds);
            Console.Write(".  ");
            Thread.Sleep(333 * seconds);
            Console.WriteLine(".  ");
            Thread.Sleep(334 * seconds);
        }
        public void Run()
        {
            Console.Clear();
            while (true)
            {
                PromptForFunction();
                string? input = Console.ReadLine();
                if (input is null)
                {
                    Console.WriteLine("No command provided.");
                    continue;
                }
                input = input.ToLower().Trim();
                foreach (var function in Functions)
                {
                    if (function.Name == input)
                    {
                        function.Action();
                        break;
                    }
                }
                if (input == "quit") break;
            }
        }

        protected abstract void PromptForFunction();
        public abstract void About();
        public abstract void Help();

        void IController.PromptForFunction()
        {
            throw new NotImplementedException();
        }

    }
}
