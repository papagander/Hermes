﻿using Domain.Models.FieldSets;
using Domain.Models.Queries;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Interfaces.Repositories.Queries;
public interface IQueryRepository
    : IUniquelyNamedRepository<Query>
    , IReferencesRepository<Query, FieldSet>
    , IReferencedByRepository<Query, Field>
{
    void SetStatement(Query query, Statement statement);
}
