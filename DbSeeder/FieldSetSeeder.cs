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

namespace DbSeeder;
public class FieldSetSeeder
    : ISeeder
{
    public const string DEVICES = "Devices";
    public const string STUDENTS = "Students";
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
        S.CreateFieldSet(DevicesSet.Name, DeviceFields);
        S.CreateFieldSet(STUDENTS, StudentFields);

    }
    public static FieldSet DevicesSet { 
        get
        {
            return new FieldSet() { Id = 1, Name = DEVICES };

        }
    }

    public static List<Field> DeviceFields
    {
        get
        {
            var output = new List<Field>();
            string name;
            SqlDbType dbType;
            name = "Asset Tag";
            dbType = SqlDbType.VarChar;
            output.Add(new Field() {  Name = name, DbType = dbType }) ;
            name = "Device Model";
            dbType= SqlDbType.VarChar;
            output.Add(new Field() { Name = name, DbType = dbType }) ;
            name = "Device Category";
            dbType = SqlDbType.VarChar;
            output.Add(new Field() {  Name = name, DbType = dbType }) ;
            name = "Department";
            dbType = SqlDbType.VarChar;
            output.Add(new Field() {  Name = name, DbType = dbType });
            name = "Deployment Date";
            dbType = SqlDbType.DateTime;
            output.Add(new Field() { Name = name, DbType = dbType });

            return output;
        }
    }
    public static List<Field> StudentFields
    {
        get
        {
            var output = new List<Field>();
            string name;
            SqlDbType dbType;
            name = "First Name";
            dbType = SqlDbType.VarChar;
            output.Add(new Field() { Name = name, DbType = dbType });
            name = "Last Name";
            dbType = SqlDbType.VarChar;
            output.Add(new Field() { Name = name, DbType = dbType });
            name = "Credits Earned";
            dbType = SqlDbType.Int;
            output.Add(new Field() { Name = name, DbType = dbType });
            name = "Financial Aid Reward";
            dbType = SqlDbType.Money;
            output.Add(new Field() { Name = name, DbType = dbType });
            name = "Date Enrolled";
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