using DataAccess.EFCore.Interfaces.Repositories.DataCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repository.DataCore
{
    public class OperatorRepository : NamedRepository<Operator>, IOperatorRepository
    {
        ReferencedByRepository<Operator, FieldType> _Ft;
        ReferencedByRepository<Operator, FieldTypeOperator> _Fto;
        public OperatorRepository(ReportContext _context) : base(_context)
        {
            _Ft = new ReferencedByRepository<Operator, FieldType>(_context);
            _Fto = new(_context);
        }


        public IEnumerable<FieldType> GetFieldTypes(Operator ent) => _Ft.GetChildren(ent);

        IEnumerable<FieldTypeOperator> IReferencedByRepository<Operator, FieldTypeOperator>.GetChildren(Operator MyT) => _Fto.GetChildren(MyT);

        IEnumerable<FieldType> IReferencedByRepository<Operator, FieldType>.GetChildren(Operator MyT) => _Ft.GetChildren(MyT);

    }
}
