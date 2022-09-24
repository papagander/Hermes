
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
            return Complete;
        }

        public int CreateFieldType(string fieldTypeName)
        {
            var fieldType = new FieldType(fieldTypeName);
            U.FieldTypes.Add(fieldType);
            return Complete;

        }

        public int? CreateFieldTypeOperator(string fieldTypeName, string operatorName)
        {
            FieldType fieldType = U.FieldTypes.Get(fieldTypeName);
            Operator @operator = U.Operators.Get(operatorName);
            var e = new FieldTypeOperator(fieldType,operator);
            return Complete;
        }

        public int CreateOperator(string operatorName)
        {
            U.Operators.Add(new(operatorName));
            return Complete;
        }

        public int DeleteConjoiner(string conjoinerName)
        {
            U.Conjoiners.Remove(U.Conjoiners.Get(conjoinerName));
            return Complete;
        }

        public int DeleteFieldType(string fieldTypeName)
        {
            U.FieldTypes.Remove(U.FieldTypes.Get(fieldTypeName));
            return Complete;
        }

        public int DeleteFieldTypeOperator(string fieldTypeName, string operatorName)
        {
            var byFieldType = U.FieldTypeOperators.GetRange(U.FieldTypes.Get(fieldTypeName));
            int count = byFieldType.Count();
            var operatorId = U.Operators.Get(operatorName).OperatorId;
            int i = 0;
            while (byFieldType.ElementAt(i).OperatorId != operatorId & i < count) i++;
            if (i < count) U.FieldTypeOperators.Remove(byFieldType.ElementAt(i));
            return Complete;

        }

        public int DeleteOperator(string operatorName)
        {
            U.Operators.Remove(U.Operators.Get(operatorName));
            return Complete;
        }

        public IEnumerable<Conjoiner> GetAllConjoiners()
        {
            return U.Conjoiners.GetAll();
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
        private int Complete => U.Complete();
    }
}