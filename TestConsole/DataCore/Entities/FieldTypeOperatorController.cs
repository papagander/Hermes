using DataAccess.EFCore;

using Domain.Models.DataCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestConsole.Interfaces;

namespace TestConsole.DataCore.Entities
{
    internal class FieldTypeOperatorController :
        DataCoreEntityController<FieldTypeOperator>
    {
        public FieldTypeOperatorController(ReportContext context) : base(context)
        {
        }

        protected override string EntityType { get => "FieldTypeOperator"; }

        public override void Add()
        {
            Console.WriteLine("Select a field type.");
            List<FieldType> fieldTypes = new List<FieldType>();
            fieldTypes.AddRange(S.GetAllFieldTypes());
            var fieldType =  SelectFromList(fieldTypes);
            if (fieldType is null)
            {
                Console.WriteLine("No field type selected, cancelling insert.");
                return;
            }
            Console.WriteLine("Select an op.");
            List<Operator> operators = new List<Operator>();
            operators.AddRange(S.GetAllOperators());
            var op = SelectFromList(operators);
            if (op is null)
            {
                Console.WriteLine("No operator selected, cancelling insert.");
                return;
            }
            int result = S.Create(fieldType, op);
            if (result == 0) Console.WriteLine("Failed to insert.");
            else if (result == 1) Console.WriteLine("Inserted successfully!");
            else Console.WriteLine($"Service returned: {result}");

        }

        public override void ShowAll()
        {
            ShowList(S.GetAllFtos());
        }

        public override void HelpPrompt()
        {
            Console.WriteLine("Field Type Operators are used to create bonds between field types and the operators which can be used on them.");
        }

        public override void Remove()
        {
            Console.WriteLine("Select a field type.");
            List<FieldType> fieldTypes = new List<FieldType>();
            fieldTypes.AddRange(S.GetAllFieldTypes());
            var fieldType = SelectFromList(fieldTypes);
            if (fieldType is null)
            {
                Console.WriteLine("No field type selected, cancelling remove.");
                return;
            }
            Console.WriteLine("Select an op.");
            List<Operator> operators = new List<Operator>();
            operators.AddRange(S.GetAllOperators());
            var op = SelectFromList(operators);
            if (op is null)
            {
                Console.WriteLine("No op selected, cancelling remove.");
                return;
            }
            S.Remove(fieldType, op);
        }
    }
}
