using DataAccess.EFCore.Interfaces.Repositories.Queries;

using Domain.Models.Queries;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repository.Queries
{
    public class CriterionValueRepository : IndexedRepository<CriterionParamater>, ICriterionValueRepository
    {
        ReferencesRepository<CriterionParamater, Criterion> RefCr;
        public CriterionValueRepository(ReportContext reportContext) : base(reportContext)
        {
            RefCr = new ReferencesRepository<CriterionParamater, Criterion>(reportContext);
        }

        public IEnumerable<CriterionParamater> GetRange(Criterion MyTRef) => RefCr.GetRange(MyTRef);
    }
}
