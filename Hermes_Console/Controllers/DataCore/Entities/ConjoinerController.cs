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
using TestConsole.Controllers;
using TestConsole.Interfaces;

namespace TestConsole.DataCore.Entities;
internal class ConjoinerController 
    : DataCoreEntityController<Conjoiner>
{
    protected override string MenuName { get => "Conjoiner"; }
    protected override string EntityType { get => "Conjoiner"; }
    protected override string AboutBody => "Conjoiners, like 'and' or 'or', are used to build conjunctions which combine multiple filters in order to build query logic.";
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
        string? name = NamePrompt(EntityType);
        if (name == null)
        {
            Console.WriteLine("Cancelling");
            return;
        }
        int output = S.AddConjoiner(name);
        if (output == 0) Console.WriteLine("Failed to create conjoiner.");
        if (output == 1) Console.WriteLine($"Created conjoiner {name}");
        else Console.WriteLine($"Service returned: {output}");
    }
}
