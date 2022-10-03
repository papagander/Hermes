using Domain.Models.FieldSets;
using Domain.Models.Queries;

using System;

namespace DataAccess.EFCore.Interfaces.Repositories.FieldSets
{
    public interface IFieldRepository : 
        INamedRepository<Field>
        , IReferencesRepository<Field, FieldSet>

    {
    }
}

