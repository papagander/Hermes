using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Interfaces.Repositories.DataCore
{
    public interface IFieldTypeRepository : 
        INamedRepository<FieldType>
        , IReferencedByRepository<FieldType,Operator>
        , IReferencedByRepository<FieldType, FieldTypeOperator>
    {
        IEnumerable<Operator> GetOperators(FieldType fieldType);
        IEnumerable<FieldTypeOperator> GetFieldTypeOperators(FieldType fieldType);
    }
}
