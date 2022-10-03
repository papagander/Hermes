using DataAccess.EFCore.Interfaces.Repositories.ReadOnly;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Interfaces.Repositories.FieldSets;

public interface IReadFieldTypeRepository : 
    IReadRepository<FieldType>
{}