using System;
namespace DataAccess.EFCore.Interfaces.Repositories.Reports
{
    public interface IFieldRepository : ICrdRepository<Field>
    {
        IEnumerable<Field> GetFieldsByDataSetId(int dataSetId);
        IEnumerable<Field> GetFieldsByQueryId(int queryId);
    }
}

