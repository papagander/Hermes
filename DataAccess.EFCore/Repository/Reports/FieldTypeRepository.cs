using System;
namespace DataAccess.EFCore.Repository
{
    public class FieldTypeRepository : CrdRepository<FieldType>, ICrdRepository<FieldType>
    {
        public FieldTypeRepository(ReportContext reportContext) : base(reportContext) { }
    }
}

