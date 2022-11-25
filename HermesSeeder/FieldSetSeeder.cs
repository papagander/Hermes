using Domain;
using Domain.Models.DataCore;
using Domain.Models.FieldSets;

using HermesSeeder.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;

using Services;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

using static System.Net.Mime.MediaTypeNames;

namespace HermesSeeder;
public class FieldSetSeeder
    : ISeeder
{
    private bool disposedValue;
    ReportContext Context;
    FieldSetService S { get; set; }
    public FieldSetSeeder(ReportContext context)
    {
        Context = context;
        S = new FieldSetService(Context);
    }

    public void Seed()
    {

        Context.Database.ExecuteSqlRaw("DELETE FROM FieldSet");
        Context.Database.ExecuteSqlRaw("DELETE FROM Field");
        S.CreateFieldSet(ReceivingSet.Name, ReceivingFields);
        S.CreateFieldSet("MockSet", MockSetFields);

    }
    public static FieldSet ReceivingSet { 
        get
        {
            return new FieldSet() { Id = 1, Name = "Receiving" };

        }
    }

    public static List<Field> ReceivingFields
    {
        get
        {
            var output = new List<Field>();
            string name;
            SqlDbType dbType;
            name = "Serial Number";
            dbType = SqlDbType.VarChar;
            output.Add(new Field() {  Name = name, DbType = dbType }) ;
            name = "Model Number";
            dbType= SqlDbType.VarChar;
            output.Add(new Field() { Name = name, DbType = dbType }) ;
            name = "Category";
            dbType = SqlDbType.VarChar;
            output.Add(new Field() {  Name = name, DbType = dbType }) ;
            name = "Sub Category";
            dbType = SqlDbType.VarChar;
            output.Add(new Field() {  Name = name, DbType = dbType }) ;
            name = "Customer";
            dbType = SqlDbType.VarChar;
            output.Add(new Field() {  Name = name, DbType = dbType });
            name = "Price";
            dbType = SqlDbType.Money;
            output.Add(new Field() { Name = name, DbType = dbType });
            name = "Date Received";
            dbType = SqlDbType.Date;
            output.Add(new Field() { Name = name, DbType = dbType });

            return output;
        }
    }
    public static List<Field> MockSetFields
    {
        get
        {
            var output = new List<Field>();
            string name;
            SqlDbType dbType;
            name = "Name";
            dbType = SqlDbType.VarChar;
            output.Add(new Field() { Name = name, DbType = dbType });
            name = "Price";
            dbType = SqlDbType.Money;
            output.Add(new Field() { Name = name, DbType = dbType });
            name = "My int";
            dbType = SqlDbType.Int;
            output.Add(new Field() { Name = name, DbType = dbType });
            name = "Date Received";
            dbType = SqlDbType.Date;
            output.Add(new Field() { Name = name, DbType = dbType });

            return output;
        }
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
            // TODO: set large fields to null
            disposedValue = true;
        }
    }

    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    // ~FieldSetSeeder()
    // {
    //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    //     Dispose(disposing: false);
    // }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}