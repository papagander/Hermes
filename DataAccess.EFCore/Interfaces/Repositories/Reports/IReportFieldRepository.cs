using System;
namespace DataAccess.EFCore.Interfaces.Repositories.Reports
{
    public interface IReportFieldRepository : ICrdRepository<ReportField>
    {
        IEnumerable<Field> GetFields(int reportId);
    }
}

