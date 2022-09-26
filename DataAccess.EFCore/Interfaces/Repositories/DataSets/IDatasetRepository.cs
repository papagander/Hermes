using Domain.Models.DataSets;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Interfaces.Repositories.DataSets
{
    public interface IDatasetRepository : INamedRepository<DataSet>, IReferencedByRepository<DataSet, Field>
    {

    }
}
