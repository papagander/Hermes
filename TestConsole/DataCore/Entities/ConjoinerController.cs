global using Domain;
using DataAccess.EFCore;

using Domain.Models.DataCore;
using Domain.Models.Queries;
using Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestConsole.Interfaces;

namespace TestConsole.DataCore.Entities
{
    internal class ConjoinerController :
        DataCoreEntityController<Conjoiner>
    {
        protected override string EntityType { get => "Conjoiner"; }
        public ConjoinerController(ReportContext context) : base(context)
        {
        }

        public override void ShowAll()
        {
            List<Conjoiner> Conjoiners = new List<Conjoiner>();
            Conjoiners.AddRange(S.GetAllConjoiners());
            ShowList(Conjoiners);
        }

        public override void Add()
        {
            string name = NamePrompt(EntityType);
            var ent = new Conjoiner { Name = name };
            int output = S.Create(ent);
            if (output == 0) Console.WriteLine("Failed to create conjoiner.");
            if (output == 1) Console.WriteLine($"Created conjoiner {name}");
            else Console.WriteLine($"Service returned: {output}");
        }

        public override void Remove()
        {
            string name = NamePrompt(EntityType);
            var ent = new Conjoiner { Name = name };
            int output = S.Remove(ent);
            if (output == 0) Console.WriteLine("Failed to remove conjoiner.");
            if (output == 1) Console.WriteLine($"Removed conjoiner {name}");
            else Console.WriteLine($"Service returned: {output}");

        }

        public override void HelpPrompt()
        {
            Console.WriteLine("Conjoiners, like 'and' or 'or', are used to build conjunctions");
            Console.WriteLine("which combine multiple filters in order to build query logic.");
        }

        public void SelectName(List<Conjoiner> nameds) => GenericController.SelectFromList(nameds);
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
                ShowAll();
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