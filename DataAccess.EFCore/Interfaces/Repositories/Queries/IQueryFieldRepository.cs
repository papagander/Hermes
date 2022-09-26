using Domain.Models.DataSets;
using Domain.Models.Queries;

using System;

namespace DataAccess.EFCore.Interfaces.Repositories.Queries
{
    public interface IQueryFieldRepository :  
        IReferencesRepository<QueryField, Query>
        , IReferencesRepository<QueryField, Field>
    {
    }
}

