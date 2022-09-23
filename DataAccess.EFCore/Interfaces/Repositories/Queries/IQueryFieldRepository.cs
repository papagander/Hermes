using System;
using DataAccess.EFCore.Interfaces.Repositories.Generic;

namespace DataAccess.EFCore.Interfaces.Repositories.Queries
{
    public interface IQueryFieldRepository : ICrdRepository<QueryField>
    {
        IEnumerable<Field> GetFields(int reportId);
    }
}

