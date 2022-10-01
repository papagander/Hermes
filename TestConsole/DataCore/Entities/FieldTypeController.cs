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
            Functions.Add(new("delops", RemoveOperators));
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
            var fts = S.GetAllFieldTypes();
            Console.WriteLine("Select a field type to add operators to.");
            var ft = SelectFromList(fts);
            if (ft is null)
            {
                Console.WriteLine("Cancelling");
                return;
            }
            var curOps = S.GetOperators(ft);
            Console.WriteLine("Select operators to add.");
            List<Operator> allOps = S.GetAllOperators().ToList();
            foreach (var curOp in curOps) allOps.Remove(curOp);
            List<Operator> ops = SelectListFromList(allOps);
            if (ops.Count == 0)
            {
                Console.WriteLine("Cancelling");
                return;
            }
            int output = S.AddOperators(ft, ops);
            Console.WriteLine($"{output} rows changed.");
        }
        public void RemoveOperators()
        {
            var fts = S.GetAllFieldTypes();
            Console.WriteLine("Select a field type to remove operators from.");
            var ft = SelectFromList(fts);
            if (ft is null)
            {
                Console.WriteLine("Cancelling");
                return;
            }
            Console.WriteLine("Select operators to remove.");
            var allOps = S.GetOperators(ft);
            List<Operator> ops = SelectListFromList(allOps);
            if (ops.Count == 0)
            {
                Console.WriteLine("Cancelling");
                return;
            }
            int output = S.RemoveOperators(ft, ops);
            Console.WriteLine($"{output} rows changed.");
        }

        private static List<T> SelectListFromList<T>(IEnumerable<T> source)
            where T : class
        {
            List<T> list = source.ToList();
            List<T> output = new();
            var op = SelectFromList(source);
            while (op is not null)
            {
                list.Remove(op);
                output.Add(op);
                op = SelectFromList(list);
            }
            return output;
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
            string header = string.Format("{0, 8} {1,10}", "Field Type", "Operator");
            Console.WriteLine(header);
            foreach (var ft in S.GetAllFieldTypes())
                foreach (var op in ft.Operators)
                    Console.WriteLine( string.Format("{0,8} {1,10}", ft.Name, op.Name));
        }
    }
}
