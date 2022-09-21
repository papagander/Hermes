using System;
using System.Linq;
namespace DataAccess.EFCore.Repository.Reports
{
    public class FieldRepository :   CrdRepository<Field>, IFieldRepository
    {
        public FieldRepository(ReportContext reportContext) : base(reportContext) { }
        public IEnumerable<Field> GetFieldsByDataSetId(int templateId)
        {
            return _context.Fields.Where<Field>(f => f.DataSetId == templateId);
        }
        public IEnumerable<Field> GetFieldsByQueryId(int queryId)
        {
            IEnumerable<int> fieldIds =
                (from queryField in _context.QueryFields where queryField.QueryId == queryId
                 select queryField.FieldId);
            IEnumerable<Field> Fields =
                (from Field in _context.Fields where fieldIds.Contains(Field.FieldId)
                 select Field);
            return Fields;
            
        } 
    }
}

