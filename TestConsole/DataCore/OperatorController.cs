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

        protected override string EntityName { get; }

        public override void Add()
        {
            int output;
            Console.WriteLine("Please provide an operator name");
            string name = Console.ReadLine();
            if (name is null)
            {
                Console.Clear();
                Add();
                return;
            }
            output = S.CreateOperator(name);
            if (output == 0) Console.WriteLine("Failed to create operator.");
            if (output == 1) Console.WriteLine($"Created operator {name}");
            else Console.WriteLine($"Service returned: {output}");
        }

        public override void GetAll()
        {
            throw new NotImplementedException();
        }

        public override void Remove()
        {
            throw new NotImplementedException();
        }
        public override void About()
        {
            throw new NotImplementedException();
        }


        public override void Help()
        {
            throw new NotImplementedException();
        }

    }
}
