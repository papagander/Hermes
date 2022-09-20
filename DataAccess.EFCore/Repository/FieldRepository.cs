using System;
using System.Linq;
namespace DataAccess.EFCore.Repository
{
    public class FieldRepository : GenericRepository<Field>, IFieldRepository
    {
        public FieldRepository(ReportContext reportContext) : base(reportContext) { }
        public IEnumerable<Field> GetFieldsByTemplateId(int templateId)
        {
            return _context.Fields.Where<Field>(f => f.TemplateId == templateId);
        }
        public IEnumerable<Field> GetFieldsByReportId(int reportId)
        {
            IEnumerable<int> fieldIds =
                (from reportField in _context.ReportFields where reportField.ReportId == reportId
                 select reportField.FieldId);
            IEnumerable<Field> Fields =
                (from Field in _context.Fields where fieldIds.Contains(Field.FieldId)
                 select Field);
            return Fields;
            
        } 
    }
}

