using Domain.Models.DataCore;

using Microsoft.EntityFrameworkCore.Migrations.Operations;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Interfaces.Repositories.DataCore;
public interface IOperatorRepository
    : IUniquelyNamedRepository<Operator>
    , IReferencedByRepository< Operator, OperatorFieldType>
    , IReferencedByRepository<Operator, Parameter>
{
    public void Add(string name, string executionString,  IEnumerable<DbType> types, IEnumerable<Parameter> parameters);
}
