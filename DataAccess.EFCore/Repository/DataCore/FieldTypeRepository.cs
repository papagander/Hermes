global using Domain.Models.DataCore;

global using DataAccess.EFCore.Interfaces.Repositories;
global using DataAccess.EFCore.Interfaces.Repositories.DataCore;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repository.DataCore
{
    public class FieldTypeRepository :
        UniquelyNamedRepository<FieldType>
        , IFieldTypeRepository
    {
        ReferencedByRepository<FieldType, Operator> RefOp;
        public FieldTypeRepository(ReportContext _context) : base(_context)
        {
            RefOp = new ReferencedByRepository<FieldType, Operator>(_context);
        }

        public void AddChildren(FieldType ft, IEnumerable<Operator> Children) => RefOp.AddChildren(ft,Children); 

        public IEnumerable<Operator> GetOperators(FieldType MyT) => RefOp.GetChildren(MyT);

        public void RemoveChildren(FieldType MyT, IEnumerable<Operator> Children) => RefOp.RemoveChildren(MyT, Children);

        IEnumerable<Operator> IReferencedByRepository<FieldType, Operator>.GetChildren(FieldType MyT) => GetOperators(MyT);

        public void SetChildren(FieldType tRef, IEnumerable<Operator> Children) => RefOp.SetChildren(tRef, Children);
    }
}
