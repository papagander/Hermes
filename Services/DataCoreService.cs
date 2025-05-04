
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
        DataCoreUnitOfWork uow { get; set; }
        public DataCoreService(ReportContext _context) : base(_context)
        {
            uow = new(context);
            UnitOfWork = uow;
        }

        public int AddOperator(string name, string executionString, IEnumerable<SqlDbType> dbTypes, IEnumerable<Parameter> parameters)
        {
            uow.Operators.Add(name, executionString, dbTypes, parameters);
            return Complete;
        }

        public Operator? GetOperator(int id) => uow.Operators.Get(id);

        public IEnumerable<Operator> GetAllOperators() => uow.Operators.GetAll();

        public int RemoveOperator(int id)
        {
            var op = uow.Operators.Get(id);
            if (op is not null) uow.Operators.Remove(op);
            return Complete;
        }

        public IEnumerable<Operator> GetOperators(SqlDbType dbType)
        {
            var output = new List<Operator>();
            foreach (var op in uow.Operators.GetAll())
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
            var op = uow.Operators.Get(operatorId);
            if (op is null) return -1;
            throw new NotImplementedException();
        }

        public int AddConjoiner(string name)
        {
            uow.Conjoiners.Add(name);
            return Complete;
        }

        public Conjoiner? GetConjoiner(int id) => uow.Conjoiners.Get(id);
        public Conjoiner? GetConjoiner(string name) => uow.Conjoiners.Get(name);

        public IEnumerable<Conjoiner> GetAllConjoiners() => uow.Conjoiners.GetAll();

        public int RemoveConjoiner(Conjoiner cjr)
        {
            uow.Conjoiners.Remove(cjr);
            return Complete;    
        }
    }
}