global using Domain.Models.DataCore;

global using DataAccess.EFCore.Interfaces.Repositories;
global using DataAccess.EFCore.Interfaces.Repositories.DataCore;


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
        public FieldTypeRepository(ReportContext _context) : base(_context)
        {
            RefOp = new ReferencedByRepository<FieldType, Operator>(_context);
        }

        public IEnumerable<Operator> GetOperators(FieldType MyT) => RefOp.GetChildren(MyT);


        IEnumerable<Operator> IReferencedByRepository<FieldType, Operator>.GetChildren(FieldType MyT) => GetOperators(MyT);

    }
}
