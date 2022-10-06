using DataAccess.EFCore;

using Domain.Models.DataCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestConsole.Interfaces;
using TestConsole.Interfaces.DataCore.Entities;

namespace TestConsole.DataCore.Entities
{
    internal class OperatorController :
        DataCoreEntityController<Operator>
        , IOperatorController
    {
        public OperatorController(ReportContext context) : base(context)
        {
        }

        protected override string EntityType { get => "Operator"; }

        public override void Add()
        {
            string name = NamePrompt(EntityType);
            var ent = new Operator { Name = name };
            int output = S.Add(ent);
            if (output == 0) Console.WriteLine("Failed to create operator.");
            if (output == 1) Console.WriteLine($"Created operator '{name}'");
            else Console.WriteLine($"Service returned: {output}");
        }

        public override void Show() =>            ShowList(S.GetAllOperators());
        public override void RemoveRange()
        {
            var es = SelectListFromList(S.GetAllOperators());
            if (es.Count == 0)
            {
                Console.WriteLine("Cancelling");
                return;
            }
            int output = 0;
            foreach (var e in es) output += S.Remove(e);
            Console.WriteLine($"Changed {output} rows.");
        }

        public override void HelpPrompt()
        {
            Console.WriteLine("Operator, such as '=', 'contains', or '<' are used to build query logic ");
            Console.WriteLine("and define the filters which can be used on a field type.");
        }

    }
}
