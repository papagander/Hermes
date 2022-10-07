using Domain;
using Domain.Models.DataCore;

using HermesSeeder.Interfaces;

using Microsoft.EntityFrameworkCore;

using Services;

namespace HermesSeeder
{
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
            Context.Database.ExecuteSqlRaw("DELETE FROM Operator");
            Context.Database.ExecuteSqlRaw("DELETE FROM FieldType");
            Context.Database.ExecuteSqlRaw("DELETE FROM Conjoiner");
            foreach (var item in Equality) S.Add(item);
            foreach (var item in GreaterOrLessThan) S.Add(item);
            foreach (var item in StringCompare) S.Add(item);
            foreach (var item in DateInLast) S.Add(item);
            foreach (var item in BaseFieldTypes) S.Add(item);

            var _equality = new List<Operator>();
            foreach (var item in Equality) _equality.Add(S.GetOperator(item.Id));

            var _greaterOrLessThan = new List<Operator>();
            foreach (var item in GreaterOrLessThan) _greaterOrLessThan.Add(S.GetOperator(item.Id));

            var _stringCompare = new List<Operator>();
            foreach (var item in StringCompare) _stringCompare.Add(S.GetOperator(item.Id));

            var _dateInlast = new List<Operator>();
            foreach (var item in DateInLast) _dateInlast.Add(S.GetOperator(item.Id));

            var _text = S.GetFieldType(TEXT.Id);
            var _int = S.GetFieldType(INT.Id);
            var _decimal = S.GetFieldType(DECIMAL.Id);
            var _date = S.GetFieldType(DATE.Id);

            S.AddOperators(_text, _equality);
            S.AddOperators(_int, _equality);
            S.AddOperators(_decimal, _equality);
            S.AddOperators(_date, _equality);
              
            S.AddOperators(_int, _greaterOrLessThan);
            S.AddOperators(_decimal, _greaterOrLessThan);
            S.AddOperators(_date, _greaterOrLessThan);
              
            S.AddOperators(_date, _dateInlast);
              
            S.AddOperators(_text, _stringCompare);



        }
        public static List<Operator> Equality
        {
            get
            {
                var output = new List<Operator>();
                int id = 1;
                string name = "=";
                output.Add(new Operator { Id = id, Name = name });
                id++;
                name = "!=";
                output.Add(new Operator { Id = id, Name = name });
                return output;
            }
        }
        public static List<Operator> GreaterOrLessThan
        {
            get
            {
                var output = new List<Operator>();
                int id = Equality[Equality.Count - 1].Id + 1;
                string name = "<";
                output.Add(new Operator { Id = id, Name = name });
                id++;
                name = ">";
                output.Add(new Operator { Id = id, Name = name });
                id++;
                name = "<=";
                output.Add(new Operator { Id = id, Name = name });
                id++;
                name = ">=";
                output.Add(new Operator { Id = id, Name = name });
                return output;
            }
        }
        public static List<Operator> StringCompare
        {
            get
            {
                var output = new List<Operator>();
                int id = GreaterOrLessThan[GreaterOrLessThan.Count - 1].Id + 1;
                string name = "contains";
                output.Add(new Operator { Id = id, Name = name });
                id++;
                name = "contained-in";
                output.Add(new Operator { Id = id, Name = name });
                return output;
            }
        }
        public static List<Operator> DateInLast
        {
            get
            {
                var output = new List<Operator>();
                int id = StringCompare[StringCompare.Count - 1].Id + 1;
                string name = "was-last-week";
                output.Add(new Operator { Id = id, Name = name });
                id++;
                name = "was-last-month";
                output.Add(new Operator { Id = id, Name = name });
                id++;
                name = "was-this-year";
                output.Add(new Operator { Id = id, Name = name });
                return output;
            }
        }
        public static List<FieldType> BaseFieldTypes
        {
            get
            {
                var output = new List<FieldType>();
                int id = 1;
                string name = "text";
                output.Add(new FieldType { Id = id, Name = name });
                id++;
                name = "int";
                output.Add(new FieldType { Id = id, Name = name });
                id++;
                name = "decimal";
                output.Add(new FieldType { Id = id, Name = name });
                id++;
                name = "date";
                output.Add(new FieldType { Id = id, Name = name });
                return output;
            }
        }
        public static FieldType TEXT { get => BaseFieldTypes[0];  }
        public static FieldType INT { get => BaseFieldTypes[1]; }
        public static FieldType DECIMAL { get => BaseFieldTypes[2]; }
        public static FieldType DATE { get => BaseFieldTypes[3];  }

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
        // ~DataCoreSeeder()
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
}