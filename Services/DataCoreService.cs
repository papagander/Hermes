
using DataAccess.EFCore;
using DataAccess.EFCore.Interfaces.UnitsOfWork.DataCore;
using DataAccess.EFCore.UnitOfWork.DataCore;

using Domain;
using Domain.Models.DataCore;

using Services.Interfaces;

using System.Data;

namespace Services
{
    public class DataCoreService :
        GenericService
        , IDataCoreService
    {
        DataCoreUnitOfWork U { get; set; }
        public DataCoreService(ReportContext _context) : base(_context)
        {
            U = new(context);
            UnitOfWork = U;
        }

        public int AddOperator(string name, string executionString, IEnumerable<SqlDbType> dbTypes, IEnumerable<Parameter> parameters)
        {
            U.Operators.Add(name, executionString, dbTypes, parameters);
            return Complete;
        }

        public Operator? GetOperator(int id) => U.Operators.Get(id);

        public IEnumerable<Operator> GetAllOperators() => U.Operators.GetAll();

        public int RemoveOperator(int id)
        {
            var op = U.Operators.Get(id);
            if (op is not null) U.Operators.Remove(op);
            return Complete;
        }

        public IEnumerable<Operator> GetOperators(SqlDbType dbType)
        {
            var output = new List<Operator>();
            foreach (var op in U.Operators.GetAll())
                foreach (var fto in op.OperatorFieldTypes)
                    if (fto.DbType.Equals(dbType))
                    {
                        output.Add(op);
                        break;
                    }
            return output;
        }

        public int AddFieldTypes(int operatorId, IEnumerable<SqlDbType> dbTypes)
        {
            var op = U.Operators.Get(operatorId);
            if (op is null) return -1;
            throw new NotImplementedException();
        }

        public int AddConjoiner(string name)
        {
            U.Conjoiners.Add(name);
            return Complete;
        }

        public Conjoiner? GetConjoiner(int id) => U.Conjoiners.Get(id);
        public Conjoiner? GetConjoiner(string name) => U.Conjoiners.Get(name);

        public IEnumerable<Conjoiner> GetAllConjoiners() => U.Conjoiners.GetAll();

        public int RemoveConjoiner(Conjoiner cjr)
        {
            U.Conjoiners.Remove(cjr);
            return Complete;    
        }
    }
}