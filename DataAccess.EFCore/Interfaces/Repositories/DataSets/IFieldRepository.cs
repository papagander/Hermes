using System;

namespace DataAccess.EFCore.Interfaces.Repositories.DataSets
{
    public interface IFieldRepository : 
        INamedRepository<Field>
        , IReferencesRepository<Field, DataSet>
        , IReferencedByRepository<Field, Query>

    {
    }
}

