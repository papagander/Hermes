using DataAccess.EFCore.Interfaces.Repositories.FieldSets;

using Domain.Models.FieldSets;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repository.FieldSets;
public class FieldSetRepository : UniquelyNamedRepository<FieldSet>, IFieldSetRepository
{
    private ReferencedByRepository<FieldSet, Field> f;
    public FieldSetRepository(ReportContext _context) : base(_context)
    {
        f = new ReferencedByRepository<FieldSet, Field>(_context);
    }

    public void AddChildren(FieldSet tRef, IEnumerable<Field> Children) => f.AddChildren(tRef, Children);

    public IEnumerable<Field> GetChildren(FieldSet MyT) => f.GetChildren(MyT);

    public IEnumerable<Field> GetFields(FieldSet dt) => f.GetChildren(dt);

    public void RemoveChildren(FieldSet tRef, IEnumerable<Field> Children) => f.RemoveChildren(tRef, Children);

    public void SetChildren(FieldSet tRef, IEnumerable<Field> Children) => f.SetChildren(tRef, Children);
}
