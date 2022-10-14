using Domain;
using Domain.Models.DataCore;

using HermesSeeder.Interfaces;

using Microsoft.EntityFrameworkCore;

using Services;

using System.Data;
using System.Net;

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
            SeedOperators();
            SeedConjoiners();
        }
        void SeedConjoiners()
        {
            Context.Database.ExecuteSqlRaw("DELETE FROM Conjoiner");

        }
        void SeedOperators()
        {

            Context.Database.ExecuteSqlRaw("DELETE FROM Operator");
            var equals = BaseOperators[0];
            var equalsTypes = Numeric;
            equalsTypes.AddRange(Temporal);
            equalsTypes.AddRange(Textual);
            S.AddOperator(equals.Name, equals.ExecutionString, equalsTypes, equals.Parameters);
            var notEqual = BaseOperators[1];
            var notEqualTypes = Numeric;
            notEqualTypes.AddRange(Temporal);
            notEqualTypes.AddRange(Textual);
            S.AddOperator(notEqual.Name, notEqual.ExecutionString, notEqualTypes, notEqual.Parameters);
            var lessThan = BaseOperators[2];
            var lessThanTypes = Numeric;
            notEqualTypes.AddRange(Temporal);
            S.AddOperator(lessThan.Name, lessThan.ExecutionString, lessThanTypes, lessThan.Parameters);
            var greaterThan = BaseOperators[3];
            var greaterThanTypes = Numeric;
            notEqualTypes.AddRange(Temporal);
            S.AddOperator(greaterThan.Name, greaterThan.ExecutionString, greaterThanTypes, greaterThan.Parameters);
            var lessThanOrEqual = BaseOperators[4];
            var lessThanOrEqualTypes = Numeric;
            notEqualTypes.AddRange(Temporal);
            S.AddOperator(lessThanOrEqual.Name, lessThanOrEqual.ExecutionString, lessThanOrEqualTypes, lessThanOrEqual.Parameters);
            var greaterThanOrEqual = BaseOperators[5];
            var greaterThanOrEqualTypes = Numeric;
            notEqualTypes.AddRange(Temporal);
            S.AddOperator(greaterThanOrEqual.Name, greaterThanOrEqual.ExecutionString, greaterThanOrEqualTypes, greaterThanOrEqual.Parameters);
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
                executionString = "{0} = {1}";
                paramName = "value";
                paramType = null;
                _1 = new Parameter() { Name = paramName, DbType = paramType };
                parameters = new List<Parameter>();
                parameters.Add(_1);
                op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
                output.Add(op);
                name = "not equal";
                executionString = "{0} <> {1}";
                paramName = "value";
                paramType = null;
                _1 = new Parameter() { Name = paramName, DbType = paramType };
                parameters = new List<Parameter>();
                parameters.Add(_1);
                op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
                output.Add(op);
                name = "less than";
                executionString = "{0} < {1}";
                paramName = "value";
                paramType = null;
                _1 = new Parameter() { Name = paramName, DbType = paramType };
                parameters = new List<Parameter>();
                parameters.Add(_1);
                op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
                output.Add(op);
                name = "greater than";
                executionString = "{0} > {1}";
                paramName = "1";
                paramType = null;
                _1 = new Parameter() { Name = paramName, DbType = paramType };
                parameters = new List<Parameter>();
                parameters.Add(_1);
                op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
                output.Add(op);
                name = "less than or equal";
                executionString = "{0} <= {1}";
                paramName = "value";
                paramType = null;
                _1 = new Parameter() { Name = paramName, DbType = paramType };
                parameters = new List<Parameter>();
                parameters.Add(_1);
                op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
                output.Add(op);
                name = "greater than or equal";
                executionString = "{0} >= {1}";
                paramName = "value";
                paramType = null;
                _1 = new Parameter() { Name = paramName, DbType = paramType };
                parameters = new List<Parameter>();
                parameters.Add(_1);
                op = new Operator { Name = name, ExecutionString = executionString, Parameters = parameters };
                output.Add(op);

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