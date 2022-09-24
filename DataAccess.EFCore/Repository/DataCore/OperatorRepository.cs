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
        ReferencedByRepository<Operator, FieldType> RefFT;
        public OperatorRepository(ReportContext _context) : base(_context)
        {
            RefFT = new ReferencedByRepository<Operator, FieldType>(_context);
        }

        public IEnumerable<FieldType> GetChildren(Operator MyT) => RefFT.GetChildren(MyT);
    }
}
