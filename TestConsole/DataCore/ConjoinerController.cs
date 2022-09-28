using DataAccess.EFCore;

using Domain.Models.DataCore;

using Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestConsole.Interfaces;

namespace TestConsole.DataCore
{
    internal class ConjoinerController :
        GenericDataCoreEntityController<Conjoiner>
    {
        protected override string EntityName { get => "Conjoiner"; }
        public ConjoinerController(ReportContext context) : base(context)
        {
            S = new DataCoreService(reportContext);
        }

        public override void GetAll()
        {
            var Conjoiners = S.GetAllConjoiners();
            foreach (var item in Conjoiners)
            {
                Console.WriteLine($"{item.ConjoinerId}. {item.ConjoinerName}");
            }
        }

        public override void Help()
        {
            throw new NotImplementedException();
        }

        public override void Add()
        {
            int output;
            Console.WriteLine("Please provide a conjoiner name");
            string name = Console.ReadLine();
            if (name is null)
            {
                Console.Clear();
                Add();
                return;
            }
            output = S.CreateConjoiner(name);
            if (output == 0) Console.WriteLine("Failed to create conjoiner.");
            if (output == 1) Console.WriteLine($"Created conjoiner {name}");
            else Console.WriteLine($"Service returned: {output}");
        }
        void Add(string name)
        {
            int output = S.CreateConjoiner(name);
            if (output == 0) Console.WriteLine("Failed to create conjoiner.");
            if (output == 1) Console.WriteLine($"Created conjoiner {name}");
            else Console.WriteLine($"Service returned: {output}");
        }

        public override void Remove()
        {
            throw new NotImplementedException();
        }

        public override void About()
        {
            throw new NotImplementedException();
        }

    }
}

/*
private void Run()
{
    Console.Write("Conjoiner.");
    string? input = Console.ReadLine().ToLower();
    while (true)
    {
        Console.Write("Conjoiner.");
        switch (input)
        {
            case "add":
                Add();
                break;
            case "get":
                GetAll();
                break;
            case "help":
                ConjoinerHelp();
                break;
        }
        input = Console.ReadLine().ToLower();
        Console.WriteLine();
    }
}
*/