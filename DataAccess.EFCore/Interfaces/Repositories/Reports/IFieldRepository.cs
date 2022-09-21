using System;
namespace DataAccess.EFCore.Interfaces.Repositories.Reports
{
    public interface IFieldRepository : ICrdRepository<Field>
    {
        IEnumerable<Field> GetFieldsByTemplateId(int templateId);
        IEnumerable<Field> GetFieldsByReportId(int reportId);
    }
}

