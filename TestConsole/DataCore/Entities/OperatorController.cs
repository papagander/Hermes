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
            Functions.Add(new("showfts",ShowFieldTypes));
        }

        protected override string EntityType { get => "Operator"; }

        public override void Add()
        {
            string name = NamePrompt(EntityType);
            var ent = new Operator { Name = name };
            int output = S.Create(ent);
            if (output == 0) Console.WriteLine("Failed to create operator.");
            if (output == 1) Console.WriteLine($"Created operator '{name}'");
            else Console.WriteLine($"Service returned: {output}");
        }

        public override void ShowAll() =>            ShowList(S.GetAllOperators());
        

        public override void Remove()
        {
            Console.WriteLine("Select and operator to delete.");
            var ent = SelectFromList(S.GetAllOperators());
            if (ent is null)
            {
                Console.WriteLine("Removed cancelled.");
                return;
            }
            S.Remove(ent);
        }
        public override void HelpPrompt()
        {
            Console.WriteLine("Operators, such as '=', 'contains', or '<' are used to build query logic ");
            Console.WriteLine("and define the filters which can be used on a field type.");
        }

        public void ShowFieldTypes()
        {
            var op = SelectFromList(S.GetAllOperators());
            if (op is null) 
            {
                Console.WriteLine("Selection cancelled.");
                return;
            }
            ShowList(op.FieldTypes);
        }
    }
}
