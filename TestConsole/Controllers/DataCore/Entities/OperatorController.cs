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
    {
        public OperatorController(ReportContext context) : base(context)
        {
        }

        protected override string EntityType { get => "Operator"; }

        public override void Show()
        {
            var ops = S.GetAllOperators();
            foreach (var op in ops)
            {
                string _name = string.Format("{0,4}", op.Name);
                string _executionString = string.Format("{0,2}", op.ExecutionString);
                Console.WriteLine(_name);
                Console.WriteLine(_executionString);
                Console.WriteLine(string.Format("{0,4}","Parameters:"));
                foreach (var param in op.Parameters)
                {
                    Console.WriteLine(string.Format("{0,8}", $"{param.Name} : {param.DbType}"));
                }
                Console.WriteLine(string.Format("{0,4}","Types"));
                foreach (var type in op.OperatorFieldTypes)
                {
                    Console.WriteLine(string.Format("{0,8}", type.DbType));
                }
            }
        }

        public override void HelpPrompt()
        {
            Console.WriteLine("Operator, such as '=', 'contains', or '<' are used to build query logic ");
            Console.WriteLine("and define the filters which can be used on a field type.");
        }

        public override void Add()
        {
            throw new NotImplementedException();
        }
    }
}
