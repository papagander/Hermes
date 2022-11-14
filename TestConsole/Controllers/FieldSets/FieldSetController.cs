global using Services;

using Domain.Models.FieldSets;


using System;
using System.Collections.Generic;
using System.Data;
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
            Actions.Add(new(nm, a));
        }

        protected override string EntityType { get => "Field Set"; }
        protected override string MenuName { get => "Field Set"; }
        protected override string AboutBody => "This menu is used to create tables for stakeholders to build queries against.";

        public override void Add()
        {
            string? fsName = NamePrompt("Field Set");
            if (fsName is null)
            {
                Console.WriteLine("Cancelling");
                return;
            }
            var fields = new List<Field>();
            var field = CreateField();
            while (field is not null)
            {
                fields.Add(field);
                Console.WriteLine($"{fsName}'s fields:");
                Console.WriteLine(String.Format("{0,4}{1,-20} | {2,-12}", "", "Field", "DbType"));
                foreach (var _field in fields)
                {
                    Console.WriteLine(String.Format("{0,4}{1,-20} | {2,-12}", "", _field.Name, _field.DbType));
                }
                field = CreateField();
            }
            if (fields.Count == 0)
            {
                Console.WriteLine("Cancelling");
                return;
            }
            Console.WriteLine($"Creating Field Set {fsName}...");
            int output = S.CreateFieldSet(fsName, fields);
            Console.WriteLine($"Changed {output} rows.");
        }
        protected Field? CreateField()
        {
            string? name;
            do
            {
                Console.WriteLine("Provide a field name. DbType exit when all fields are created.");
                name = Console.ReadLine();

            } while (name is null || name == "");
            if (name.ToLower() == "exit") return null;

            var dbTypes = new List<SqlDbType>();
            var _names = Enum.GetNames(typeof(SqlDbType));
            foreach (var typeName in _names) dbTypes.Add((SqlDbType)Enum.Parse(typeof(SqlDbType), typeName));
            int selectionId;
            bool selectionIsValid;
            do
            {
                Console.WriteLine("Select a field type by entering the corresponding number.");

                for (int i = 0; i < dbTypes.Count; i++)
                {
                    SqlDbType _type = dbTypes[i];
                    Console.WriteLine(String.Format("{0,2}. {1,10}", i, _type));
                }
                selectionIsValid = int.TryParse(Console.ReadLine(), out selectionId);
                selectionIsValid = selectionIsValid && selectionId < dbTypes.Count;
            } while (!selectionIsValid);
            var dbType = dbTypes[selectionId];
            return new Field() { Name = name, DbType = dbType };

            throw new NotImplementedException();
        }

        public void AddFields()
        {
            var fs = SelectFromList(S.GetFieldSets());
            var fields = CreateList(CreateField);
            S.AddFields(fs, fields);
        }



        public override void ShowAll()
        {
            var fsz = S.GetFieldSets();
            Console.WriteLine(String.Format("{0,-16}|{1,16}|{2,16}", "Field Set", "Field", "Field DbType"));
            Console.WriteLine("**************************************************");
            foreach (var fs in fsz)
            {
                if (fs.Fields is null || fs.Fields.Count == 0)
                {
                    Console.WriteLine(String.Format("{0,-16}|{1,16}", fs.Name, "No fields in this set"));

                }
                else
                {
                    foreach (var field in fs.Fields)
                    {
                        Console.WriteLine(String.Format("{0,-16}|{1,16}|{2, 16}", fs.Name, field.Name, field.DbType));
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
