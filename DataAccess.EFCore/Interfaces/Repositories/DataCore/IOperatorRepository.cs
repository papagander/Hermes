using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Interfaces.Repositories.DataCore;
public interface IOperatorRepository :
    INamedRepository<Operator>
    , IReferencedByRepository<Operator, FieldType>
    , IReferencedByRepository<Operator, FieldTypeOperator>
{
    public IEnumerable<FieldType> GetFieldTypes(Operator ent);
}
