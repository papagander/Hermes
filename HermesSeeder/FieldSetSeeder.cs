using Domain.Models.DataCore;
using Domain.Models.FieldSets;

using HermesSeeder.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HermesSeeder;
public class FieldSetSeeder
    : ISeeder
{

    public void Seed()
    {
        throw new NotImplementedException();
    }
    public void Dispose()
    {
        throw new NotImplementedException();
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
            var fields = new List<Field>();
            int id = 1;
            string name = "Serial Number";
            FieldType fieldType = DataCoreSeeder.TEXT;
        }
    }

}