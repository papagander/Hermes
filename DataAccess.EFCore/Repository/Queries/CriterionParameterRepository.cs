using DataAccess.EFCore.Interfaces.Repositories.Queries;

using Domain.Models.Queries;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repository.Queries
{
    public class CriterionParameterRepository 
        : IndexedRepository<CriterionParameter>
        , ICriterionParameterRepository
    {
        ReferencesRepository<CriterionParameter, Criterion> RefCr;
        ReferencesRepository<CriterionParameter, Parameter> P;
        public CriterionParameterRepository(ReportContext reportContext) : base(reportContext)
        {
            RefCr = new ReferencesRepository<CriterionParameter, Criterion>(hContext);
            P = new ReferencesRepository<CriterionParameter, Parameter>(hContext);
        }

        public IEnumerable<CriterionParameter> GetRange(Criterion MyTRef) => RefCr.GetRange(MyTRef);
        public IEnumerable<CriterionParameter> GetRange(Parameter par) => P.GetRange(par);
    }
}
