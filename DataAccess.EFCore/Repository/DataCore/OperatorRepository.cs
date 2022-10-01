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
        public OperatorRepository(ReportContext _context) : base(_context)
        {
        }
    }
}
