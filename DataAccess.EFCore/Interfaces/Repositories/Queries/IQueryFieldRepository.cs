using System;
using DataAccess.EFCore.Interfaces.Repositories.Generic;

namespace DataAccess.EFCore.Interfaces.Repositories.Queries
{
    public interface IQueryFieldRepository :  
        IReferencesRepository<QueryField, Query>
        , IReferencesRepository<QueryField, Field>
    {
    }
}

