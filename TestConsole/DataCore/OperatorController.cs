using DataAccess.EFCore;

using Domain.Models.DataCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.DataCore
{
    internal class OperatorController :
        GenericDataCoreEntityController<Operator>
    {
        public OperatorController(ReportContext context) : base(context)
        {
        }

        protected override string EntityType { get => "Operator"; }

        public override void Add()
        {
            string name = NamePrompt(EntityType);
            int output = S.CreateOperator(name);
            if (output == 0) Console.WriteLine("Failed to create operator.");
            if (output == 1) Console.WriteLine($"Created operator '{name}'");
            else Console.WriteLine($"Service returned: {output}");
        }

        public override void GetAll()
        {
            var operators = S.GetAllOperators();
            foreach (var op in operators)
            {
                Console.WriteLine(op.OperatorName);
            }
        }

        public override void Remove()
        {
            throw new NotImplementedException();
        }
        public override void HelpPrompt()
        {
            Console.WriteLine("Operators, such as '=', 'contains', or '<' are used to build query logic ");
            Console.WriteLine("and define the filters which can be used on a field type.");
        }
    }
}
