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
    public const int AND = 1;
    public const int OR = 2;
    public const int NOR = 3;
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
    public void DeleteQueries()
    {
        Context.Database.ExecuteSqlRaw("DELETE FROM Query");
        Context.Database.ExecuteSqlRaw("DELETE FROM OperationParameter");
        Context.Database.ExecuteSqlRaw("DELETE FROM Operation");
        Context.Database.ExecuteSqlRaw("DELETE FROM Conjunction");
        Context.Database.ExecuteSqlRaw("DELETE FROM Statement");
        Context.Database.ExecuteSqlRaw("DELETE FROM FieldQuery");


    }
    public void DeletFieldSets()
    {
        Context.Database.ExecuteSqlRaw("DELETE FROM FieldSet");
        Context.Database.ExecuteSqlRaw("DELETE FROM Field");

    }
    void SeedConjoiners()
    {
        Context.Database.ExecuteSqlRaw("DELETE FROM Conjoiner");
        S.AddConjoiner("AND");
        S.AddConjoiner("OR");
    }
    void SeedOperators()
    {

        Context.Database.ExecuteSqlRaw("DELETE FROM Operator");
        Context.Database.ExecuteSqlRaw("DELETE FROM OperatorFieldType");
        Context.Database.ExecuteSqlRaw("DELETE FROM Parameter");
        int i = 0;
        Operator op;
        List<SqlDbType> dbTypes;

        // Equals - Numeric
        op = BaseOperators[i];
        dbTypes = new List<SqlDbType>();
        dbTypes.AddRange(Numeric);
        S.AddOperator(op.Name, op.ExecutionString, dbTypes, op.Parameters);
        i++;

        // Is - Textual
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

        // Is not - Textual
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

        // Greater Than Or Equal - time
        op = BaseOperators[i];
        dbTypes = new List<SqlDbType>();
        dbTypes.AddRange(Temporal);
        S.AddOperator(op.Name, op.ExecutionString, dbTypes, op.Parameters);
        i++;

        // Contains
        op = BaseOperators[i];
        dbTypes = new List<SqlDbType>();
        dbTypes.AddRange(Textual);
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
            executionString = "/*FIELD_NAME*/ = /*p0*/";
            paramName = "value";
            paramType = null;
            _1 = new Parameter() { Name = paramName, DbType = paramType };
            parameters = new List<Parameter>();
            parameters.Add(_1);
            op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
            output.Add(op);


            name = "is";
            executionString = "/*FIELD_NAME*/ = '/*p0*/'";
            paramName = "value";
            paramType = SqlDbType.VarChar;
            _1 = new Parameter() { Name = paramName, DbType = paramType };
            parameters = new List<Parameter>();
            parameters.Add(_1);
            op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
            output.Add(op);


            name = "not equals";
            executionString = "/*FIELD_NAME*/ <> /*p0*/";
            paramName = "value";
            paramType = null;
            _1 = new Parameter() { Name = paramName, DbType = paramType };
            parameters = new List<Parameter>();
            parameters.Add(_1);
            op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
            output.Add(op);


            name = "is not";
            executionString = "/*FIELD_NAME*/ <> '/*p0*/'";
            paramName = "value";
            paramType = SqlDbType.VarChar;
            _1 = new Parameter() { Name = paramName, DbType = paramType };
            parameters = new List<Parameter>();
            parameters.Add(_1);
            op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
            output.Add(op);


            name = "less than";
            executionString = "/*FIELD_NAME*/ < /*p0*/";
            paramName = "value";
            paramType = null;
            _1 = new Parameter() { Name = paramName, DbType = paramType };
            parameters = new List<Parameter>();
            parameters.Add(_1);
            op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
            output.Add(op);


            name = "less than";
            executionString = "/*FIELD_NAME*/ < '/*p0*/'";
            paramName = "value";
            paramType = SqlDbType.VarChar;
            _1 = new Parameter() { Name = paramName, DbType = paramType };
            parameters = new List<Parameter>();
            parameters.Add(_1);
            op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
            output.Add(op);

            name = "greater than";
            executionString = "/*FIELD_NAME*/ > /*p0*/";
            paramName = "0";
            paramType = null;
            _1 = new Parameter() { Name = paramName, DbType = paramType };
            parameters = new List<Parameter>();
            parameters.Add(_1);
            op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
            output.Add(op);


            name = "greater than";
            executionString = "/*FIELD_NAME*/ > '/*p0*/'";
            paramName = "0";
            paramType = SqlDbType.VarChar;
            _1 = new Parameter() { Name = paramName, DbType = paramType };
            parameters = new List<Parameter>();
            parameters.Add(_1);
            op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
            output.Add(op);



            name = "less than or equal";
            executionString = "/*FIELD_NAME*/ <= /*p0*/";
            paramName = "value";
            paramType = null;
            _1 = new Parameter() { Name = paramName, DbType = paramType };
            parameters = new List<Parameter>();
            parameters.Add(_1);
            op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
            output.Add(op);

            name = "less than or equal";
            executionString = "/*FIELD_NAME*/ <= '/*p0*/'";
            paramName = "value";
            paramType = SqlDbType.VarChar;
            _1 = new Parameter() { Name = paramName, DbType = paramType };
            parameters = new List<Parameter>();
            parameters.Add(_1);
            op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
            output.Add(op);



            name = "greater than or equal";
            executionString = "/*FIELD_NAME*/ >= /*p0*/";
            paramName = "value";
            paramType = null;
            _1 = new Parameter() { Name = paramName, DbType = paramType };
            parameters = new List<Parameter>();
            parameters.Add(_1);
            op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
            output.Add(op);

            name = "greater than or equal";
            executionString = "/*FIELD_NAME*/ >= '/*p0*/'";
            paramName = "value";
            paramType = SqlDbType.VarChar;
            _1 = new Parameter() { Name = paramName, DbType = paramType };
            parameters = new List<Parameter>();
            parameters.Add(_1);
            op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
            output.Add(op);

            name = "contains";
            executionString = "/*FIELD_NAME*/ LIKE '%/*p0*/%'";
            paramName = "substring";
            paramType = SqlDbType.Int;
            _1 = new Parameter() { Name = paramName, DbType = paramType };
            parameters = new List<Parameter>();
            parameters.Add(_1);
            op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
            output.Add(op);


            name = "isWeeksAgo";
            executionString = "(firstDate <= /*FIELD_NAME*/ AND lastDate >= /*FIELD_NAME*/)";
            executionString = executionString.Replace("firstDate", "DATEADD(week, -/*p0*/, DATEADD(day, 1 - DATEPART(dw, DATEFROMPARTS(DATEPART(year, GETDATE()), DATEPART(month, GETDATE()), DATEPART(day, GETDATE()))), DATEFROMPARTS(DATEPART(year, GETDATE()), DATEPART(month, GETDATE()), DATEPART(day, GETDATE()))))");
            executionString = executionString.Replace("lastDate", "DATEADD(day, 6, DATEADD(week, -/*p0*/, DATEADD(day, 1 - DATEPART(dw, DATEFROMPARTS(DATEPART(year, GETDATE()), DATEPART(month, GETDATE()), DATEPART(day, GETDATE()))), DATEFROMPARTS(DATEPART(year, GETDATE()), DATEPART(month, GETDATE()), DATEPART(day, GETDATE())))))");
            paramName = "weeks-back";
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
                //Context.Dispose();
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