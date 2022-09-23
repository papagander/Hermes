global using DataAccess.EFCore.Interfaces.Repositories;
using DataAccess.EFCore.Interfaces.Repositories.Generic;
using Domain.Models.DataCore;

using System;

namespace DataAccess.EFCore.Repository.Queries
{
    public class FieldTypeRepository : CrdRepository<FieldType>, ICrdRepository<FieldType>
    {
        public FieldTypeRepository(ReportContext reportContext) : base(reportContext) { }
    }
}

