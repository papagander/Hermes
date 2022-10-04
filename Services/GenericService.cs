global using Domain;
using DataAccess.EFCore;
using DataAccess.EFCore.Interfaces.UnitsOfWork;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public abstract class GenericService
    {
        protected virtual IUnitOfWork UnitOfWork { get; set; }
        ReportContext _context { get; set; }
        public GenericService(ReportContext context)
        {
            _context = context;
        }
        protected int Complete => UnitOfWork.Complete();
    }
}
