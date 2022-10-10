using Domain.Interfaces.Models;
using Domain.Models.DataCore;
using Domain.Models.Queries;

namespace Domain.Models.FieldSets;

public class Field : Indexed, IReferences<FieldSet>, IReferences<FieldType>
{
    public override string ToString()
    {

        if (FieldSet is not null) return $"{FieldSet.Name}.{Name} ({FieldType.Name})";
        else return Name;
    }
    public string Name { get; set; }
    public int FieldSetId { get; set; }
    public int FieldTypeId { get; set; }
    public FieldType FieldType { get; set; }
    public FieldSet FieldSet { get; set; }
    internal List<Query> Queries { get; set; }
    int IReferences<FieldSet>.MyTRefId { get => FieldSetId;  /*set => Id = value;  */}
    int IReferences<FieldType>.MyTRefId { get =>FieldTypeId; /*set => Id = value;*/ }
    FieldSet IReferences<FieldSet>.MyTRef { get => FieldSet; /*set => FieldSet = value;*/ }
    FieldType IReferences<FieldType>.MyTRef { get => FieldType; /*set => FieldType = value;*/ }
}

