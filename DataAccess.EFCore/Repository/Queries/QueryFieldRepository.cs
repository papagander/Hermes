global using DataAccess.EFCore.Interfaces.Repositories.Queries;

using Domain.Models.DataSets;
using Domain.Models.Queries;

using System;

namespace DataAccess.EFCore.Repository.Queries
{
    public class QueryFieldRepository : IndexedRepository<QueryField>, IQueryFieldRepository
    {
        public QueryFieldRepository(ReportContext reportContext) : base(reportContext) 
        {

        }

        public IEnumerable<QueryField> GetRange(Query MyTRef)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<QueryField> GetRange(Field MyTRef)
        {
            throw new NotImplementedException();
        }
        /*
public IEnumerable<Field> GetFields(int queryId)
{

   IEnumerable<int> fieldIds = (
       from rf in _context.QueryFields
       where rf.Id == queryId
       select rf.Id
       );
   var Fields = _context.Fields;
   List<Field> fieldList = new List<Field>();
   foreach (var fieldId in fieldIds)
       fieldList.Add(Fields.ElementAt(fieldId));
   return fieldList;
}
*/
    }
}

