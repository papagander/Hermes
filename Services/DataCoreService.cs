
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

        public int CreateFieldTypeOperator(string fieldTypeName, string operatorName)
        {
            FieldType fieldType = U.FieldTypes.Get(fieldTypeName);
            Operator @operator = U.Operators.Get(operatorName);
            var e = new FieldTypeOperator(fieldType, @operator);
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
            var fto = GetFieldTypeOperator(fieldTypeName, operatorName);
            if (fto is not null) U.FieldTypeOperators.Remove(fto);
            return Complete;

        }

        public int DeleteOperator(string operatorName)
        {
            U.Operators.Remove(U.Operators.Get(operatorName));
            return Complete;
        }

        public IEnumerable<Conjoiner> GetAllConjoiners() => U.Conjoiners.GetAll();

        public IEnumerable<FieldType> GetAllFieldTypes() => U.FieldTypes.GetAll();

        public IEnumerable<Operator> GetAllOperators() => U.Operators.GetAll();

        public FieldTypeOperator? GetFieldTypeOperator(string fieldTypeName, string operatorName)
        {
            var byFieldType = U.FieldTypeOperators.GetRange(U.FieldTypes.Get(fieldTypeName));
            int count = byFieldType.Count();
            var operatorId = U.Operators.Get(operatorName).OperatorId;
            int i = 0;
            while (byFieldType.ElementAt(i).OperatorId != operatorId & i < count) i++;
            if (i < count) return byFieldType.ElementAt(i);
            return null;
        }

        public IEnumerable<Operator> GetOperatorsByFieldType(int fieldTypeDex) => U.FieldTypes.GetOperators(U.FieldTypes.Get(fieldTypeDex));

        public IEnumerable<Operator> GetOperatorsByFieldType(string fieldTypeName) => U.FieldTypes.GetOperators(U.FieldTypes.Get(fieldTypeName));
        private int Complete => U.Complete();
    }
}