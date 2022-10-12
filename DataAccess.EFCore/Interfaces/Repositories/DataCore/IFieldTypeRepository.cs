using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Interfaces.Repositories.DataCore
{
    public interface IFieldTypeRepository : 
        IUniquelyNamedRepository<FieldType>
        , IReferencedByRepository<FieldType,Operator>
    {
        IEnumerable<Operator> GetOperators(FieldType fieldType);
    }
}
