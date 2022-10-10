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
        protected  IUnitOfWork  UnitOfWork { get; set; }
        protected ReportContext context {  get; private set; }
        public GenericService(ReportContext _)
        {
            context = _;
        }
        protected int Complete => UnitOfWork.Complete();
    }
}
