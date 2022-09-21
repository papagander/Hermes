global using DataAccess.EFCore.Interfaces.Repositories.Reports;
using System;
namespace DataAccess.EFCore.Repository.Reports
{
    public class ReportFieldRepository : CrdRepository<ReportField>, IReportFieldRepository
    {
        public ReportFieldRepository(ReportContext reportContext) :base(reportContext){}
        public IEnumerable<Field> GetFields(int reportId)
        {

            IEnumerable<int> fieldIds = (
                from rf in _context.ReportFields
                where rf.ReportId == reportId
                select rf.FieldId
                );
            var Fields = _context.Fields;
            List<Field> fieldList = new List<Field>();
            foreach (var fieldId in fieldIds)
                fieldList.Add(Fields.ElementAt(fieldId));
            return fieldList;
        }
    }
}

