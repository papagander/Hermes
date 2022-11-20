using Domain;
using Domain.Models.DataCore;

using HermesSeeder.Interfaces;

using Microsoft.EntityFrameworkCore;

using Services;

using System.Data;
using System.Net;

namespace HermesSeeder;
public class DataCoreSeeder
    : ISeeder
{
    private bool disposedValue;
    ReportContext Context;
    DataCoreService S { get; set; }
    public DataCoreSeeder(ReportContext context)
    {
        Context = context;
        S = new DataCoreService(Context);
    }
    public void Seed()
    {
        SeedOperators();
        SeedConjoiners();
    }
    void SeedConjoiners()
    {
        Context.Database.ExecuteSqlRaw("DELETE FROM Conjoiner");
        S.AddConjoiner("and");
        S.AddConjoiner("or");
        S.AddConjoiner("nor");
    }
    void SeedOperators()
    {

        Context.Database.ExecuteSqlRaw("DELETE FROM Operator");
        int i = 0;
        Operator op;
        List<SqlDbType> dbTypes;

        // Equals - Numeric
        op = BaseOperators[i];
        dbTypes = new List<SqlDbType>();
        dbTypes.AddRange(Numeric);
        S.AddOperator(op.Name, op.ExecutionString, dbTypes, op.Parameters);
        i++;

        // Equals - Textual
        op = BaseOperators[i];
        dbTypes = new List<SqlDbType>();
        dbTypes.AddRange(Temporal);
        dbTypes.AddRange(Textual);
        S.AddOperator(op.Name, op.ExecutionString, dbTypes, op.Parameters);
        i++;

        // Not Equals - Numeric
        op = BaseOperators[i];
        dbTypes = new List<SqlDbType>();
        dbTypes.AddRange(Numeric);
        S.AddOperator(op.Name, op.ExecutionString, dbTypes, op.Parameters);
        i++;

        // Not Equals - Textual
        op = BaseOperators[i];
        dbTypes = new List<SqlDbType>();
        dbTypes.AddRange(Temporal);
        dbTypes.AddRange(Textual);
        S.AddOperator(op.Name, op.ExecutionString, dbTypes, op.Parameters);
        i++;

        // Less Than - Numeric
        op = BaseOperators[i];
        dbTypes = new List<SqlDbType>();
        dbTypes.AddRange(Numeric);
        S.AddOperator(op.Name, op.ExecutionString, dbTypes, op.Parameters);
        i++;

        // Less Than - Textual
        op = BaseOperators[i];
        dbTypes = new List<SqlDbType>();
        dbTypes.AddRange(Temporal);
        S.AddOperator(op.Name, op.ExecutionString, dbTypes, op.Parameters);
        i++;

        // Greater Than - Numeric
        op = BaseOperators[i];
        dbTypes = new List<SqlDbType>();
        dbTypes.AddRange(Numeric);
        S.AddOperator(op.Name, op.ExecutionString, dbTypes, op.Parameters);
        i++;

        // Greater Than - Textual
        op = BaseOperators[i];
        dbTypes = new List<SqlDbType>();
        dbTypes.AddRange(Temporal);
        S.AddOperator(op.Name, op.ExecutionString, dbTypes, op.Parameters);
        i++;

        // Less Than Or Equal - Numeric
        op = BaseOperators[i];
        dbTypes = new List<SqlDbType>();
        dbTypes.AddRange(Numeric);
        S.AddOperator(op.Name, op.ExecutionString, dbTypes, op.Parameters);
        i++;

        // Less Than Or Equal - Textual
        op = BaseOperators[i];
        dbTypes = new List<SqlDbType>();
        dbTypes.AddRange(Temporal);
        S.AddOperator(op.Name, op.ExecutionString, dbTypes, op.Parameters);
        i++;

        // Greater Than Or Equal - Numeric
        op = BaseOperators[i];
        dbTypes = new List<SqlDbType>();
        dbTypes.AddRange(Numeric);
        S.AddOperator(op.Name, op.ExecutionString, dbTypes, op.Parameters);
        i++;

        // Greater Than Or Equal - Textual
        op = BaseOperators[i];
        dbTypes = new List<SqlDbType>();
        dbTypes.AddRange(Temporal);
        S.AddOperator(op.Name, op.ExecutionString, dbTypes, op.Parameters);
        i++;

        // Weeks Ago
        op = BaseOperators[i];
        dbTypes = new List<SqlDbType>();
        dbTypes.AddRange(Temporal);
        S.AddOperator(op.Name, op.ExecutionString, dbTypes, op.Parameters);
    }
    public static List<Operator> BaseOperators
    {
        get
        {
            var output = new List<Operator>();
            Operator op;
            string name;
            string executionString;
            string paramName;
            SqlDbType? paramType;
            List<Parameter> parameters;
            Parameter _1;


            name = "equals";
            executionString = "{ASDF} = {0}";
            paramName = "value";
            paramType = null;
            _1 = new Parameter() { Name = paramName, DbType = paramType };
            parameters = new List<Parameter>();
            parameters.Add(_1);
            op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
            output.Add(op);


            name = "is";
            executionString = "{ASDF} = '{0}'";
            paramName = "value";
            paramType = SqlDbType.VarChar;
            _1 = new Parameter() { Name = paramName, DbType = paramType };
            parameters = new List<Parameter>();
            parameters.Add(_1);
            op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
            output.Add(op);


            name = "not equals";
            executionString = "{ASDF} <> {0}";
            paramName = "value";
            paramType = null;
            _1 = new Parameter() { Name = paramName, DbType = paramType };
            parameters = new List<Parameter>();
            parameters.Add(_1);
            op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
            output.Add(op);


            name = "is not";
            executionString = "{ASDF} <> '{0}'";
            paramName = "value";
            paramType = SqlDbType.VarChar;
            _1 = new Parameter() { Name = paramName, DbType = paramType };
            parameters = new List<Parameter>();
            parameters.Add(_1);
            op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
            output.Add(op);


            name = "less than";
            executionString = "{ASDF} < {0}";
            paramName = "value";
            paramType = null;
            _1 = new Parameter() { Name = paramName, DbType = paramType };
            parameters = new List<Parameter>();
            parameters.Add(_1);
            op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
            output.Add(op);


            name = "less than";
            executionString = "{ASDF} < '{0}'";
            paramName = "value";
            paramType = SqlDbType.VarChar;
            _1 = new Parameter() { Name = paramName, DbType = paramType };
            parameters = new List<Parameter>();
            parameters.Add(_1);
            op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
            output.Add(op);

            name = "greater than";
            executionString = "{ASDF} > {0}";
            paramName = "0";
            paramType = null;
            _1 = new Parameter() { Name = paramName, DbType = paramType };
            parameters = new List<Parameter>();
            parameters.Add(_1);
            op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
            output.Add(op);


            name = "greater than";
            executionString = "{ASDF} > '{0}'";
            paramName = "0";
            paramType = SqlDbType.VarChar;
            _1 = new Parameter() { Name = paramName, DbType = paramType };
            parameters = new List<Parameter>();
            parameters.Add(_1);
            op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
            output.Add(op);



            name = "less than or equal";
            executionString = "{ASDF} <= {0}";
            paramName = "value";
            paramType = null;
            _1 = new Parameter() { Name = paramName, DbType = paramType };
            parameters = new List<Parameter>();
            parameters.Add(_1);
            op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
            output.Add(op);

            name = "less than or equal";
            executionString = "{ASDF} <= '{0}'";
            paramName = "value";
            paramType = SqlDbType.VarChar;
            _1 = new Parameter() { Name = paramName, DbType = paramType };
            parameters = new List<Parameter>();
            parameters.Add(_1);
            op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
            output.Add(op);



            name = "greater than or equal";
            executionString = "{ASDF} >= {0}";
            paramName = "value";
            paramType = null;
            _1 = new Parameter() { Name = paramName, DbType = paramType };
            parameters = new List<Parameter>();
            parameters.Add(_1);
            op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
            output.Add(op);

            name = "greater than or equal";
            executionString = "{ASDF} >= '{0}'";
            paramName = "value";
            paramType = SqlDbType.VarChar;
            _1 = new Parameter() { Name = paramName, DbType = paramType };
            parameters = new List<Parameter>();
            parameters.Add(_1);
            op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
            output.Add(op);


            name = "weeks ago";
            executionString = "SELECT DATEPART(WEEKDAY, GETDATE())";
            paramName = "weeksBack";
            paramType = SqlDbType.Int;
            _1 = new Parameter() { Name = paramName, DbType = paramType };
            parameters = new List<Parameter>();
            parameters.Add(_1);
            op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
            output.Add(op);


            return output;
        }
    }
    protected static List<SqlDbType> Numeric
    {
        get
        {
            var output = new List<SqlDbType>();
            output.Add(SqlDbType.Int);
            output.Add(SqlDbType.SmallInt);
            output.Add(SqlDbType.BigInt);
            output.Add(SqlDbType.Decimal);
            output.Add(SqlDbType.Float);
            output.Add(SqlDbType.Money);
            output.Add(SqlDbType.SmallMoney);
            output.Add(SqlDbType.Real);
            return output;
        }
    }
    protected static List<SqlDbType> Textual
    {
        get
        {
            var output = new List<SqlDbType>();
            output.Add(SqlDbType.Text);
            output.Add(SqlDbType.NText);
            output.Add(SqlDbType.VarChar);
            output.Add(SqlDbType.NVarChar);
            output.Add(SqlDbType.NChar);
            return output;
        }
    }
    protected static List<SqlDbType> Temporal
    {
        get
        {
            var output = new List<SqlDbType>();
            output.Add(SqlDbType.Date);
            output.Add(SqlDbType.DateTime);
            output.Add(SqlDbType.DateTime2);
            return output;
        }
    }
    
    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    // ~DataCoreSeeder()
    // {
    //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    //     Dispose(disposing: false);
    // }
    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                Context.Dispose();
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            disposedValue = true;
        }
    }
    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}