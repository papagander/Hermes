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
    public class FieldTypeController :
        DataCoreEntityController<FieldType>
        , IFieldTypeController
    {
        public FieldTypeController(ReportContext context) : base(context)
        {
            Functions.Add(new("addops", AddOperators));
            Functions.Add(new("showops", ShowOperators));
        }

        protected override string EntityType { get => "FieldType"; }

        public override void Add()
        {
            string name = NamePrompt(EntityType);
            var ft = new FieldType { Name = name };
            int output;
            output = S.Create(ft);
            if (output == 0) Console.WriteLine("Failed to create field type.");
            if (output == 1) Console.WriteLine($"Created field type '{name}'");
            else Console.WriteLine($"Service returned: {output}");
        }
        public void AddOperators()
        {
            Console.WriteLine("Select a field type to add operators to.");
            var fts = S.GetAllFieldTypes();
            var ft = SelectFromList(fts);
            if (ft is null)
            {
                Console.WriteLine("Cancelling");
                return;
            }
            Console.WriteLine("Select operators to add.");
            List<Operator> ops = new();
            List<Operator> unselectedOps = S.GetAllOperators().ToList();
            var op = SelectFromList(unselectedOps);
            while (op is not null)
            {
                unselectedOps.Remove(op);
                ops.Add(op);
                op = SelectFromList(unselectedOps);
            }
            if (ops.Count == 0)
            {
                Console.WriteLine("Cancelling");
                return;
            }
            foreach (var _op in ops)
            {
                S.Create(ft, _op);
            }
            ft = S.GetFieldType(ft.Id);
            var _ops = S.GetOperators(ft);
            Console.WriteLine($"Updated {ft.Name}:");
            ShowList(_ops);
        }
        public override void ShowAll() => ShowList(S.GetAllFieldTypes());

        public override void HelpPrompt()
        {
            Console.WriteLine("Field types are used to classify field that appear on reports");
            Console.WriteLine("and specify what filters can be applied to them.");
        }

        public override void Remove()
        {
            string name = NamePrompt(EntityType);
            var ft = new FieldType { Name = name };
            int output;
            output = S.Create(ft);
            if (output == 0) Console.WriteLine("Failed to create field type.");
            if (output == 1) Console.WriteLine($"Created field type '{name}'");
            else Console.WriteLine($"Service returned: {output}");
        }

        public void ShowNames(List<FieldType> nameds) => GenericController.SelectFromList(nameds);
        public void ShowOperators()
        {
            Console.WriteLine("Please select a field type.");
            var fts = S.GetAllFieldTypes();
            var ft = SelectFromList(fts);
            if (ft is null)
            {
                Console.WriteLine("Selection canceled.");
            }
            var ops = S.GetOperators(ft);
            Console.WriteLine($"{ft.Name}'s operators:");
            ShowList(ops);

        }
    }
}
