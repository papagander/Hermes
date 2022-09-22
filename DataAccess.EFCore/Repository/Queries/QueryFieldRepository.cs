global using DataAccess.EFCore.Interfaces.Repositories.Queries;
using System;
namespace DataAccess.EFCore.Repository.Queries
{
    public class QueryFieldRepository : CrdRepository<QueryField>, IQueryFieldRepository
    {
        public QueryFieldRepository(ReportContext reportContext) :base(reportContext){}
        public IEnumerable<Field> GetFields(int queryId)
        {

            IEnumerable<int> fieldIds = (
                from rf in _context.QueryFields
                where rf.QueryId == queryId
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

