using Domain.Models.FieldSets;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Interfaces.Repositories.FieldSets
{
    public interface IFieldSetRepository : IUniquelyNamedRepository<FieldSet>, IReferencedByRepository<FieldSet, Field>
    {
        IEnumerable<Field> GetFields(FieldSet dt);
    }
}
