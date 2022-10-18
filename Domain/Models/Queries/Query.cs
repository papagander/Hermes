
using Domain.Interfaces.Models;
using Domain.Models.FieldSets;

namespace Domain.Models.Queries;

public class Query : Named, IReferences<FieldSets.FieldSet>, IReferencedBy<Field>
{
    public override string ToString() => $"{FieldSet.Name}.{Name}";
    public int FieldSetId { get; set; }
    public int StatementId { get; set; }
    public FieldSet FieldSet { get; set; }
    public Statement Statement { get; set; }
    public List<Field> Fields { get; set; }
    int IReferences<FieldSet>.MyTRefId { get => FieldSetId; /*set => Id = value;*/ }
    FieldSet IReferences<FieldSet>.MyTRef { get => FieldSet; /*set => FieldSet = value;*/ }
    List<Field> IReferencedBy<Field>.MyTs { get => Fields; set => Fields = value; }
    //int IReferences<Statement>.MyTRefId { get => Id; /*set => Id = value;*/ }
    //Statement IReferences<Statement>.MyTRef { get => Statement; /*set => Statement = value;*/ }
}




