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

    protected override string MenuName { get => "Query"; }
    protected override string EntityType { get => "Query"; }

    List<Field>? SelectFields(FieldSet fs)
    {
        var fields = new List<Field>();
        var allFields = fs.Fields;
        Console.ForegroundColor = ConsoleColor.Yellow;
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
        string name;
        FieldSet fs;
        List<Field>? fields;
        int output;


        Console.Clear();
        AddQueryPrompt();
        // Name query
        Console.ForegroundColor = ConsoleColor.Yellow;
        name = NamePrompt(EntityType);
        Console.WriteLine();
        // Select source table
        fs = SelectFieldSet();
        // Select columns to show on report
        fields = SelectFields(fs);
        if (fields is null) return;
        bool isValid;
        ConsoleKey input;
        do
        {
            Console.Clear();
            Console.WriteLine();
            DisplayQuery(name ,fs, fields);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Would you like to add a filter to this query? (y / n)");
            Console.ForegroundColor = ConsoleColor.White;
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
        List<Operation> operations = CreateOperations(fs);
        List<Statement> statements = new List<Statement>();
        foreach (var operation in operations)
        {
            statements.Add(new Statement() { Operation = operation });
        }
        Statement statement = CreateTopLevelStatement(statements);

        output = S.AddQuery(name, fs, fields, statement);

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine($"Changed {output} rows");
    }

    private void AddQueryPrompt()
    {
        Console.Clear();
    }
    private void DisplayQuery(string name, FieldSet fs, IEnumerable<Field> fields)
    {

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Query name: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(name);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Source Table: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(fs);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Columns: ");
        Console.ForegroundColor = ConsoleColor.Gray;
        foreach (Field field in fields) Console.Write($"{field.Name}, ");
        Console.WriteLine("\n");
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
        Console.WriteLine($"Created ParentConjunction: {output.ToString()}");
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

        // Declare ParentConjunction
        conj = new Conjunction() { Conjoiner = cjr, Statements = selection };

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine($"Created conjunction: {conj.ToString()}");
        output = new Statement() { Conjunction = conj };

        // Loop recursively until no "loose" criteria exist
        if (statements.Count != 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Some criteria are not contained yet. Another conjunction will be needed.");
            Console.ForegroundColor = ConsoleColor.White;
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

    private List<Operation> CreateOperations(FieldSet fs)
    {
        List<Operation> output = new List<Operation>();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Clear();
        Console.WriteLine("Create the base operations for the filter by choosing fields ands operations to perform. Next,");
        Console.WriteLine("you will combine the criteria into one statement using conjunctions.");
        Console.WriteLine("\n");
        Console.ForegroundColor = ConsoleColor.White;
        do
        {
            output.Add(CreateCriterion(fs));
            Console.WriteLine($"Created operation: {output.Last().ToString()}");
            Console.WriteLine("Current criteria:");
            for (int i = 0; i < output.Count; i++)
            {
                Operation? crit = output[i];
                Console.WriteLine($"{i}.{crit.ToString()}");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Create more? (y/n)");
            Console.ForegroundColor = ConsoleColor.White;
            var input = Console.ReadKey().Key;
            if (input == ConsoleKey.N) return output;
        } while (true);


        Operation CreateCriterion(FieldSet fs)
        {
            Field? field;
            SqlDbType dbType;  
            field = SelectField(fs);
            dbType = field.DbType;
            Operator? op = SelectOperator(dbType);
            List<Parameter> parameters = op.Parameters;
            List<OperationParameter> cParams = CreateCritParameters(op, parameters);
            return new Operation()
            {
                Field = field,
                OperationParameters = cParams,
                Operator = op
            };
        }
        static Field SelectField(FieldSet fs)
        {
            Field? field;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
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
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Select an operation to perform");
                op = SelectFromList(ops);
            } while (op is null);
            return op;
        }
        static List<OperationParameter> CreateCritParameters(Operator op, List<Parameter> parameters)
        {
            List<OperationParameter> cParams = new List<OperationParameter>();
            foreach (Parameter param in parameters)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Input value for {op.Name} {param.Name}");
                string val = Console.ReadLine();
                cParams.Add(new OperationParameter() { Parameter = param, Value = val });

            }
            return cParams;
        }
    }

    FieldSet? SelectFieldSet()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Select a source table for this query.");
        var _fsz = S.GetFieldSets().ToList();
        return SelectFromList(_fsz);
    }
    public override void ShowAll()
    {
        var qs = S.GetQueries();
        foreach (var query in qs)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(query.Name);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(query.FieldSet);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(query.ExecutionString);

        }
    }
}