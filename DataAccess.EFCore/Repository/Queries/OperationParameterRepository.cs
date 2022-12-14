using DataAccess.EFCore.Interfaces.Repositories.Queries;

using Domain.Models.Queries;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repository.Queries
{
    public class OperationParameterRepository 
        : IndexedRepository<OperationParameter>
        , IOperationParameterRepository
    {
        ReferencesRepository<OperationParameter, Operation> Opn;
        ReferencesRepository<OperationParameter, Parameter> P;
        public OperationParameterRepository(ReportContext reportContext) : base(reportContext)
        {
            Opn = new ReferencesRepository<OperationParameter, Operation>(context);
            P = new ReferencesRepository<OperationParameter, Parameter>(context);
        }

        public IEnumerable<OperationParameter> GetRange(Operation MyTRef) => Opn.GetRange(MyTRef);
        public IEnumerable<OperationParameter> GetRange(Parameter par) => P.GetRange(par);
    }
}
