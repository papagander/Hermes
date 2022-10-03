using DataAccess.EFCore;

using Domain.Interfaces.Models;

using Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole.Controllers;

namespace TestConsole.DataCore
{
    public abstract class DataCoreEntityController<T> : GenericEntityController<T> where T : class, IIndexed
    {
        protected DataCoreService S;
        public DataCoreEntityController(ReportContext context) : base(context)
        {
            S = new DataCoreService(reportContext);
        }

    }
}
