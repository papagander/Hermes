using DataAccess.EFCore.Interfaces.Repositories.DataSets;

using Domain.Models.DataSets;
using Domain.Models.Queries;

using System;
using System.Linq;
namespace DataAccess.EFCore.Repository.DataSets
{
    public class FieldRepository : NamedRepository<Field>, IFieldRepository
    {
        private ReferencedByRepository<Field, Query> RefQ;
        private ReferencesRepository<Field, DataSet> RefDS;
        public FieldRepository(ReportContext reportContext) : base(reportContext)
        {
            RefQ = new ReferencedByRepository<Field, Query>(reportContext);
        }

        public IEnumerable<Query> GetChildren(Field MyT) => RefQ.GetChildren(MyT);

        public IEnumerable<Field> GetRange(DataSet MyTRef) => RefDS.GetRange(MyTRef);
        /*
public IEnumerable<Field> GetFieldsByDataSetId(int templateId)
{
   return _context.Fields.Where<Field>(f => f.Id == templateId);
}
public IEnumerable<Field> GetFieldsByQueryId(int queryId)
{
   IEnumerable<int> fieldIds =
       (from queryField in _context.QueryFields where queryField.Id == queryId
        select queryField.Id);
   IEnumerable<Field> Fields =
       (from Field in _context.Fields where fieldIds.Contains(Field.Id)
        select Field);
   return Fields;

} 
*/
    }
}

