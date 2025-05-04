using DataAccess.EFCore;
using DataAccess.EFCore.Interfaces.UnitsOfWork;

using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public abstract class GenericService
    {
        protected  IUnitOfWork  UnitOfWork { get; set; }
        protected ReportContext context {  get; private set; }
        // dep inject context
        public GenericService(ReportContext _)
        {
            context = _;
        }
        // used by children to finalize changes
        protected int Complete => UnitOfWork.Complete();
    }
}
