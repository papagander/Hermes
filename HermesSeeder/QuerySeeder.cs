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
        Context.Database.ExecuteSqlRaw("DELETE FROM QUERY");
        throw new NotImplementedException();
    }
    public Query QueryZero()
    {
        throw new NotImplementedException();
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
        var prodStat = new Conjunction() { Statements = orStats}.ToStatement();

        // Add date condition
        Statement dateStatement = OneWeeksAgo(S);
        var _ = new List<Statement>();
        _.Add(dateStatement);
        _.Add(prodStat);

        // Combine Product condition w date condition
        var parentStat = new Conjunction() { Statements = _}.ToStatement();


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

        // Fieldset the fields are in
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
        fs = S.GetFieldSets().FirstOrDefault(fs => fs.Name.ToLower().Contains("receiving"));
        // Get Customer and Category columns
        customerField = fs.Fields.FirstOrDefault(f => f.Name.ToLower().Contains("customer"));
        categoryField = fs.Fields.FirstOrDefault(f => f.Name.ToLower().Contains("category"));


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
        and = new Conjunction() {Statements = andStatements };
        output = new Statement()
        {
            Conjunction = and
        };
        return output;

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

        // Fieldset the fields are in
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
        fs = S.GetFieldSets().FirstOrDefault(fs => fs.Name.ToLower().Contains("receiving"));
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
        and = new Conjunction() { Statements = andStatements };
        output = new Statement()
        {
            Conjunction = and
        };
        return output;

#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
    public static Statement OneWeeksAgo(QueryService S)
    {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        
        Statement output;

        // Operations 
        Operation weeksAgoOpn;
        
        // Fields to perform operation on
        Field dateReceivedField;

        // Fieldset the field is in
        FieldSet fs;

        // "Is" operator
        Operator opr;

        // Parameter lists for operations
        List<OperationParameter> weeksAgoParams = new();

        // Operation Parameters
        OperationParameter weeksAgoParameter;

        // Statements to contain operations
        Statement weeksAgoSt;


        // Get Is Operator
        opr = S.GetOperators(SqlDbType.VarChar).FirstOrDefault(opr => opr.Name.ToLower().Contains("is"));
        // Get Receiving Table
        fs = S.GetFieldSets().FirstOrDefault(fs => fs.Name.ToLower().Contains("receiving"));
        // Get date received field
        dateReceivedField = fs.Fields.FirstOrDefault(f => f.Name.ToLower().Contains("Date Received"));

        // Create operation parameter entities
        weeksAgoParameter = new OperationParameter() { Parameter = opr.Parameters[0], Value = "1" };

        // Add parameters to parameter lists (1 each)
        weeksAgoParams.Add(weeksAgoParameter);
        // Instantiate operations
        weeksAgoOpn = new Operation() { Field = dateReceivedField, Operator = opr, OperationParameters = weeksAgoParams };
        weeksAgoSt = new Statement() { Operation = weeksAgoOpn };
        output = new Statement()
        {
            Operation = weeksAgoOpn
        };
        return output;

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
                Context.Dispose();
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
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