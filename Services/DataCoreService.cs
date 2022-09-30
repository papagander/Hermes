
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
        public int Create(Conjoiner e)
        {
            U.Conjoiners.Add(e);
            return Complete;
        }
        public int Create(Operator e)
        {
            U.Operators.Add(e);
            return Complete;
        }
        public int Create(FieldType e)
        {
            U.FieldTypes.Add(e);
            return Complete;
        }
        public int Create(FieldTypeOperator e)
        {
            U.FieldTypeOperators.Add(e);
            return Complete;
        }

        public int Create(FieldType fieldType, Operator op)
        {
            var fto = new FieldTypeOperator { FieldType = fieldType, Operator = op };
            U.FieldTypeOperators.Add(fto);
            return Complete;
        }
        public int Remove(Conjoiner e)
        {
            U.Conjoiners.Remove(e);
            return Complete;
        }
        public int Remove(FieldType e)
        {
            U.FieldTypes.Remove(e);
            return Complete;
        }
        public int Remove(FieldTypeOperator e)
        {
            U.FieldTypeOperators.Remove(e);
            return Complete;
        }
        public int Remove(Operator e)
        {
            U.Operators.Remove(e);
            return Complete;
        }
        public int Remove(FieldType ft, Operator op)
        {
            var fto = GetFieldTypeOperator(ft, op);
            if (fto is not null) U.FieldTypeOperators.Remove(fto);
            return Complete;

        }

        public IEnumerable<Conjoiner> GetAllConjoiners() => U.Conjoiners.GetAll();

        public IEnumerable<FieldType> GetAllFieldTypes() => U.FieldTypes.GetAll();

        public IEnumerable<Operator> GetAllOperators() => U.Operators.GetAll();

        public FieldTypeOperator? GetFieldTypeOperator(FieldType ft, Operator op)
        {
            var ftos = U.FieldTypes.GetFieldTypeOperators(ft);
            int count = ftos.Count();
            int opId = op.Id;
            return (from fto in ftos where fto.OperatorId == opId select fto).First();
        }

        public IEnumerable<Operator> GetOperators(FieldType ft) => U.FieldTypes.GetOperators(ft);
        public IEnumerable<FieldType> GetFieldTypes(Operator ent) => U.Operators.GetFieldTypes(ent);
        public FieldType? GetFieldType(string name) => U.FieldTypes.Get(name);
        public Operator? GetOperator(string name) => U.Operators.Get(name);
        public Conjoiner? GetConjoiner(string name) => U.Conjoiners.Get(name);
        private int Complete => U.Complete();
    }
}