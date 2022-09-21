global using DataAccess.EFCore.Interfaces.Repositories;
using System;

namespace DataAccess.EFCore.Repository.Reports
{
    public class FieldTypeRepository : CrdRepository<FieldType>, ICrdRepository<FieldType>
    {
        public FieldTypeRepository(ReportContext reportContext) : base(reportContext) { }
    }
}

