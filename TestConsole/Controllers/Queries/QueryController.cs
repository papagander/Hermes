using Domain.Models.Queries;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Controllers.Queries
{
    public class QueryController
        : GenericEntityController<Query>
    {
        public QueryController(ReportContext context) : base(context)
        {
        }

        protected override string EntityType { get => "Query"; }

        public override void Add()
        {
            var name = NamePrompt(EntityType);
            if (name == null)
            {
                Console.WriteLine("Cancelling");
                return;
            }
            Console.WriteLine("Select a dataset for this field.");
        }

        public override void HelpPrompt()
        {
            throw new NotImplementedException();
        }

        public override void RemoveRange()
        {
            throw new NotImplementedException();
        }

        public override void Show()
        {
            throw new NotImplementedException();
        }
    }
}