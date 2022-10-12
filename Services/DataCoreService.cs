
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

        public int AddOperator(string name, string executionString, IEnumerable<DbType> dbTypes, IEnumerable<Parameter> parameters)
        {
            U.Operators.Add(name, executionString, dbTypes, parameters);
            return Complete;
        }

        public Operator GetOperator(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Operator> GetAllOperators()
        {
            throw new NotImplementedException();
        }

        public int RemoveOperator(Operator op)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Operator> GetOperators(DbType dbType)
        {
            throw new NotImplementedException();
        }

        public int AddFieldTypes(string operatorName, IEnumerable<DbType> dbTypes)
        {
            throw new NotImplementedException();
        }

        public int AddConjoiner(string name)
        {
            throw new NotImplementedException();
        }

        public Conjoiner GetConjoiner(int id)
        {
            throw new NotImplementedException();
        }

        public Conjoiner GetConjoiner(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Conjoiner> GetAllConjoiners()
        {
            throw new NotImplementedException();
        }

        public int RemoveConjoiner(Conjoiner cjr)
        {
            throw new NotImplementedException();
        }
    }
}