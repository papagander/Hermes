global using Domain;
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
        public OperatorRepository(ReportContext _context) : base(_context)
        {
            _Ft = new ReferencedByRepository<Operator, FieldType>(_context);
        }


        public IEnumerable<FieldType> GetFieldTypes(Operator ent) => _Ft.GetChildren(ent);


        IEnumerable<FieldType> IReferencedByRepository<Operator, FieldType>.GetChildren(Operator MyT) => _Ft.GetChildren(MyT);

    }
}
