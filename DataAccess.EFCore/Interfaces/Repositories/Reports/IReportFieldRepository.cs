using System;
namespace DataAccess.EFCore.Interfaces.Repositories.Reports
{
    public interface IReportFieldRepository : ICrdRepository<QueryField>
    {
        IEnumerable<Field> GetFields(int reportId);
    }
}

