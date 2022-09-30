
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
        public int Remove(Operator e)
        {
            U.Operators.Remove(e);
            return Complete;
        }

        public IEnumerable<Conjoiner> GetAllConjoiners() => U.Conjoiners.GetAll();

        public IEnumerable<FieldType> GetAllFieldTypes() => U.FieldTypes.GetAll();

        public IEnumerable<Operator> GetAllOperators() => U.Operators.GetAll();
        public IEnumerable<Operator> GetOperators(FieldType ft) => U.FieldTypes.GetOperators(ft);
        public IEnumerable<FieldType> GetFieldTypes(Operator ent) => U.Operators.GetFieldTypes(ent);
        public FieldType? GetFieldType(int id) => U.FieldTypes.Get(id);
        public Operator? GetOperator(int id) => U.Operators.Get(id);
        public Conjoiner? GetConjoiner(int id) => U.Conjoiners.Get(id);

        private int Complete => U.Complete();
    }
}