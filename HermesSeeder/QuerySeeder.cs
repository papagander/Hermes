using Domain;
using Domain.Models.DataCore;
using Domain.Models.FieldSets;
using Domain.Models.Queries;

using HermesSeeder.Interfaces;

using Microsoft.EntityFrameworkCore;

using Services;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HermesSeeder;
public class QuerySeeder
    : ISeeder
{
    ReportContext Context;
    public QuerySeeder(ReportContext reportContext)
    {
        Context = reportContext;
    }
    private bool disposedValue;

    public void Seed()
    {
        Context.Database.ExecuteSqlRaw("DELETE FROM Query");
        Context.Database.ExecuteSqlRaw("DELETE FROM OperationParameter");
        Context.Database.ExecuteSqlRaw("DELETE FROM Operation");
        Context.Database.ExecuteSqlRaw("DELETE FROM Statement");
        Context.Database.ExecuteSqlRaw("DELETE FROM Conjunction");
        Context.Database.ExecuteSqlRaw("DELETE FROM FieldQuery");
        QueryService S = new(Context);
        S.AddQuery(QueryZero(S));
    }
    public Query QueryZero(QueryService S)
    {
        // Query Name
        string name;
        // Query FieldSet
        FieldSet fs;
        // Query Fields
        List<Field> fds = new();
        // Query Statement
        Statement stat = QueryZeroFilter(S);
        
        name = "Test Query 0";
        fs = S.GetFieldSet(FieldSetSeeder.DevicesSet.Name);
        fds = fs.Fields;
        return new Query() { Name = name, FieldSet = fs, Fields = fds, Statement = stat};
    }

    public Statement QueryZeroFilter(QueryService S)
    {
        // Returns a statement which is interpreted as
        // "(
        // ( department is 'Chemistry' AND Category is 'Laptop')
        // OR (department is 'SCCS' AND Category is 'Monitor')
        // ) AND WeeksAgo(1)"
        Statement output;

        // Combine our two product info conditions
        List<Statement> orStats = new();
        orStats.Add(ChemistryLaptops(S));
        orStats.Add(CompSciMonitors(S));
        var prodStat = new Conjunction() { Conjoiner = S.GetConjoiner(DataCoreSeeder.OR), Statements = orStats}.ToStatement();

        // Get date condition
        Statement dateStatement = OneWeeksAgo(S);

        // Create List of statements for top conj - {PRODUCT_INFO} AND {DATE_CONDITION}
        var stats = new List<Statement>();
        stats.Add(prodStat);
        stats.Add(OneWeeksAgo(S));

        // Instantiate top level statement + return
        return new Conjunction() {Conjoiner = S.GetConjoiner(DataCoreSeeder.AND), Statements = stats}.ToStatement();
    }

    public static Statement ChemistryLaptops(QueryService S)
    {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        Statement output;
        // Statements joined under the and
        List<Statement> andStatements = new();

        // "And" object
        Conjunction and;

        // Operations joined under the and
        Operation departmentOpn;
        Operation categoryOpn;

        // Fields to perform operation on
        Field departmentField;
        Field categoryField;

        // Fieldset the fds are in
        FieldSet fs;

        // "Is" operator
        Operator opr;

        // Parameter lists for operations
        List<OperationParameter> departmentParameters = new();
        List<OperationParameter> categoryParameters = new();

        // Operation Parameters
        OperationParameter departmentParameter;
        OperationParameter categoryParameter;

        // Statements to contain operations
        Statement categoryStatement;
        Statement departmentStatement;



        // Get Is Operator
        opr = S.GetOperators(SqlDbType.VarChar).FirstOrDefault(opr => opr.Name.ToLower().Contains("is"));
        // Get Device Table
        fs = S.GetFieldSet(FieldSetSeeder.DEVICES);
        // Get department and Category columns
        departmentField = fs.Fields.FirstOrDefault(f => f.Name.Contains("Department"));
        categoryField = fs.Fields.FirstOrDefault(f => f.Name.Contains("Category"));


        departmentParameter = new OperationParameter() { Parameter = opr.Parameters[0], Value = "Chemistry" };
        categoryParameter = new OperationParameter() { Parameter = opr.Parameters[0], Value = "Laptop" };
        departmentParameters.Add(departmentParameter);
        categoryParameters.Add(categoryParameter);
        departmentOpn = new Operation() { Field = departmentField, Operator = opr, OperationParameters = departmentParameters};
        categoryOpn = new Operation() { Field = categoryField, Operator = opr, OperationParameters = categoryParameters};
        departmentStatement = new Statement() { Operation = departmentOpn };
        categoryStatement = new Statement() { Operation = categoryOpn };
        andStatements.Add(departmentStatement);
        andStatements.Add(categoryStatement);
        return new Conjunction() {Conjoiner = S.GetConjoiner(DataCoreSeeder.AND), Statements = andStatements }.ToStatement();

#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }

    public static Statement CompSciMonitors(QueryService S)
    {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.

        Statement output;
        // Statements joined under the and
        List<Statement> andStatements = new();

        // "And" object
        Conjunction and;

        // Operations joined under the and
        Operation departmentOpn;
        Operation categoryOpn;

        // Fields to perform operation on
        Field departmentField;
        Field categoryField;

        // Fieldset the fds are in
        FieldSet fs;

        // "Is" operator
        Operator opr;

        // Parameter lists for operations
        List<OperationParameter> departmentParameters = new();
        List<OperationParameter> categoryParameters = new();

        // Operation Parameters
        OperationParameter departmentParameter;
        OperationParameter categoryParameter;

        // Statements to contain operations
        Statement categoryStatement;
        Statement departmentStatement;



        // Get Is Operator
        opr = S.GetOperators(SqlDbType.VarChar).FirstOrDefault(opr => opr.Name.ToLower().Contains("is"));
        // Get Receiving Table
        fs = S.GetFieldSet(FieldSetSeeder.DEVICES);
        // Get department and Category columns
        departmentField = fs.Fields.FirstOrDefault(f => f.Name.ToLower().Contains("department"));
        categoryField = fs.Fields.FirstOrDefault(f => f.Name.ToLower().Contains("category"));


        departmentParameter = new OperationParameter() { Parameter = opr.Parameters[0], Value = "SCCS" };
        categoryParameter = new OperationParameter() { Parameter = opr.Parameters[0], Value = "Monitor" };
        departmentParameters.Add(departmentParameter);
        categoryParameters.Add(categoryParameter);
        departmentOpn = new Operation() { Field = departmentField, Operator = opr, OperationParameters = departmentParameters };
        categoryOpn = new Operation() { Field = categoryField, Operator = opr, OperationParameters = categoryParameters };
        departmentStatement = new Statement() { Operation = departmentOpn };
        categoryStatement = new Statement() { Operation = categoryOpn };
        andStatements.Add(departmentStatement);
        andStatements.Add(categoryStatement);
        return new Conjunction() { Conjoiner = S.GetConjoiner(DataCoreSeeder.AND), Statements = andStatements }.ToStatement();

#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
    public static Statement OneWeeksAgo(QueryService S)
    {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        
        // Field to perform operation on
        Field dateReceivedField;

        // Fieldset the field is in
        FieldSet fs;

        // "Is" operator
        Operator opr;

        // Parameter list for operation
        List<OperationParameter> weeksAgoParams = new();

        // Operation Parameter
        OperationParameter weeksAgoParameter;

        // Get Is Operator
        opr = S.GetOperators(SqlDbType.Date).FirstOrDefault(opr => opr.Name == "isWeeksAgo");
        // Get Receiving Table
        fs = S.GetFieldSet(FieldSetSeeder.DEVICES);
        // Get date received field
        dateReceivedField = S.GetField(fs, "Deployment Date");

        // Create operation parameter entities
        weeksAgoParameter = new OperationParameter() { Parameter = opr.Parameters[0], Value = "1" };

        // Add parameters to parameter lists (1 each)
        weeksAgoParams.Add(weeksAgoParameter);

        // Instantiate + return
        return new Operation() { Field = dateReceivedField, Operator = opr, OperationParameters = weeksAgoParams }.ToStatement();
        

#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                //Context.Dispose();
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fds to null
            disposedValue = true;
        }
    }

    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    // ~QuerySeeder()
    // {
    //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    //     Dispose(disposing: false);
    // }

    void IDisposable.Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}