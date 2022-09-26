using Domain.Models.DataSets;
using Domain.Models.Queries;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Interfaces.Repositories.Queries
{
    public interface IQueryRepository : 
        INamedRepository<Query>
        , IReferencesRepository<Query, DataSet>
        , IReferencedByRepository<Query, Field>
    {

    }
}
