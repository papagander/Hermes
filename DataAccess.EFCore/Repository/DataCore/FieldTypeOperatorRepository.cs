using DataAccess.EFCore.Interfaces.Repositories.DataCore;

using Domain.Models.DataCore;

using System;

namespace DataAccess.EFCore.Repository.DataCore
{
    public class FieldTypeOperatorRepository : IndexedRepository<FieldTypeOperator>, IFieldTypeOperatorRepository
    {
        private  ReferencesRepository<FieldTypeOperator, FieldType> RefFT;
        private  ReferencesRepository<FieldTypeOperator, Operator> RefOp;
        public FieldTypeOperatorRepository(ReportContext _context) : base(_context)
        {
            RefFT = new ReferencesRepository<FieldTypeOperator, FieldType>(_context);
            RefOp = new ReferencesRepository<FieldTypeOperator, Operator>(_context);
        }

        public IEnumerable<FieldTypeOperator> GetRange(FieldType MyTRef) => RefFT.GetRange(MyTRef);
        public IEnumerable<FieldTypeOperator> GetRange(Operator MyTRef) =>RefOp.GetRange(MyTRef);
    }
}

