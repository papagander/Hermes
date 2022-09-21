using System;
namespace DataAccess.EFCore.Interfaces.Repositories.Reports
{
    public interface IQueryFieldRepository : ICrdRepository<QueryField>
    {
        IEnumerable<Field> GetFields(int reportId);
    }
}

