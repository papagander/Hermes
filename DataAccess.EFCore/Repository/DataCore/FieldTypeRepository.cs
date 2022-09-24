using DataAccess.EFCore.Interfaces.Repositories.DataCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repository.DataCore
{
    public class FieldTypeRepository : NamedRepository<FieldType>, IFieldTypeRepository
    {
        ReferencedByRepository<FieldType, Operator> RefOp;
        ReferencedByRepository<FieldType, FieldTypeOperator> RefFto;
        public FieldTypeRepository(ReportContext _context) : base(_context)
        {
            RefOp = new ReferencedByRepository<FieldType, Operator>(_context);
            RefFto = new ReferencedByRepository<FieldType, FieldTypeOperator>(_context);
        }

        public IEnumerable<Operator> GetChildren(FieldType MyT) => RefOp.GetChildren(MyT);

        IEnumerable<FieldTypeOperator> IReferencedByRepository<FieldType, FieldTypeOperator>.GetChildren(FieldType MyT) => RefFto.GetChildren(MyT);
    }
}
