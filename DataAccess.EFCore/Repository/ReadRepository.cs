using System;
using DataAccess.EFCore.Interfaces.Repositories.Generic;

namespace DataAccess.EFCore.Repository
{
    public class ReadRepository<T> : GenericRepository<T>, IReadRepository<T> where T : class
    {
        public ReadRepository(ReportContext reportContext) : base(reportContext){}

        public T Get(int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetRange(IEnumerable<int> indexes)
        {
            throw new NotImplementedException();
        }
    }
}

