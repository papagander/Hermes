using DataAccess.EFCore;
using DataAccess.EFCore.UnitOfWork.DataCore;

using Domain.Models.DataCore;

using Services.Interfaces;

namespace Services
{
    public class DataCoreService : IDataCoreService
    {
        DataCoreUnitOfWork U { get; set; }
        public DataCoreService(ReportContext reportContext)
        { 
            U = new DataCoreUnitOfWork(reportContext);
        }

        public int CreateConjoiner(string conjoinerName)
        {
            var conjoiner = new Conjoiner(conjoinerName);
            U.Conjoiners.Add(conjoiner);
            return U.Complete();
        }

        public int CreateFieldType(string fieldTypeName)
        {
            var fieldType = new FieldType(fieldTypeName);
            U.FieldTypes.Add(fieldType);
            return U.Complete();

        }

        public int CreateFieldTypeOperator(string fieldTypeName, string operatorName)
        {
            var e = new FieldTypeOperator()
        }

        public int CreateOperator(string operatorName)
        {
            throw new NotImplementedException();
        }

        public int DeleteConjoiner(string conjoinerName)
        {
            throw new NotImplementedException();
        }

        public int DeleteFieldType(string fieldTypeName)
        {
            throw new NotImplementedException();
        }

        public int DeleteFieldTypeOperator(string fieldTypeName, string operatorName)
        {
            throw new NotImplementedException();
        }

        public int DeleteOperator(string operatorName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Conjoiner> GetAllConjoiners()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FieldType> GetAllFieldTypes()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Operator> GetAllOperators()
        {
            throw new NotImplementedException();
        }

        public int GetFieldTypeOperator(string fieldTypeName, string operatorName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Operator> GetOperatorsByFieldType(int fieldTypeDex)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Operator> GetOperatorsByFieldType(string fieldTypeName)
        {
            throw new NotImplementedException();
        }
    }
}