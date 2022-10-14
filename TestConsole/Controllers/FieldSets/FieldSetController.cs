global using Services;
using Domain.Models.FieldSets;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestConsole.Interfaces.FieldSets;

namespace TestConsole.Controllers.FieldSets
{
    public class FieldSetController :
        GenericEntityController<FieldSet>
        , IFieldSetController
    {
        private FieldSetService S;
        public FieldSetController(ReportContext context) : base(context)
        {
            S = new FieldSetService(context);

            string nm; Action a;
            nm = "AddF"; a = AddFields;
            Acts.Add(new (nm, a));
            nm = "RemF"; a = RemoveFields;
            Acts.Add (new (nm, a));
            nm = "SetF"; a = SetFields;
            Acts.Add(new(nm, a));
            nm = "fdeets"; a = ShowFieldDetails;
            Acts.Add(new(nm, a));
        }

        protected override string EntityType { get => "Field Set"; }

        public override void Add()
        {
            string? fsName = NamePrompt("Field Set");
            if (fsName is null)
            {
                Console.WriteLine("Cancelling");
                return;
            }
            var fields = CreateList(CreateField);
            if (fields is null)
            {
                Console.WriteLine("Cancelling");
                return;
            }
            int output = S.CreateFieldSet(fsName, fields);
            Console.WriteLine($"Changed {output} rows.");
        }
        public void ShowFieldDetails()
        {
            throw new NotImplementedException("waaaaaaaah");
        }
        protected Field? CreateField()
        {
            throw new NotImplementedException();
        }

        public void AddFields()
        {
            throw new NotImplementedException();
        }

        public override void HelpPrompt() => Console.WriteLine("This menu is used to create field sets" +
            "for stakeholders to build queries against.");

        public void RemoveFields()
        {
            throw new NotImplementedException();
        }

        public override void RemoveRange()
        {
            throw new NotImplementedException();
        }

        public void SetFields()
        {
            throw new NotImplementedException();
        }

        public override void Show()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("_______________________");
            string header = string.Format("{0, 10} {1,12}", "Field Set", "Field");
            Console.WriteLine(header);
            var fz = S.GetFieldSets();
            Show<Field>(fz);
            Console.WriteLine("_______________________");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
