using System;
namespace DataAccess.EFCore.UnitOfWork
{
    public class GenericUnitOfWork
    {
        private readonly ReportContext _context;
        public GenericUnitOfWork(ReportContext _context)
        {
            this._context = _context;
        }
    }
}

