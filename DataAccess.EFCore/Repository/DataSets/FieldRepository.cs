using DataAccess.EFCore.Interfaces.Repositories.DataSets;

using Domain.Models.DataSets;
using Domain.Models.Queries;

using System;
using System.Linq;
namespace DataAccess.EFCore.Repository.DataSets
{
    public class FieldRepository : NamedRepository<Field>, IFieldRepository
    {
        private ReferencesRepository<Field, DataSet> RefDS;
        public FieldRepository(ReportContext reportContext) : base(reportContext)
        {
        }


        public IEnumerable<Field> GetRange(DataSet MyTRef) => RefDS.GetRange(MyTRef);
        /*
public IEnumerable<Field> GetFieldsByDataSetId(int templateId)
{
   return _context.Field.Where<Field>(f => f.Id == templateId);
}
public IEnumerable<Field> GetFieldsByQueryId(int queryId)
{
   IEnumerable<int> fieldIds =
       (from queryField in _context.QueryFields where queryField.Id == queryId
        select queryField.Id);
   IEnumerable<Field> Field =
       (from Field in _context.Field where fieldIds.Contains(Field.Id)
        select Field);
   return Field;

} 
*/
    }
}

