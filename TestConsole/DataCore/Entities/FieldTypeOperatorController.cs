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

        protected override string EntityType { get; }

        public override void Add()
        {
            Console.WriteLine("Enter the number corresponding to the desired field type.");
            List<FieldType> fieldTypes = new List<FieldType>();
            fieldTypes.AddRange(S.GetAllFieldTypes());
            GenericController.ShowNames(fieldTypes);

        }

        public override void GetAll()
        {
            List<FieldTypeOperator> fieldTypeOperators = new();
            for (int i = 0; i < fieldTypeOperators.Count; i++)
            {
                FieldTypeOperator? fto = fieldTypeOperators[i];
                Console.WriteLine($"{i}.\t{fto.FieldType.Name}\t");
            }
        }

        public override void HelpPrompt()
        {
            throw new NotImplementedException();
        }

        public override void Remove()
        {
            throw new NotImplementedException();
        }
    }
}
