using Domain.Models.DataSets;
using Domain.Models.Queries;

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

