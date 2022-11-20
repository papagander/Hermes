using Domain;
using Domain.Models.DataCore;
using Domain.Models.FieldSets;
using Domain.Models.Queries;

using HermesSeeder.Interfaces;

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
        throw new NotImplementedException();
    }

    public static Statement CapitalBrandsVaccuums(QueryService S)
    {
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        Operator opr;
        FieldSet fs;
        Statement st;
        Field customerField;
        Field categoryField;
        Operation customerOpn;
        Operation categoryOpn;
        List<OperationParameter> customerParameters = new();
        List<OperationParameter> categoryParameters = new();
        OperationParameter customerParameter;
        OperationParameter categoryParameter;
        Statement categoryStatement;
        Statement customerStatement;
        Conjunction and;
        List<Statement> andStatements;
        Statement output;


        // Get Is Operator
        opr = S.GetOperators(SqlDbType.VarChar).FirstOrDefault(opr => opr.Name.ToLower().Contains("is"));
        // Get Receiving Table
        fs = S.GetFieldSets().FirstOrDefault(fs => fs.Name.ToLower().Contains("receiving"));
        // Get Customer and Category columns
        customerField = fs.Fields.FirstOrDefault(f => f.Name.ToLower().Contains("customer"));
        categoryField = fs.Fields.FirstOrDefault(f => f.Name.ToLower().Contains("categoryOpn"));


        customerParameter = new OperationParameter() { Parameter = opr.Parameters[0], Value = "Capital Brands" };
        categoryParameter = new OperationParameter() { Parameter = opr.Parameters[0], Value = "Vaccuums" };
        customerParameters.Add(customerParameter);
        categoryParameters.Add(categoryParameter);
        customerOpn = new Operation() { Field = customerField, Operator = opr, OperationParameters = customerParameters};
        categoryOpn = new Operation() { Field = categoryField, Operator = opr, OperationParameters = categoryParameters};
        customerStatement = new Statement() { Operations = new List<Operation>() { } };
        and = new Conjunction() { };
        var _ = new List<Conjunction>();
        _.Add(and);

        output = new Statement()
        {
            Conjunctions = _
        };
        return output;

#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8601 // Possible null reference assignment.
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