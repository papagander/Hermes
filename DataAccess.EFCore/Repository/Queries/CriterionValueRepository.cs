using Domain.Models.Queries;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repository.Queries
{
    public class CriterionValueRepository : IndexedRepository<CriterionValue>, ICriterionValueRepository
    {
        ReferencesRepository<CriterionValue, Criterion> RefCr;
        public CriterionValueRepository(ReportContext reportContext) : base(reportContext)
        {
            RefCr = new ReferencesRepository<CriterionValue, Criterion>(reportContext);
        }

        public IEnumerable<CriterionValue> GetRange(Criterion MyTRef) => RefCr.GetRange(MyTRef);
    }
}
