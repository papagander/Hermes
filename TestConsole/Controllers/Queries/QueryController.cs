using Domain.Models.FieldSets;
using Domain.Models.Queries;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Controllers.Queries
{
    public class QueryController
        : GenericEntityController<Query>
    {
        QueryService S;
        public QueryController(ReportContext context) : base(context)
        {
            S = new(context);
        }

        protected override string EntityType { get => "Query"; }

        public override void Add()
        {
            Console.WriteLine("Provide a name for this query.");
            string name;
            FieldSet fs;
            List<Field> fields;
            name = NamePrompt(EntityType);
            if (name == null)
            {
                Console.WriteLine("Cancelling");
                return;
            }
            fs = SelectFieldSet();
            var _fields = fs.Fields;
            Console.WriteLine("Select fields to be included on this query.");
            fields = SelectListFromList(_fields);
            if (fields is null || fields.Count == 0)
            {
                Console.WriteLine("Cancelling");
                return;
            }
            var query = new Query { Name = name, FieldSet = fs, Fields = fields };
            int selectionId;
            bool isValid;
            do
            {
                Console.WriteLine("Would you like to add a filter to this query?");
                Console.WriteLine("1. yes");
                Console.WriteLine("2. no");
                isValid = int.TryParse(Console.ReadLine(), out selectionId);
                isValid = isValid && (selectionId == 1 || selectionId == 2);
            } while (!isValid);

        }
        FieldSet SelectFieldSet()
        {

            var _fsz = S.GetFieldSets().ToList();
            int selectionId;
            bool selectionIsValid;
            do
            {
                Console.WriteLine("Select a source table for this field.");
                for (int i = 0; i < _fsz.Count; i++)
                {
                    FieldSet _fs = _fsz[i];
                    Console.WriteLine(String.Format("{0,2}. {1,0}", i, _fs.Name));
                }
                selectionIsValid = int.TryParse(Console.ReadLine(), out selectionId);
                selectionIsValid = selectionIsValid && selectionId < _fsz.Count;

            } while (!selectionIsValid);
            return _fsz[selectionId];
        }
        public override void HelpPrompt()
        {
            Console.WriteLine("Each query has a source table (or field set) which contains the data");
            Console.WriteLine("filtered by the query. A subset of the table's fields are selected,");
            Console.WriteLine("And a combian");
        }

        public override void Show()
        {
            throw new NotImplementedException();
        }
    }
}