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

        protected override string MenuName { get => "Operator"; }
        protected override string EntityType { get => "Operator"; }
        protected override string AboutBody => "Operator, such as '=', 'contains', or '<' are used to build query logic and define the filters which can be used on a field type.";

        public override void ShowAll()
        {
            var ops = S.GetAllOperators();
            foreach (var op in ops)
            {
                string _name = string.Format(op.Name);
                string _executionString = string.Format("{0,10}", op.ExecutionString);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(_name);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(_executionString);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine(string.Format("{1,-10}", "", "Parameters:"));
                Console.ForegroundColor = ConsoleColor.Magenta;
                foreach (var param in op.Parameters)
                {
                    string paramName = param.Name;
                    string? dbType = param.DbType.ToString();
                    if (dbType is null || dbType == "") dbType = "default";

                    Console.WriteLine(string.Format("{0,4}{1,-10}", "", $"{paramName} : {dbType}"));
                }
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(string.Format("{1,-10}", "", "Types"));
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (var type in op.OperatorFieldTypes)
                {
                    Console.WriteLine(string.Format("{0,4}{1,-10}", "", type.DbType));
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public override void Add()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Operators cannot be added through this menu at this time.");
            Pause(2);
            Console.Clear();
        }
    }
}
