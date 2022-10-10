using Domain;
using Domain.Models.DataCore;
using Domain.Models.FieldSets;

using HermesSeeder.Interfaces;

using Microsoft.EntityFrameworkCore;

using Services;

using System;
using System.Collections.Generic;
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
            int id = 1;
            string name = "Serial Number";
            FieldType fieldType = DataCoreSeeder.TEXT;
            output.Add(new Field() { FieldType = fieldType, Id = id, Name = name });
            id++;
            name = "Model Number";
            fieldType = DataCoreSeeder.TEXT;
            output.Add(new Field() { FieldType = fieldType, Id = id, Name = name });
            id++;
            name = "Category";
            fieldType = DataCoreSeeder.TEXT;
            output.Add(new Field() { FieldType = fieldType, Id = id, Name = name });
            id++;
            name = "Sub Category";
            fieldType = DataCoreSeeder.TEXT;
            output.Add(new Field() { FieldType = fieldType, Id = id, Name = name });
            id++;
            name = "Customer Name";
            fieldType = DataCoreSeeder.TEXT;
            output.Add(new Field() { FieldType = fieldType, Id = id, Name = name });
            id++;
            name = "Price";
            fieldType = DataCoreSeeder.DECIMAL;
            output.Add(new Field() { FieldType = fieldType, Id = id, Name = name });
            id++;
            name = "Date Received";
            fieldType = DataCoreSeeder.DATE;
            output.Add(new Field() { FieldType = fieldType, Id = id, Name = name });

            return output;
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
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