using DataAccess.EFCore.Interfaces.Repositories.FieldSets;

using Domain.Models.FieldSets;
using Domain.Models.Queries;

using System;
using System.Linq;
namespace DataAccess.EFCore.Repository.FieldSets
{
    public class FieldRepository : IndexedRepository<Field>, IFieldRepository
    {
        private ReferencesRepository<Field, FieldSet> Fs;
        public FieldRepository(ReportContext reportContext) : base(reportContext)
        {
        }


        public IEnumerable<Field> GetRange(FieldSet MyTRef) => Fs.GetRange(MyTRef);
    }
}

