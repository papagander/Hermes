using Microsoft.EntityFrameworkCore.Migrations.Operations;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Interfaces.Repositories.DataCore;
public interface IOperatorRepository :
    IUniquelyNamedRepository<Operator>
{
    public void Add(string name, IEnumerable<DbType> types);
}
