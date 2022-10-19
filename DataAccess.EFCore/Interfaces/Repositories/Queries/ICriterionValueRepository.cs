using Domain.Models.Queries;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Interfaces.Repositories.Queries
{
    public interface ICriterionValueRepository :
        IIndexedRepository<CriterionParamater>
        , IReferencesRepository<CriterionParamater, Criterion>
    { }
}
