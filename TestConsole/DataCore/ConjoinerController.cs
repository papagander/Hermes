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
        protected override string EntityType { get => "Conjoiner"; }
        public ConjoinerController(ReportContext context) : base(context)
        {
            S = new DataCoreService(reportContext);
        }

        public override void GetAll()
        {
            var Conjoiners = S.GetAllConjoiners();
            ShowNames(Conjoiners);
        }

        public override void Add()
        {
            string name = NamePrompt(EntityType);
            int output = S.CreateConjoiner(name);
            if (output == 0) Console.WriteLine("Failed to create conjoiner.");
            if (output == 1) Console.WriteLine($"Created conjoiner {name}");
            else Console.WriteLine($"Service returned: {output}");
        }

        public override void Remove()
        {
            throw new NotImplementedException();
        }

        public override void HelpPrompt()
        {
            Console.WriteLine("Conjoiners, like 'and' or 'or', are used to build conjunctions");
            Console.WriteLine("which combine multiple filters in order to build query logic.");
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