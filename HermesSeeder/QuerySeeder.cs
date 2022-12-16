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
        Context.Database.ExecuteSqlRaw("DELETE FROM Conjunction");
        Context.Database.ExecuteSqlRaw("DELETE FROM Statement");
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
        fs = S.GetFieldSet(FieldSetSeeder.ReceivingSet.Name);
        fds = fs.Fields;
        return new Query() { Name = name, FieldSet = fs, Fields = fds, Statement = stat};
    }

    public Statement QueryZeroFilter(QueryService S)
    {
        // Returns a statement which is interpreted as
        // "(
        // ( Customer is 'Capital Brands' AND Category is 'Vaccuum Cleaner')
        // OR (Customer is 'Galanz' AND Category is 'Microwave')
        // ) AND WeeksAgo(1)"
        Statement output;

        // Combine our two product info conditions
        List<Statement> orStats = new();
        orStats.Add(CapitalBrandsVaccuums(S));
        orStats.Add(GalanzMicrowaves(S));
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

    public static Statement CapitalBrandsVaccuums(QueryService S)
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
        Operation customerOpn;
        Operation categoryOpn;

        // Fields to perform operation on
        Field customerField;
        Field categoryField;

        // Fieldset the fds are in
        FieldSet fs;

        // "Is" operator
        Operator opr;

        // Parameter lists for operations
        List<OperationParameter> customerParameters = new();
        List<OperationParameter> categoryParameters = new();

        // Operation Parameters
        OperationParameter customerParameter;
        OperationParameter categoryParameter;

        // Statements to contain operations
        Statement categoryStatement;
        Statement customerStatement;



        // Get Is Operator
        opr = S.GetOperators(SqlDbType.VarChar).FirstOrDefault(opr => opr.Name.ToLower().Contains("is"));
        // Get Receiving Table
        fs = S.GetFieldSet(FieldSetSeeder.RECEIVING);
        // Get Customer and Category columns
        customerField = fs.Fields.FirstOrDefault(f => f.Name.Contains("Customer"));
        categoryField = fs.Fields.FirstOrDefault(f => f.Name.Contains("Category"));


        customerParameter = new OperationParameter() { Parameter = opr.Parameters[0], Value = "Capital Brands" };
        categoryParameter = new OperationParameter() { Parameter = opr.Parameters[0], Value = "Vaccuums" };
        customerParameters.Add(customerParameter);
        categoryParameters.Add(categoryParameter);
        customerOpn = new Operation() { Field = customerField, Operator = opr, OperationParameters = customerParameters};
        categoryOpn = new Operation() { Field = categoryField, Operator = opr, OperationParameters = categoryParameters};
        customerStatement = new Statement() { Operation = customerOpn };
        categoryStatement = new Statement() { Operation = categoryOpn };
        andStatements.Add(customerStatement);
        andStatements.Add(categoryStatement);
        return new Conjunction() {Conjoiner = S.GetConjoiner(DataCoreSeeder.AND), Statements = andStatements }.ToStatement();

#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }

    public static Statement GalanzMicrowaves(QueryService S)
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
        Operation customerOpn;
        Operation categoryOpn;

        // Fields to perform operation on
        Field customerField;
        Field categoryField;

        // Fieldset the fds are in
        FieldSet fs;

        // "Is" operator
        Operator opr;

        // Parameter lists for operations
        List<OperationParameter> customerParameters = new();
        List<OperationParameter> categoryParameters = new();

        // Operation Parameters
        OperationParameter customerParameter;
        OperationParameter categoryParameter;

        // Statements to contain operations
        Statement categoryStatement;
        Statement customerStatement;



        // Get Is Operator
        opr = S.GetOperators(SqlDbType.VarChar).FirstOrDefault(opr => opr.Name.ToLower().Contains("is"));
        // Get Receiving Table
        fs = S.GetFieldSet(FieldSetSeeder.RECEIVING);
        // Get Customer and Category columns
        customerField = fs.Fields.FirstOrDefault(f => f.Name.ToLower().Contains("customer"));
        categoryField = fs.Fields.FirstOrDefault(f => f.Name.ToLower().Contains("category"));


        customerParameter = new OperationParameter() { Parameter = opr.Parameters[0], Value = "Galanz" };
        categoryParameter = new OperationParameter() { Parameter = opr.Parameters[0], Value = "Microwaves" };
        customerParameters.Add(customerParameter);
        categoryParameters.Add(categoryParameter);
        customerOpn = new Operation() { Field = customerField, Operator = opr, OperationParameters = customerParameters };
        categoryOpn = new Operation() { Field = categoryField, Operator = opr, OperationParameters = categoryParameters };
        customerStatement = new Statement() { Operation = customerOpn };
        categoryStatement = new Statement() { Operation = categoryOpn };
        andStatements.Add(customerStatement);
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
        fs = S.GetFieldSet(FieldSetSeeder.RECEIVING);
        // Get date received field
        dateReceivedField = S.GetField(fs, "Date Received");

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