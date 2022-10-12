using Domain.Interfaces.Models;
using Domain.Models.DataCore;
using Domain.Models.Queries;

using System.Data;

namespace Domain.Models.FieldSets;

public class Field : Named, IReferences<FieldSet>
{
    public override string ToString()
    {

        if (FieldSet is not null) return $"{FieldSet.Name}.{Name} ({Type.ToString()})";
        else return Name;
    }
    public int FieldSetId { get; set; }
    public int FieldTypeId { get; set; }
    public DbType Type { get; set; }
    public FieldSet FieldSet { get; set; }
    internal List<Query> Queries { get; set; }
    int IReferences<FieldSet>.MyTRefId { get => FieldSetId;  /*set => Id = value;  */}
    FieldSet IReferences<FieldSet>.MyTRef { get => FieldSet; /*set => FieldSet = value;*/ }
}

