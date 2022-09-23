using System;
using DataAccess.EFCore.Interfaces.Repositories.Generic;

namespace DataAccess.EFCore.Interfaces.Repositories.DataSets
{
    public interface IFieldRepository : 
        INamedRepository<Field>
        , IReferencesRepository<Field, DataSet>
        , IReferencedByRepository<Field, Query>

    {
    }
}

