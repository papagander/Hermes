global using Domain;
using DataAccess.EFCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public abstract class GenericService
    {
        ReportContext _context { get; set; }
        public GenericService(ReportContext context)
        {
            _context = context;
        }
    }
}
