using System;
namespace DataAccess.EFCore.UnitOfWork
{
    public class GenericUnitOfWork
    {
        protected readonly ReportContext _context;
        public GenericUnitOfWork(ReportContext _context)
        {
            this._context = _context;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}

