using System;
using DataAccess.EFCore.Interfaces.Repositories.Generic;

namespace DataAccess.EFCore.Interfaces.Repositories.DataSets
{
    public interface IFieldRepository : ICrdRepository<Field>
    {
        IEnumerable<Field> GetFieldsByDataSetId(int dataSetId);
        IEnumerable<Field> GetFieldsByQueryId(int queryId);
    }
}

