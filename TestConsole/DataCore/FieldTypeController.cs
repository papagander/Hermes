using DataAccess.EFCore;

using Domain.Models.DataCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.DataCore
{
    public class FieldTypeController : GenericDataCoreEntityController<FieldType>
    {
        public FieldTypeController(ReportContext context) : base(context)
        {
        }

        protected override string EntityType { get => "FieldType"; }

        public override void Add()
        {
            string name = NamePrompt(EntityType);
            int output;
            output = S.CreateFieldType(name);
            if (output == 0) Console.WriteLine("Failed to create field type.");
            if (output == 1) Console.WriteLine($"Created field type '{name}'");
            else Console.WriteLine($"Service returned: {output}");
        }


        public override void GetAll()
        {
            throw new NotImplementedException();
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
