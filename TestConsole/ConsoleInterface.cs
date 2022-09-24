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
        public int? Run()
        {
            Console.WriteLine("Welcome to the Hermes DataCore inteface.");
            Pause(1);
            Console.WriteLine("Type 'about' to learn more about the DataCore module or 'help'");
            Console.WriteLine("for a guide on using this interface.");
            Console.WriteLine();
            Console.WriteLine("Otherwise, enter an entity table to access.");
            string input = Console.ReadLine().ToLower();
            while (input.ToLower() != "exit")
            {
                switch (input)
                {
                    case "about":
                        About();
                        break;
                    case "help":
                        MainHelp();
                        break;
                    case "conjoiner":
                        ConjoinerInterface();
                }
                input = Console.ReadLine().ToLower();
            }

        }
        private void About()
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
        private void ConjoinerInterface()
        {
            Console.Write("Conjoiner.");
            string? input = Console.ReadLine().ToLower();
            while (input is not null)
            {
                switch (input)
                {
                    case "create":
                        CreateConjoiner();
                        break;
                    case "get":
                        GetConjoiners();
                        break;
                    case "help":
                        ConjoinerHelp();
                        break;
                }
                input = Console.ReadLine().ToLower();
            }
        }

        private void GetConjoiners()
        {
            throw new NotImplementedException();
        }

        private void ConjoinerHelp()
        {
            throw new NotImplementedException();
        }

        private void CreateConjoiner()
        {
            int output;
            Console.WriteLine("Please provide a conjoiner name");
            string name = Console.ReadLine();
            if (name is null)
            {
                Console.Clear();
                CreateConjoiner();
                return;
            }
            output = S.CreateConjoiner(name);
            if (output == 0) Console.WriteLine("Failed to create conjoiner.");
            if (output == 1) Console.WriteLine($"Created conjoiner {name}");
            else Console.WriteLine($"Service returned: {output}");
            Pause(2);
            Console.Clear();
        }
        private void Pause(int seconds)
        {
            Thread.Sleep(250 * seconds);
            Console.WriteLine("\t.\t");
            Thread.Sleep(250 * seconds);
            Console.Write(".\t");
            Thread.Sleep(250 * seconds );
            Console.Write(".\t");
            Thread.Sleep(250 * seconds );
        }


    }
}
