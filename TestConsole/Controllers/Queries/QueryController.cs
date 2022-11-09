using Domain.Models.DataCore;
using Domain.Models.FieldSets;
using Domain.Models.Queries;

using Microsoft.Data.SqlClient.DataClassification;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestConsole.Controllers.Queries;
public class QueryController
    : GenericEntityController<Query>
{
    QueryService S;
    public QueryController(ReportContext context) : base(context)
    {
        S = new(context);
    }

    protected override string EntityType { get => "Query"; }

    List<Field>? SelectFields(FieldSet fs)
    {
        var fields = new List<Field>();
        var allFields = fs.Fields;
        Console.WriteLine("Select fields to be included on this query.");
        fields = SelectListFromList(allFields);
        if (fields is null || fields.Count == 0)
        {
            Console.WriteLine("Cancelling");
            return null;
        }
        return fields;
    }
    public override void Add()
    {
        Query q;
        string name;
        FieldSet fs;
        List<Field>? fields;
        int output;

        // Name query
        name = NamePrompt(EntityType);
        fs = SelectFieldSet();
        fields = SelectFields(fs);
        if (fields is null) return;
        var query = new Query { Name = name, FieldSet = fs, Fields = fields };
        bool isValid;
        ConsoleKey input;
        do
        {
            Console.WriteLine("Would you like to add a filter to this query? (y / n)");
            input = Console.ReadKey().Key;
            isValid = input == ConsoleKey.Y || input == ConsoleKey.N;
        } while (!isValid);
        Console.WriteLine();
        if (input == ConsoleKey.N)
        //create query with no filter
        {
            output = S.AddQuery(name, fs, fields);
            Console.WriteLine("Changed " + output + " rows.");
            return;
        }
        List<Criterion> critera = CreateCriteria(fs);
        List<Statement> statements = new List<Statement>();
        foreach (var criterion in critera)
        {
            var criteria = new List<Criterion>();
            criteria.Add(criterion);
            statements.Add(new Statement() { Criteria = criteria });
        }
        Statement statement = CreateTopLevelStatement(statements);

        output = S.AddQuery(name, fs, fields, statement);

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine($"Changed {output} rows");
    }

    private Statement CreateTopLevelStatement(List<Statement> statements)
    {
        Statement output;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Now, combine those criteria into a single statement using conjunctions. ");
        Console.WriteLine("Start with the inner-most conjunctions and then create the higher level ones.");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Ex. ((Customer = Hurom AND Model = 1234) OR (Customer = Galanz AND Model = 5678)) AND [Date Received] WEEKSAGO(1)");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\n***\n");
            
        output = CreateConjunction(statements);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Created Conjunction: {output.ToString()}");
        Console.WriteLine();

        return output;
    }

    private Statement CreateConjunction(List<Statement> statements)
    {
        Statement output;
        Conjunction conj;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("First, select a conjoiner.");
        List<Conjoiner> conjoiners = S.GetConjoiners();
        Conjoiner cjr = SelectConjoiner();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Now select criteria to add to this conjunction.");
        Console.ForegroundColor = ConsoleColor.Cyan;
        List<Statement> selection = new List<Statement>();
        // Select criteria for conjunction
        do
        {
            Statement? st;
            do
            {
                st = SelectFromList(statements);
            } while (st is null);
            selection.Add(st);
            statements.Remove(st);
            if (statements.Count == 0) break;
            ConsoleKey input;
            Console.ForegroundColor = ConsoleColor.Yellow;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Add more? (y/n)");
                input = Console.ReadKey().Key;
                Console.WriteLine();

            } while (input != ConsoleKey.Y && input != ConsoleKey.N);
            if (input == ConsoleKey.N) break; 
        } while (true);

        // Declare Conjunction
        conj = new Conjunction() { Conjoiner = cjr, Statements = selection };

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine($"Created conjunction: {conj.ToString()}");

        var conjs = new List<Conjunction>();
        conjs.Add(conj);
        output = new Statement() { Conjunctions = conjs };

        // Loop recursively until no "loose" criteria exist
        if (statements.Count != 0)
        {
            Console.WriteLine("Some criteria are not contained yet. Another conjunction will be needed.");
            statements.Add(output);
            return CreateConjunction(statements);
        }

        return output;

        // Funcs
        Conjoiner SelectConjoiner()
        {
            Conjoiner? output;
            do
            {
                output = SelectFromList(conjoiners);
            } while (output is null);
            return output;
        }
    }

    private List<Criterion> CreateCriteria(FieldSet fs)
    {
        List<Criterion> output = new List<Criterion>();
        Console.WriteLine("First, you will create the base operations for the filter by choosing fields ands operations to perform. Next,");
        Console.WriteLine("you will combine the criteria into one statement using conjunctions.");
        do
        {
            output.Add(CreateCriterion(fs));
            Console.WriteLine($"Created criterion: {output.Last().ToString()}");
            Console.WriteLine("Current criteria:");
            for (int i = 0; i < output.Count; i++)
            {
                Criterion? crit = output[i];
                Console.WriteLine($"{i}.{crit.ToString()}");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Create more? (y/n)");
            var input = Console.ReadKey().Key;
            if (input == ConsoleKey.N) return output;
        } while (true);


        Criterion CreateCriterion(FieldSet fs)
        {
            Field? field;
            SqlDbType dbType;
            field = SelectField(fs);
            dbType = field.DbType;
            Operator? op = SelectOperator(dbType);
            List<Parameter> parameters = op.Parameters;
            List<CriterionParameter> cParams = CreateCritParameters(op, parameters);
            return new Criterion()
            {
                Field = field,
                CriterionParameters = cParams,
                Operator = op
            };
        }
        static Field SelectField(FieldSet fs)
        {
            Field? field;
            do
            {
                Console.WriteLine("Choose a field to filter on.");
                field = SelectFromList(fs.Fields);
            } while (field is null);
            return field;
        }
        Operator SelectOperator(SqlDbType dbType)
        {
            List<Operator> ops = S.GetOperators(dbType);
            Operator? op;
            do
            {
                Console.WriteLine("Select an operation to perform");
                op = SelectFromList(ops);
            } while (op is null);
            return op;
        }
        static List<CriterionParameter> CreateCritParameters(Operator op, List<Parameter> parameters)
        {
            List<CriterionParameter> cParams = new List<CriterionParameter>();
            foreach (Parameter param in parameters)
            {
                Console.WriteLine($"Input value for {op.Name} {param.Name}");
                string val = Console.ReadLine();
                cParams.Add(new CriterionParameter() { Parameter = param, Value = val });
            }

            return cParams;
        }
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
        Console.WriteLine("And a combination of conditions can be used to filter rows returned.");
    }

    public override void ShowAll()
    {
        throw new NotImplementedException();
    }
}